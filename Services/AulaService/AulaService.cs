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

        //El metodo no esta 100% igual al diseño, esto es una base para probar
        /*public HashSet<AulaDTO> GetDisponibilidadAula(ReservaDTO reservaDTO)
        {

            HashSet<AulaDTO> aula = reservaDTO.aulas;


            //Obtenemos segun el tipo de aula
            var tipoAulaHandlers = new Dictionary<Type, Func<HashSet<Aula>>>
                {
                    { typeof(AulaInformaticaDTO), () => _aulaDao.getAulasByTipo<AulaInformatica>() },
                    { typeof(AulaMultimediosDTO), () => _aulaDao.getAulasByTipo<AulaMultimedios>() },
                    { typeof(AulaSinRecursosAdicionalesDTO), () => _aulaDao.getAulasByTipo<AulaSinRecursosAdicionales>() }
                };

            var aulaTipo = reservaDTO.aulas.Any().GetType();

            if (!tipoAulaHandlers.TryGetValue(aulaTipo, out var aulas))
                throw new NotFoundException($"El tipo de aula {aulaTipo.Name} no es válido.");

            var aulasDisponibles = aulas()
                                 .Where(aula =>
                                 {
                                     // Verifica si la capacidad del aula alcanza para los alumnos
                                     if (aula.getCapacidad() < reservaDTO.cantidad_alumnos) return false;

                                     // Verifica si existen dias asociados al aula que están ocupados en el horario y día de la semana especificados
                                     return !aula.Dias
                                         .Any(d =>
                                         {
                                             // Si existe un horario para el dia en la reserva
                                             if (reservaDTO.horariosPorDia.TryGetValue(d.DiaSemana, out var tuple))
                                             {
                                                 TimeOnly horaInicioExistente = tuple.Item1;
                                                 int duracionExistente = tuple.Item2;

                                                 TimeOnly horaFinDia = d.HoraInicio.AddMinutes(d.DuracionMinutos);
                                                 TimeOnly horaFinExistente = horaInicioExistente.AddMinutes(duracionExistente);

                                                 // Verifica si hay un solapamiento de horarios
                                                 return d.HoraInicio < horaFinExistente && horaFinDia > horaInicioExistente;
                                             }
                                             return false;
                                         });
                                 })
                                 .ToHashSet();


            HashSet<AulaDTO> aulaDTOs = ConvertirADTO(aulasDisponibles);

            aulaDTOs.OrderBy(aula =>
                aula.capacidad
            );

            return aulaDTOs;
        }*/

        public List<List<AulaDTO>> obtenerAulasDisponibles(ReservaEsporadicaDTO reserva)
        {
            var aulas = _aulaDao.ObtenerAulas().ToList();
            aulas = aulas.Where(a => a.getEstado() == true && a.getCapacidad() >= reserva.cantidadAlumnos).ToList();
            var aulasDisponibles = new List<List<Aula>>();
            var reservasEsporadicas = _reservaDao.obtenerReservasEsporadicas();
            var reservasPeriodicas = _reservaDao.obtenerReservasPeriodica();
            foreach (DiaEsporadicaDTO d in reserva.dias)
            {
                var aulasParaDiad = aulas;
                foreach (ReservaEsporadica r in reservasEsporadicas)
                {
                    // Falta agregar comprobacion correcta
                    if (r.DiaEsporadica.dia.Date == d.fecha.Date)
                    {
                        var horaInicio = TimeOnly.Parse(d.horaInicio);
                        if (r.DiaEsporadica.HoraInicio < horaInicio.AddMinutes(d.duracionMinutos) && r.DiaEsporadica.HoraInicio.AddMinutes(r.DiaEsporadica.DuracionMinutos) > horaInicio)
                            aulasParaDiad.Remove(r.DiaEsporadica.Aula);
                    }
                }

                foreach (ReservaPeriodica r in reservasPeriodicas)
                {
                    foreach (DiaPeriodica dp in r.DiasPeriodica)
                    {
                        if ((int)dp.getDiaSemana() == (int)d.fecha.DayOfWeek)
                        {
                            var horaInicio = TimeOnly.Parse(d.horaInicio);
                            if (dp.HoraInicio < horaInicio.AddMinutes(d.duracionMinutos) && dp.HoraInicio.AddMinutes(dp.DuracionMinutos) > horaInicio)
                                aulasParaDiad.Remove(dp.Aula);
                        }
                    }
                    aulasDisponibles.Add(aulasParaDiad);
                }
            }
            //Maybe TODO: CAMBIAR A DICCIONARIO
            return ConvertirADTO(aulasDisponibles);
        }
        public bool disponibilidadAulaParaEsporadica(DiaEsporadicaDTO dia, Aula aula)
        {
            var reservasEsporadicas = _reservaDao.obtenerReservasEsporadicas().Where(r => r.DiaEsporadica.idAula == aula.getIdAula());
            var reservasPeriodicas = _reservaDao.obtenerReservasPeriodica();
            var horaInicio = TimeOnly.Parse(dia.horaInicio);
            foreach (ReservaEsporadica reservaEsporadicaGuardada in reservasEsporadicas)
            {
                // Falta agregar comprobacion correcta
                if (reservaEsporadicaGuardada.DiaEsporadica.dia.Date == dia.fecha)
                {
                    if (reservaEsporadicaGuardada.DiaEsporadica.HoraInicio < horaInicio.AddMinutes(dia.duracionMinutos) && reservaEsporadicaGuardada.DiaEsporadica.HoraInicio.AddMinutes(reservaEsporadicaGuardada.DiaEsporadica.DuracionMinutos) > horaInicio)
                        return false;
                }
            }

            foreach (ReservaPeriodica reservaPeriodicaGuardada in reservasPeriodicas)
            {
                foreach (DiaPeriodica diaPeriodicaDelaReserva in reservaPeriodicaGuardada.DiasPeriodica)
                {
                    if ((int)diaPeriodicaDelaReserva.getDiaSemana() == (int)dia.fecha.DayOfWeek)
                    {
                        if (diaPeriodicaDelaReserva.HoraInicio < horaInicio.AddMinutes(dia.duracionMinutos) && diaPeriodicaDelaReserva.HoraInicio.AddMinutes(diaPeriodicaDelaReserva.DuracionMinutos) > horaInicio)
                            return false;
                    }
                }
            }
            return true;
        }
    


        /*private bool disponibilidadAulaParaPeriodo(DiaSemana dia, TimeOnly horaInicio, TimeOnly horaFin, Aula aula)
        {
            foreach (Dia d in aula.Dias)
            {
                if (d.DiaSemana == dia)
                {
                    TimeOnly horaFinDia = d.HoraInicio.AddMinutes(d.DuracionMinutos);
                    TimeOnly horaFinReserva = horaFin;

                    if (d.HoraInicio < horaFinReserva && horaFinDia > horaInicio)
                    {
                        return false;
                    }
                }
            }
            return true;
        }*/



        private List<List<AulaDTO>> ConvertirADTO(List<List<Aula>> aulas)
        {

            List<List<AulaDTO>> result = new List<List<AulaDTO>>();

            foreach (var aula in aulas)
            {
                List<AulaDTO> aulaDTOs = new List<AulaDTO>();
                foreach (var a in aula)
                {
                    aulaDTOs.Add(new AulaDTO(a));
                }
                result.Add(aulaDTOs);
            }

            return result;

        }

        public HashSet<AulaDTO> GetDisponibilidadAula(ReservaDTO reservaDTO)
        {
            throw new NotImplementedException();
        }
    }
}
