using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Enums;
using Services.ReservaService;
using Web.API.Utilities;



namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private IReservaService _reservaService { get; set; }
        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpPost("guardar-reserva")]
        public Response<bool> GuardarReservaEsporadica([FromBody] ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            try
            {
                _reservaService.GuardarReservaEsporadica(reservaEsporadicaDTO);
                return Response<bool>.SuccessResponse(true, "Se guardo el aula");
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                return Response<bool>.FailureResponse("Error interno del servidor: " + ex.Message);
            }
        }

            // POST api/<ReservaController>
            [HttpPost("reserva-esporadica")]
            public Response<List<List<AulaDTO>>> PostReservaEsporadica([FromBody] ReservaEsporadicaDTO reservaEsporadicaDTO)
            {
                try
                {
                    Console.WriteLine(reservaEsporadicaDTO);
                    if (reservaEsporadicaDTO == null || reservaEsporadicaDTO.dias == null) {
                        HttpContext.Response.StatusCode = 400;
                        return Response<List<List<AulaDTO>>>.FailureResponse("La reseva no puede ser nula");
                    }

                    var reservaRegistrada = _reservaService.ObtenerAulasParaReserva(reservaEsporadicaDTO);
                    HttpContext.Response.StatusCode = 201;
                    return Response<List<List<AulaDTO>>>.SuccessResponse(reservaRegistrada, "Aulas encontradas.");
                }
                catch (ArgumentException ex) when (ex.Message == "Ya existen reservas en ese horario")
                {

                    HttpContext.Response.StatusCode = 409;  // Código 409 - Conflicto
                    return Response<List<List<AulaDTO>>>.FailureResponse("Ya existen reservas en ese horario");
                }
                catch (Exception ex)
                {
                    HttpContext.Response.StatusCode = 500;
                    return Response<List<List<AulaDTO>>>.FailureResponse("Error interno del servidor: " + ex.Message);
                }

            }

            [HttpPost("reserva-periodica")]
            public Response<ReservaPeriodicaDTO> PostReservaPeriodica([FromBody] ReservaPeriodicaDTO reservaPeriodicaDTO)
            {
                try
                {
                    if (reservaPeriodicaDTO == null)
                    {
                        HttpContext.Response.StatusCode = 400;
                        return Response<ReservaPeriodicaDTO>.FailureResponse("La reseva no puede ser nula");
                    }


                    if (!Enum.IsDefined(typeof(TipoPeriodo), reservaPeriodicaDTO.tipoPeriodo))
                    {
                        HttpContext.Response.StatusCode = 400;
                        return Response<ReservaPeriodicaDTO>.FailureResponse("El periodo especificado no es válido.");
                    }

                    var reservaRegistrada = _reservaService.GuardarReservaPeriodica(reservaPeriodicaDTO);

                    HttpContext.Response.StatusCode = 201;
                    return Response<ReservaPeriodicaDTO>.SuccessResponse(reservaRegistrada, "Reserva registrada con éxito.");

                }

                catch (ArgumentException ex) when (ex.Message == "Ya existen reservas en ese horario")
                {

                    HttpContext.Response.StatusCode = 409;  // Código 409 - Conflicto
                    return Response<ReservaPeriodicaDTO>.FailureResponse("Ya existen reservas en ese horario");
                }
                catch (Exception ex)
                {
                    HttpContext.Response.StatusCode = 500;
                    return Response<ReservaPeriodicaDTO>.FailureResponse("Error interno del servidor: " + ex.Message);
                }

            }
            /*
            [HttpPost("seleccionar-aulas")]
            public Response<ReservaDTO> SeleccionarAulas([FromBody] ReservaDTO reservaDTO,[FromBody] List<DiaDTO> diaDTOs)
            {
                try
                {
                    if (!diaDTOs.Any())
                    {
                        HttpContext.Response.StatusCode = 400;
                        return Response<ReservaDTO>.FailureResponse("Seleccione las aulas a reservar");
                    }

                    var reserva = _reservaService.reservarAulas(reservaDTO,diaDTOs);

                    HttpContext.Response.StatusCode = 201;
                    return Response<ReservaDTO>.SuccessResponse(reserva, "Reserva registrada con éxito");
                }
                catch (ArgumentException ex) when (ex.Message == "Ya existen reservas en ese horario")
                {

                    HttpContext.Response.StatusCode = 409;  // Código 409 - Conflicto
                    return Response<ReservaDTO>.FailureResponse("Ya existen reservas en ese horario");
                }
                catch (Exception ex)
                {
                    HttpContext.Response.StatusCode = 500;
                    return Response<ReservaDTO>.FailureResponse("Error interno del servidor: " + ex.Message);
                }
            }*/
        
    }
}
