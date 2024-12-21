using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Enums;
using Model.Exceptions;
using Services.AulaService;
using Services.ReservaService.Interfaces;
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


        [HttpPost("retornar-aulas-esporadica")]
        public IActionResult RetornarReservaEsporadica([FromBody] ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            try
            {
                var aulasConMayorCapacidad = _reservaService.validarReservaEsporadica(reservaEsporadicaDTO);
                
                
                var successResponse = Response<List<DisponibilidadAulaDTO>>.SuccessResponse(
                    aulasConMayorCapacidad,
                    "Se encontraron aulas para la reserva"
                );
                return Ok(successResponse);
            }
            catch (SuperposicionDeAulasException ex)
            {
                var response = Response<List<List<SuperposicionInfoDTO>>>.FailureResponse(
                "No hay aulas disponibles en los horarios seleccionados", ex.superposiciones);
                return StatusCode(409, response); // Código 409: Conflicto
            }
            catch (Exception ex)
            {
                var errorResponse = Response<string>.FailureResponse($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, errorResponse); // Código 500: Error interno del servidor
            }
        }

        [HttpPost("guardar-reserva-esporadica")]
        public IActionResult GuardarReservaEsporadica([FromBody] ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            try
            {

                _reservaService.ConfirmarDisponibilidadAulaParaReservaEsporadica(reservaEsporadicaDTO);


                // Si no hay conflictos, guardar la reserva periódica
                _reservaService.guardarReservaEsporadica(reservaEsporadicaDTO);

                var successResponse = Response<List<DisponibilidadAulaDTO>>.SuccessResponse(null,
                    "Se guardo la reserva correctamente"
                );
                return Ok(successResponse);
            }
            catch (SuperposicionDeAulasException ex)
            {
                var response = Response<bool>.FailureResponse(
                "Ya se ha registrado una reserva para alguna de las aulas en alguna fecha indica.", false);
                return StatusCode(409, response); // Código 409: Conflicto
            }
            catch (Exception ex)
            {
                var errorResponse = Response<string>.FailureResponse($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, errorResponse); // Código 500: Error interno del servidor
            }
        }

        [HttpPost("retornar-aulas-periodica")]
        public IActionResult RetornarAulasReservaPeriodica([FromBody] ReservaPeriodicaDTO reservaPeriodicaDTO)
        {
            try
            {
                // Validar la reserva periódica
                var aulasConMayorCapacidad = _reservaService.validarReservaPeriodica(reservaPeriodicaDTO);

                var successResponse = Response<List<DisponibilidadAulaDTO>>.SuccessResponse(
                    aulasConMayorCapacidad,
                    "Se encontraron aulas disponibles."
                ); 
                return Ok(successResponse);
            }
            catch (SuperposicionDeAulasException ex)
            {
                var response = Response<List<List<SuperposicionInfoDTO>>>.FailureResponse(
                    "No hay aulas disponibles en los horarios seleccionados", ex.superposiciones);
                return StatusCode(409, response); // Código 409: Conflicto
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
                _reservaService.ConfirmarDisponibilidadAulaParaReservaPeriodica(reservaPeriodicaDTO);

                // Si no hay conflictos, guardar la reserva periódica
                _reservaService.guardarReservaPeriodica(reservaPeriodicaDTO);

                //TODO: devolver lo que haga falta
                var successResponse = Response<List<DisponibilidadAulaDTO>>.SuccessResponse(null,
                    "Se guardó la reserva periódica con aulas disponibles."
                );
                return Ok(successResponse);
            }
            catch (SuperposicionDeAulasException ex)
            {
                var response = Response<bool>.FailureResponse(
                "Ya se ha registrado una reserva para alguna de las aulas en algun dia indicado.", false);
                return StatusCode(409, response); // Código 409: Conflicto
            }
            catch (Exception ex)
            {
                var errorResponse = Response<string>.FailureResponse($"Error interno del servidor: {ex.Message}");
                return StatusCode(500, errorResponse); // Código 500: Error interno del servidor
            }
        }

    }
}

