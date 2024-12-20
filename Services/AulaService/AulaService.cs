﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Data.DAO;
using Data.Utilities;
using Model.Abstract;
using Model.DTO;
using Model.Entity;
using Model.Enums;

namespace Services.AulaService
{
    public class AulaService : IAulaService
    {
        private readonly AulaDAO _aulaDao;
        private readonly ReservaDAO _reservaDao;

        public AulaService(AulaDAO aulaDao, ReservaDAO reservaDao)
        {
            _aulaDao = aulaDao;
            _reservaDao = reservaDao;
        }

        public List<DisponibilidadAulaDTO> obtenerAulasPeriodica(ReservaPeriodicaDTO reserva)
        {
            // Obtener aulas del tipo especificado en la reserva
            Type tipoAula = GetTipoAula(reserva.tipoAula);
            var aulas = _aulaDao.getAulasByTipo(tipoAula);

            var aulasFiltradas = aulas.Where(aula => aula.getCapacidad() >= reserva.cantidadAlumnos && aula.getEstado())
                .ToList();

            if (!aulasFiltradas.Any())
            {
                throw new Exception("No hay aulas disponibles que cumplan con la capacidad requerida.");
            }

            List<DiaPeriodicaDTO> dias = reserva.dias;
            return comprobarDisponibilidadAulasPeriodica(dias, aulasFiltradas.ToList(), DateOnly.Parse(reserva.fechaInicio), DateOnly.Parse(reserva.fechaFin));
        }


        public List<DisponibilidadAulaDTO> comprobarDisponibilidadAulasPeriodica(List<DiaPeriodicaDTO> dias,
            List<Aula> aulas, DateOnly fechaInicio, DateOnly fechaFin)
        {
            List<DisponibilidadAulaDTO> disponibilidadPorDia = new List<DisponibilidadAulaDTO>();

            foreach (DiaPeriodicaDTO d in dias)
            {
                DiaSemana diaSemana = d.diaSemana;
                TimeOnly horaInicio = TimeOnly.Parse(d.horaInicio);
                TimeOnly horaFin = horaInicio.AddMinutes(d.duracionMinutos);

                List<AulaDTO> aulasDisponibles = new List<AulaDTO>();
                List<SuperposicionInfoDTO> todasSuperposiciones = new List<SuperposicionInfoDTO>();

                foreach (Aula a in aulas)
                {
                    var superposiciones = CalcularSuperposicionPeriodica(diaSemana, horaInicio, horaFin, a, fechaInicio, fechaFin);

                    if (superposiciones.Count == 0)
                    {
                        // No hay superposición, agregar aula disponible
                        aulasDisponibles.Add(ConvertirAulaADTO(a));
                    }
                    else
                    {
                        // Agregar todas las superposiciones
                        todasSuperposiciones.AddRange(superposiciones);
                    }
                }

                // Procesar aulas disponibles y superposiciones
                List<SuperposicionInfoDTO> superposicionesMinimas = new List<SuperposicionInfoDTO>();
                if (aulasDisponibles.Count == 0 && todasSuperposiciones.Count > 0)
                {
                    // Si no hay aulas disponibles, buscar las superposiciones mínimas
                    double minHorasSuperpuestas = todasSuperposiciones.Min(x => x.HorasSuperpuestas);
                    superposicionesMinimas = todasSuperposiciones
                        .Where(x => x.HorasSuperpuestas == minHorasSuperpuestas)
                        .ToList();
                }
                var disponibilidadAulaDTO = crearDisponibilidadAulaDto(null, diaSemana, aulasDisponibles, superposicionesMinimas);

                disponibilidadPorDia.Add(disponibilidadAulaDTO);
            }

            return disponibilidadPorDia;
        }

        public DisponibilidadAulaDTO crearDisponibilidadAulaDto(DateTime? dia,DiaSemana DiaSemana, List<AulaDTO> AulasDisponibles, List<SuperposicionInfoDTO> SuperposicionesMinimas)
        {
            return new DisponibilidadAulaDTO
            {
                Dia = dia,
                DiaSemana = DiaSemana,
                AulasDisponibles = AulasDisponibles,
                SuperposicionesMinimas = SuperposicionesMinimas
            };
        }

