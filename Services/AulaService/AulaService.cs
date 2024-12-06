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

namespace Services.AulaService
{
    public class AulaService : IAulaService
    {
        private readonly AulaDAO _aulaDao;

        public AulaService(AulaDAO aulaDao)
        {
            _aulaDao = aulaDao;
        }

        public HashSet<AulaDTO> GetDisponibilidadAula(ReservaDTO reservaDTO)
        {

           AulaDTO aula = reservaDTO.aula;


            //Obtenemos segun el tipo de aula
            var tipoAulaHandlers = new Dictionary<Type, Func<HashSet<Aula>>>
                {
                    { typeof(AulaInformaticaDTO), () => _aulaDao.getAulasByTipo<AulaInformatica>() },
                    { typeof(AulaMultimediosDTO), () => _aulaDao.getAulasByTipo<AulaMultimedios>() },
                    { typeof(AulaSinRecursosAdicionalesDTO), () => _aulaDao.getAulasByTipo<AulaSinRecursosAdicionales>() }
                };

            var aulaTipo = reservaDTO.aula.GetType();

            if (!tipoAulaHandlers.TryGetValue(aulaTipo, out var aulas))
                throw new NotFoundException($"El tipo de aula {aulaTipo.Name} no es válido.");

            var aulasDisponibles = aulas()
                                 .Where(aula =>
                                 {
                                     // Verifica si la capacidad del aula alcanza para los alumnos
                                     if (aula.Capacidad < reservaDTO.cantidad_alumnos) return false;

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
                aulaDto.idAula = aula.IdAula;
                aulaDto.numero = aula.Numero;
                aulaDto.piso = aula.Piso;
                aulaDto.aireAcondicionado = aula.AireAcondicionado;
                aulaDto.estado = aula.Estado;
                aulaDto.capacidad = aula.Capacidad;
                aulaDto.tipoDePizarron = aula.TipoDePizarron;

            }

            return result;

        }
    }
}
