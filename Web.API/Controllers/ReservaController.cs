using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Enums;
using Services.AulaService;
using Services.ReservaService;
using Web.API.Utilities;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private IReservaService _reservaService { get; set; }
        private IAulaService _aulaService { get; set; }

        public ReservaController(IReservaService reservaService, IAulaService aulaService)
        {
            _reservaService = reservaService;
            _aulaService = aulaService;
        }


        [HttpPost("guardar-reserva-esporadica")]
        public IActionResult GuardarReservaEsporadica([FromBody] ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            try
            {
                _reservaService.validarReservaEsporadica(reservaEsporadicaDTO);
                List<DisponibilidadAulaDTO> aulasDisponibles = _aulaService.obtenerAulasEsporadica(reservaEsporadicaDTO);
                
                // Filtrar las 3 aulas con mayor capacidad por cada día
                List<DisponibilidadAulaDTO> aulasConMayorCapacidad = aulasDisponibles.Select(disponibilidad =>
                {
                    disponibilidad.AulasDisponibles = disponibilidad.AulasDisponibles
                        .OrderByDescending(aula => aula.capacidad)
                        .Take(3)
                        .ToList();
                    return disponibilidad;
                }).ToList();
                
                List<List<SuperposicionInfoDTO>> superposiciones = new List<List<SuperposicionInfoDTO>>();

                foreach (DisponibilidadAulaDTO disponibilidad in aulasDisponibles)
                {
                    if (disponibilidad.AulasDisponibles.Count == 0)
                    {
                        superposiciones.Add(disponibilidad.SuperposicionesMinimas);
                    }
                }

                if (superposiciones.Count > 0)
                {
                    var response = Response<List<List<SuperposicionInfoDTO>>>.FailureResponse(
                        "No hay aulas disponibles en los horarios seleccionados", superposiciones);
                    return StatusCode(409, response); // Código 409: Conflicto
                }
                
                // Si no hay conflictos, guardar la reserva periódica
                _reservaService.guardarReservaEsporadica(reservaEsporadicaDTO);
                
                var successResponse = Response<List<DisponibilidadAulaDTO>>.SuccessResponse(
                    aulasConMayorCapacidad,
                    "Se guardó la reserva con aulas disponibles"
                );
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = Response<string>.FailureResponse($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, errorResponse); // Código 500: Error interno del servidor
            }
        }

        [HttpPost("guardar-reserva-periodica")]
        public IActionResult GuardarReservaPeriodica([FromBody] ReservaPeriodicaDTO reservaPeriodicaDTO)
        {
            try
            {
                // Validar la reserva periódica
                _reservaService.validarReservaPeriodica(reservaPeriodicaDTO);

                // Obtener la disponibilidad de aulas para la reserva periódica
                List<DisponibilidadAulaDTO> aulasDisponibles = _aulaService.obtenerAulasPeriodica(reservaPeriodicaDTO);

                // Filtrar las 3 aulas con mayor capacidad por cada día
                List<DisponibilidadAulaDTO> aulasConMayorCapacidad = aulasDisponibles.Select(disponibilidad =>
                {
                    disponibilidad.AulasDisponibles = disponibilidad.AulasDisponibles
                        .OrderByDescending(aula => aula.capacidad)
                        .Take(3)
                        .ToList();
                    return disponibilidad;
                }).ToList();

                // Verificar si hay días sin aulas disponibles y recopilar superposiciones
                List<List<SuperposicionInfoDTO>> superposiciones = new List<List<SuperposicionInfoDTO>>();
                foreach (DisponibilidadAulaDTO disponibilidad in aulasConMayorCapacidad)
                {
                    if (disponibilidad.AulasDisponibles.Count == 0)
                    {
                        superposiciones.Add(disponibilidad.SuperposicionesMinimas);
                    }
                }

                // Si hay superposiciones, devolver un error
                if (superposiciones.Count > 0)
                {
                    var conflictResponse = Response<List<List<SuperposicionInfoDTO>>>.FailureResponse(
                        "No hay aulas disponibles en los horarios seleccionados para algunos días.",
                        superposiciones
                    );
                    return StatusCode(409, conflictResponse); // Código 409: Conflicto
                }

                // Si no hay conflictos, guardar la reserva periódica
                _reservaService.guardarReservaPeriodica(reservaPeriodicaDTO);

                var successResponse = Response<List<DisponibilidadAulaDTO>>.SuccessResponse(
                    aulasConMayorCapacidad,
                    "Se guardó la reserva periódica con aulas disponibles."
                );
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = Response<string>.FailureResponse($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, errorResponse); // Código 500: Error interno del servidor
            }
        }

    }
}