        public List<SuperposicionInfoDTO> CalcularSuperposicionPeriodica(DiaSemana diaSemana, TimeOnly horaInicio,
            TimeOnly horaFin, Aula aula, DateOnly fechaInicio, DateOnly fechaFin)
        {
            List<SuperposicionInfoDTO> superposiciones = new List<SuperposicionInfoDTO>();
            var reservasEsporadicas = _reservaDao.obtenerReservasEsporadicas();
            var reservasPeriodicasGuardadas = _reservaDao.obtenerReservasPeriodica();

            foreach (Dia d in aula.Dias)
            {
                if (d is DiaPeriodica diaPeriodica && diaPeriodica.getDiaSemana() == diaSemana)
                {
                    TimeOnly horaFinDia = diaPeriodica.HoraInicio.AddMinutes(diaPeriodica.DuracionMinutos);
                    if (diaPeriodica.HoraInicio < horaFin && horaFinDia > horaInicio && diaPeriodica.ReservaPeriodica.Cuatrimestres.Any(c => c.getFechaInicio <= fechaFin && c.getFechaFin >= fechaInicio))
                    {
                        double horasSolapadas = CalcularHorasSolapadas(horaInicio, horaFin, diaPeriodica.HoraInicio, horaFinDia);
                        superposiciones.Add(crearSuperposicionInfo(ConvertirAulaADTO(aula),
                            ConvertirReservaADTO(reservasPeriodicasGuardadas.FirstOrDefault(r => r.getId() == diaPeriodica.idReserva)),
                            diaPeriodica.HoraInicio, 
                            horaFinDia,
                            horasSolapadas));
                    }
                }
                else if (d is DiaEsporadica diaEsporadica && (int)diaEsporadica.dia.DayOfWeek == (int)diaSemana && diaEsporadica.dia >= DateTime.Parse(fechaInicio.ToString()) && diaEsporadica.dia >= DateTime.Parse(fechaFin.ToString()))
                {
                    TimeOnly horaFinDia = diaEsporadica.HoraInicio.AddMinutes(diaEsporadica.DuracionMinutos);
                    if (diaEsporadica.HoraInicio < horaFin && horaFinDia > horaInicio)
                    {
                        double horasSolapadas =
                            CalcularHorasSolapadas(horaInicio, horaFin, diaEsporadica.HoraInicio, horaFinDia);
                        superposiciones.Add(crearSuperposicionInfo(ConvertirAulaADTO(aula), ConvertirReservaADTO(reservasPeriodicasGuardadas.FirstOrDefault(r => r.getId() == diaEsporadica.idReserva)), diaEsporadica.HoraInicio, horaFinDia, horasSolapadas));
                    }
                }

            }
            return superposiciones;
        }
        public ReservaDTO ConvertirReservaADTO(Reserva reserva)
        {
            if (reserva is ReservaEsporadica reservaEsporadica)
            {
                return new ReservaEsporadicaDTO
                {
                    idReserva = reservaEsporadica.getId(),
                    profesor = reservaEsporadica.getProfesor(),
                    nombreCatedra = reservaEsporadica.getNombreCatedra(),
                    correoElectronico = reservaEsporadica.getCorreoElectronico(),
                    idBedel = reservaEsporadica.idBedel,
                    dias = ConvertirDiasEsporadicos(reservaEsporadica.DiasEsporadica)
                };
            }
            else if (reserva is ReservaPeriodica reservaPeriodica)
            {
                return new ReservaPeriodicaDTO
                {
                    idReserva = reservaPeriodica.getId(),
                    profesor = reservaPeriodica.getProfesor(),
                    nombreCatedra = reservaPeriodica.getNombreCatedra(),
                    correoElectronico = reservaPeriodica.getCorreoElectronico(),
                    tipoPeriodo = reservaPeriodica.getTipoPeriodo(),
                    idBedel = reservaPeriodica.idBedel,
                    fechaInicio = reservaPeriodica.getFechaInicio().ToString("yyyy-MM-dd"),
                    fechaFin = reservaPeriodica.getFechaFin().ToString("yyyy-MM-dd"),
                    dias = ConvertirDiasPeriodicos(reservaPeriodica.DiasPeriodica)
                };
            }
            else
            {
                throw new ArgumentException("Tipo de reserva no soportado");
            }
        }

        public SuperposicionInfoDTO crearSuperposicionInfo(AulaDTO Aula, ReservaDTO Reserva, TimeOnly HoraInicio, TimeOnly HoraFin, double HorasSuperpuestas)
        {
            return new SuperposicionInfoDTO
            {
                Aula = Aula,
                Reserva = Reserva,
                HoraInicio = HoraInicio,
                HoraFin = HoraFin,
                HorasSuperpuestas = HorasSuperpuestas
            };
        }

        public List<DisponibilidadAulaDTO> obtenerAulasEsporadica(ReservaEsporadicaDTO reserva)
        {
            // Obtener aulas del tipo especificado en la reserva
            Type tipoAula = GetTipoAula(reserva.tipoAula);
            var aulas = _aulaDao.getAulasByTipo(tipoAula);
            var aulasFiltradas = aulas.Where(aula => aula.getCapacidad() >= reserva.cantidadAlumnos && aula.getEstado())
                .ToList();

            if (!aulasFiltradas.Any())
            {
                throw new Exception("No hay aulas disponibles que cumplan con la capacidad requerida.");
            }

            List<DiaEsporadicaDTO> dias = reserva.dias.ToList();
            return comprobarDisponibilidadAulasEsporadica(dias, aulasFiltradas.ToList());
        }

