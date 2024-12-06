using Data.DAO;
using Data.Utilities;
using Model.Abstract;
using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Data.DAO;
using Model.Abstract;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace Services.AulaService
{
    public class AulaService : IAulaService
    {
        private readonly AulaDAO _aulaDao;

        public AulaService(AulaDAO aulaDao)
        {
            _aulaDao = aulaDao;
        }

        //El metodo no esta 100% igual al diseño, esto es una base para probar
        public HashSet<AulaDTO> GetDisponibilidadAula(ReservaDTO reservaDTO)
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
        }

        

        private HashSet<AulaDTO> ConvertirADTO(HashSet<Aula> aulas)
        {

            HashSet<AulaDTO> result = new HashSet<AulaDTO>();

            foreach (Aula aula in aulas)
            {
                AulaDTO aulaDto = new AulaDTO();
                aulaDto.idAula = aula.getIdAula();
                aulaDto.numero = aula.getNumero();
                aulaDto.piso = aula.getPiso();
                aulaDto.aireAcondicionado = aula.getAireAcondicionado();
                aulaDto.estado = aula.getEstado();
                aulaDto.capacidad = aula.getCapacidad();
                aulaDto.tipoDePizarron = aula.getTipoDePizarron();

            }

            return result;

        }

        public AulaInformaticaDTO actualizarAulaInformatica(AulaInformaticaDTO aulaInformaticaDTO)
        {
            try
            {
                var aulaExistente = _aulaDao.obtenerAulaInformatica(aulaInformaticaDTO.idAula);
                if (aulaExistente == null)
                {
                    throw new ArgumentException("No existe el aula");
                }

                if (!(aulaExistente is AulaInformatica))
                {
                    throw new ArgumentException("El aula no es del tipo adecuado.");
                }

                var aulaInformaticaActualizada = modificarAulaInformatica(aulaInformaticaDTO, (AulaInformatica)aulaExistente);

                var updatedAula = _aulaDao.actualizarAulaInformatica(aulaInformaticaActualizada);

                return new AulaInformaticaDTO(
                   idAula: updatedAula.getIdAula(),
                   numero: updatedAula.getNumero(),
                   piso: updatedAula.getPiso(),
                   aireAcondicionado: updatedAula.getAireAcondicionado(),
                   estado: updatedAula.getEstado(),
                   capacidad: updatedAula.getCapacidad(),
                   tipoDePizarron: updatedAula.getTipoDePizarron(),
                   canion: updatedAula.getCanion(),
                   cantidadComputadoras: updatedAula.getCantidadComputadoras()
               );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Aula: " + ex.Message);
            }
        }

        public AulaInformatica modificarAulaInformatica(AulaInformaticaDTO aulaDTO, AulaInformatica aulaExistente)
        {
            if (aulaDTO.numero != aulaExistente.getNumero())
            {
                aulaExistente.setNumero(aulaDTO.numero);
            }

            if (aulaDTO.piso != aulaExistente.getPiso())
            {
                aulaExistente.setPiso(aulaDTO.piso);
            }

            if (aulaDTO.aireAcondicionado != aulaExistente.getAireAcondicionado())
            {
                aulaExistente.setAireAcondicionado(aulaDTO.aireAcondicionado);
            }

            if (aulaDTO.estado != aulaExistente.getEstado())
            {
                aulaExistente.setEstado(aulaDTO.estado);
            }

            if (aulaDTO.capacidad != aulaExistente.getCapacidad())
            {
                aulaExistente.setCapacidad(aulaDTO.capacidad);
            }

            if (aulaDTO.tipoDePizarron != aulaExistente.getTipoDePizarron())
            {
                aulaExistente.setTipoDePizarron(aulaDTO.tipoDePizarron);
            }

            if (aulaDTO.canion != aulaExistente.getCanion())
            {
                aulaExistente.setCanion(aulaDTO.canion);
            }

            if (aulaDTO.cantidadComputadoras != aulaExistente.getCantidadComputadoras())
            {
                aulaExistente.setCantidadComputadoras(aulaDTO.cantidadComputadoras);
            }

            return aulaExistente;
        }

        public AulaMultimediosDTO actualizarAulaMultimedios(AulaMultimediosDTO aulaMultimediosDTO)
        {
            try
            {
                var aulaExistente = _aulaDao.obtenerAulaMultimedios(aulaMultimediosDTO.idAula);
                if (aulaExistente == null)
                {
                    throw new ArgumentException("No existe el aula");
                }
                var aulaMultimediosActualizada = modificarAulaMultimedios(aulaMultimediosDTO, aulaExistente);

                var updatedAula = _aulaDao.actualizarAulaMultimedios(aulaMultimediosActualizada);

                return new AulaMultimediosDTO(
                    idAula: updatedAula.getIdAula(),
                    numero: updatedAula.getNumero(),
                    piso: updatedAula.getPiso(),
                    aireAcondicionado: updatedAula.getAireAcondicionado(),
                    estado: updatedAula.getEstado(),
                    capacidad: updatedAula.getCapacidad(),
                    tipoDePizarron: updatedAula.getTipoDePizarron(),
                    cantidadComputadoras: updatedAula.getCantidadComputadoras(),
                    canion: updatedAula.getCanion(),
                    poseeVentiladores: updatedAula.getPoseeVentiladores(),
                    televisor: updatedAula.getTelevisor()
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Aula: " + ex.Message);
            }
        }

        public AulaMultimedios modificarAulaMultimedios(AulaMultimediosDTO aulaMultimediosDto, AulaMultimedios aulaMultimedios)
        {
            if (aulaMultimediosDto.numero != aulaMultimedios.getNumero())
            {
                aulaMultimedios.setNumero(aulaMultimediosDto.numero);
            }

            if (aulaMultimediosDto.piso != aulaMultimedios.getPiso())
            {
                aulaMultimedios.setPiso(aulaMultimediosDto.piso);
            }

            if (aulaMultimediosDto.aireAcondicionado != aulaMultimedios.getAireAcondicionado())
            {
                aulaMultimedios.setAireAcondicionado(aulaMultimediosDto.aireAcondicionado);
            }

            if (aulaMultimediosDto.estado != aulaMultimedios.getEstado())
            {
                aulaMultimedios.setEstado(aulaMultimediosDto.estado);
            }

            if (aulaMultimediosDto.capacidad != aulaMultimedios.getCapacidad())
            {
                aulaMultimedios.setCapacidad(aulaMultimediosDto.capacidad);
            }

            if (aulaMultimediosDto.tipoDePizarron != aulaMultimedios.getTipoDePizarron())
            {
                aulaMultimedios.setTipoDePizarron(aulaMultimediosDto.tipoDePizarron);
            }

            if (aulaMultimediosDto.televisor != aulaMultimedios.getTelevisor())
            {
                aulaMultimedios.setTelevisor(aulaMultimediosDto.televisor);
            }

            if (aulaMultimediosDto.poseeVentiladores != aulaMultimedios.getPoseeVentiladores())
            {
                aulaMultimedios.setPoseeVentiladores(aulaMultimediosDto.poseeVentiladores);
            }

            if (aulaMultimediosDto.canion != aulaMultimedios.getCanion())
            {
                aulaMultimedios.setCanion(aulaMultimediosDto.canion);
            }

            if (aulaMultimediosDto.cantidadComputadoras != aulaMultimedios.getCantidadComputadoras())
            {
                aulaMultimedios.setCantidadComputadoras(aulaMultimediosDto.cantidadComputadoras);
            }

            return aulaMultimedios;
        }

        public AulaSinRecursosAdicionalesDTO actualizarAulaSinRecursosAdicionales(AulaSinRecursosAdicionalesDTO aulaSinRecursosAdicionalesDTO)
        {
            try
            {
                var aulaExistente = _aulaDao.obtenerAulaSinRecursosAdicionales(aulaSinRecursosAdicionalesDTO.idAula);
                if (aulaExistente == null)
                {
                    throw new ArgumentException("No existe el aula");
                }
                var aulaSinRecursosAdicionalesActualizada = modificarAulaSinRecursosAdicionales(aulaSinRecursosAdicionalesDTO, aulaExistente);
                var updatedAula = _aulaDao.actualizarAulaSinRecursosAdicionales(aulaSinRecursosAdicionalesActualizada);
                return new AulaSinRecursosAdicionalesDTO(
                    idAula: updatedAula.getIdAula(),
                    numero: updatedAula.getNumero(),
                    piso: updatedAula.getPiso(),
                    aireAcondicionado: updatedAula.getAireAcondicionado(),
                    estado: updatedAula.getEstado(),
                    capacidad: updatedAula.getCapacidad(),
                    tipoDePizarron: updatedAula.getTipoDePizarron(),
                    poseeVentiladores: updatedAula.getPoseeVentiladores()
                );

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Aula: " + ex.Message);
            }
        }

        public AulaSinRecursosAdicionales modificarAulaSinRecursosAdicionales(AulaSinRecursosAdicionalesDTO aulaSinRecursosAdicionalesDTO, AulaSinRecursosAdicionales aulaSinRecursosAdicionales)
        {
            if (aulaSinRecursosAdicionalesDTO.numero != aulaSinRecursosAdicionales.getNumero())
            {
                aulaSinRecursosAdicionales.setNumero(aulaSinRecursosAdicionalesDTO.numero);
            }
            if (aulaSinRecursosAdicionalesDTO.piso != aulaSinRecursosAdicionales.getPiso())
            {
                aulaSinRecursosAdicionales.setPiso(aulaSinRecursosAdicionalesDTO.piso);
            }
            if (aulaSinRecursosAdicionalesDTO.aireAcondicionado != aulaSinRecursosAdicionales.getAireAcondicionado())
            {
                aulaSinRecursosAdicionales.setAireAcondicionado(aulaSinRecursosAdicionalesDTO.aireAcondicionado);
            }
            if (aulaSinRecursosAdicionalesDTO.estado != aulaSinRecursosAdicionales.getEstado())
            {
                aulaSinRecursosAdicionales.setEstado(aulaSinRecursosAdicionalesDTO.estado);
            }
            if (aulaSinRecursosAdicionalesDTO.capacidad != aulaSinRecursosAdicionales.getCapacidad())
            {
                aulaSinRecursosAdicionales.setCapacidad(aulaSinRecursosAdicionalesDTO.capacidad);
            }
            if (aulaSinRecursosAdicionalesDTO.tipoDePizarron != aulaSinRecursosAdicionales.getTipoDePizarron())
            {
                aulaSinRecursosAdicionales.setTipoDePizarron(aulaSinRecursosAdicionalesDTO.tipoDePizarron);
            }
            if (aulaSinRecursosAdicionalesDTO.poseeVentiladores != aulaSinRecursosAdicionales.getPoseeVentiladores())
            {
                aulaSinRecursosAdicionales.setPoseeVentiladores(aulaSinRecursosAdicionalesDTO.poseeVentiladores);
            }
            return aulaSinRecursosAdicionales;
        }
    }
}