        private Type GetTipoAula(TipoAula tipoAula)
        {
            return tipoAula switch
            {
                TipoAula.Informatica => typeof(AulaInformatica),
                TipoAula.Multimedios => typeof(AulaMultimedios),
                TipoAula.SinRecursosAdicionales => typeof(AulaSinRecursosAdicionales),
                _ => throw new ArgumentException("Tipo de aula no soportado")
            };
        }


        public List<DisponibilidadAulaDTO> comprobarDisponibilidadAulasEsporadica(List<DiaEsporadicaDTO> dias,
            List<Aula> aulas)
        {
            List<DisponibilidadAulaDTO> disponibilidadPorDia = new List<DisponibilidadAulaDTO>();

            foreach (DiaEsporadicaDTO d in dias)
            {
                DateTime fecha = d.fecha;
                TimeOnly horaInicio = TimeOnly.Parse(d.horaInicio);
                TimeOnly horaFin = horaInicio.AddMinutes(d.duracionMinutos);

                List<AulaDTO> aulasDisponibles = new List<AulaDTO>();
                List<SuperposicionInfoDTO> todasSuperposiciones = new List<SuperposicionInfoDTO>();

                foreach (Aula a in aulas)
                {
                    var superposiciones = CalcularSuperposicion(fecha, horaInicio, horaFin, a);

                    if (superposiciones.Count == 0)
                    {
                        // No hay superposición, agregar aula disponible
                        aulasDisponibles.Add(ConvertirAulaADTO(a));
                    }
                    else
                    {
                        // Agregar todas las superposiciones
                        todasSuperposiciones.AddRange(superposiciones);
                    }
                }

                // Procesar aulas disponibles y superposiciones
                List<SuperposicionInfoDTO> superposicionesMinimas = new List<SuperposicionInfoDTO>();
                if (aulasDisponibles.Count == 0 && todasSuperposiciones.Count > 0)
                {
                    // Si no hay aulas disponibles, buscar las superposiciones mínimas
                    double minHorasSuperpuestas = todasSuperposiciones.Min(x => x.HorasSuperpuestas);
                    superposicionesMinimas = todasSuperposiciones
                        .Where(x => x.HorasSuperpuestas == minHorasSuperpuestas)
                        .ToList();
                }      
                var disponibilidadAulaDTO = crearDisponibilidadAulaDto(fecha, (DiaSemana)fecha.DayOfWeek, aulasDisponibles, superposicionesMinimas);

                disponibilidadPorDia.Add(disponibilidadAulaDTO);
            }

            return disponibilidadPorDia;
        }

        public List<SuperposicionInfoDTO> CalcularSuperposicion(DateTime dia, TimeOnly horaInicio, TimeOnly horaFin,
            Aula aula)
        {
            List<SuperposicionInfoDTO> superposiciones = new List<SuperposicionInfoDTO>();
            var reservasEsporadicas = _reservaDao.obtenerReservasEsporadicas();
            var reservasPeriodicas = _reservaDao.obtenerReservasPeriodica().Where(rP => rP.Cuatrimestres.Any(c => DateTime.Parse(c.getFechaInicio.ToString()) <= dia && DateTime.Parse(c.getFechaFin.ToString()) >= dia));

            foreach (Dia d in aula.Dias)
            {
                if (d is DiaEsporadica diaEsporadica && diaEsporadica.dia.Date == dia.Date)
                {
                    TimeOnly horaFinDia = diaEsporadica.HoraInicio.AddMinutes(diaEsporadica.DuracionMinutos);
                    if (diaEsporadica.HoraInicio < horaFin && horaFinDia > horaInicio)
                    {
                        double horasSolapadas =
                            CalcularHorasSolapadas(horaInicio, horaFin, diaEsporadica.HoraInicio, horaFinDia);
                        superposiciones.Add(crearSuperposicionInfo(ConvertirAulaADTO(aula), ConvertirReservaADTO(reservasEsporadicas.FirstOrDefault(r => r.getId() == diaEsporadica.idReserva)), diaEsporadica.HoraInicio, horaFinDia, horasSolapadas));
                    }
                }
                else if (d is DiaPeriodica diaPeriodica)
                {
                    if ((int)diaPeriodica.getDiaSemana() == (int)dia.DayOfWeek)
                    {
                        TimeOnly horaFinDia = diaPeriodica.HoraInicio.AddMinutes(diaPeriodica.DuracionMinutos);
                        if (diaPeriodica.HoraInicio < horaFin && horaFinDia > horaInicio)
                        {
                            double horasSolapadas = CalcularHorasSolapadas(horaInicio, horaFin, diaPeriodica.HoraInicio,
                                horaFinDia);
                            var reservaPeriodica = reservasPeriodicas.FirstOrDefault(r => r.getId() == diaPeriodica.idReserva);
                            if (reservaPeriodica != null)
                            {
                                superposiciones.Add(crearSuperposicionInfo(
                                    ConvertirAulaADTO(aula),
                                    ConvertirReservaADTO(reservaPeriodica),
                                    diaPeriodica.HoraInicio,
                                    horaFinDia,
                                    horasSolapadas));
                            }
                        }
                    }
                }
            }

            return superposiciones;
        }

        public ICollection<DiaEsporadicaDTO> ConvertirDiasEsporadicos(IEnumerable<DiaEsporadica> diasEsporadicos)
        {
            return diasEsporadicos.Select(d => new DiaEsporadicaDTO
            {
                idDia = d.IdDia,
                numeroAula = d.Aula?.getNumero(), // Si Aula es null, retorna null
                horaInicio = d.HoraInicio.ToString("HH:mm"),
                duracionMinutos = d.DuracionMinutos,
                fecha = d.dia
            }).ToList();
        }

        public List<DiaPeriodicaDTO> ConvertirDiasPeriodicos(IEnumerable<DiaPeriodica> diasPeriodicos)
        {
            return diasPeriodicos.Select(d => new DiaPeriodicaDTO
            {
                idDia = d.IdDia,
                numeroAula = d.Aula?.getNumero(), // Si Aula es null, retorna null
                horaInicio = d.HoraInicio.ToString("HH:mm"),
                duracionMinutos = d.DuracionMinutos,
                diaSemana = d.getDiaSemana()
            }).ToList();
        }

        public double CalcularHorasSolapadas(TimeOnly inicio1, TimeOnly fin1, TimeOnly inicio2, TimeOnly fin2)
        {
            var overlapStart = inicio1 > inicio2 ? inicio1 : inicio2;
            var overlapEnd = fin1 < fin2 ? fin1 : fin2;
            if (overlapEnd > overlapStart)
            {
                return (overlapEnd.ToTimeSpan() - overlapStart.ToTimeSpan()).TotalHours;
            }

            return 0;
        }

        public AulaDTO ConvertirAulaADTO(Aula aula)
        {
            if (aula is AulaInformatica aulaInformatica)
            {
                return new AulaInformaticaDTO(
                    idAula: aulaInformatica.getIdAula(),
                    numero: aulaInformatica.getNumero(),
                    piso: aulaInformatica.getPiso(),
                    aireAcondicionado: aulaInformatica.getAireAcondicionado(),
                    estado: aulaInformatica.getEstado(),
                    capacidad: aulaInformatica.getCapacidad(),
                    tipoDePizarron: aulaInformatica.getTipoDePizarron(),
                    canion: aulaInformatica.getCanion(),
                    cantidadComputadoras: aulaInformatica.getCantidadComputadoras()
                );
            }
            else if (aula is AulaMultimedios aulaMultimedios)
            {
                return new AulaMultimediosDTO(
                    idAula: aulaMultimedios.getIdAula(),
                    numero: aulaMultimedios.getNumero(),
                    piso: aulaMultimedios.getPiso(),
                    aireAcondicionado: aulaMultimedios.getAireAcondicionado(),
                    estado: aulaMultimedios.getEstado(),
                    capacidad: aulaMultimedios.getCapacidad(),
                    tipoDePizarron: aulaMultimedios.getTipoDePizarron(),
                    televisor: aulaMultimedios.getTelevisor(),
                    poseeVentiladores: aulaMultimedios.getPoseeVentiladores(),
                    canion: aulaMultimedios.getCanion(),
                    cantidadComputadoras: aulaMultimedios.getCantidadComputadoras()
                );
            }
            else if (aula is AulaSinRecursosAdicionales aulaSinRecursos)
            {
                return new AulaSinRecursosAdicionalesDTO(
                    idAula: aulaSinRecursos.getIdAula(),
                    numero: aulaSinRecursos.getNumero(),
                    piso: aulaSinRecursos.getPiso(),
                    aireAcondicionado: aulaSinRecursos.getAireAcondicionado(),
                    estado: aulaSinRecursos.getEstado(),
                    capacidad: aulaSinRecursos.getCapacidad(),
                    tipoDePizarron: aulaSinRecursos.getTipoDePizarron(),
                    poseeVentiladores: aulaSinRecursos.getPoseeVentiladores()
                );
            }
            else
            {
                throw new ArgumentException("Tipo de aula no soportado");
            }
        }
    }
}    
