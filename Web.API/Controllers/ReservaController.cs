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

        // GET: api/<ReservaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<ReservaController>
        [HttpPost("reserva-esporadica")]
        public Response<ReservaEsporadicaDTO> PostReservaEsporadica([FromBody] ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            try
            {
                if (reservaEsporadicaDTO == null) {
                    HttpContext.Response.StatusCode = 400;
                    return Response<ReservaEsporadicaDTO>.FailureResponse("La reseva no puede ser nula");
                }
                    
                
                if (!Enum.IsDefined(typeof(TipoPeriodo),reservaEsporadicaDTO.tipoPeriodo))
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<ReservaEsporadicaDTO>.FailureResponse("El periodo especificado no es válido.");
                }

                var reservaRegistrada = _reservaService.GuardarReservaEsporadica(reservaEsporadicaDTO);
                HttpContext.Response.StatusCode = 201;
                return Response<ReservaEsporadicaDTO>.SuccessResponse(reservaRegistrada, "Reserva registrada con éxito.");
            }
            catch (ArgumentException ex) when (ex.Message == "Ya existen reservas en ese horario")
            {

                HttpContext.Response.StatusCode = 409;  // Código 409 - Conflicto
                return Response<ReservaEsporadicaDTO>.FailureResponse("Ya existen reservas en ese horario");
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                return Response<ReservaEsporadicaDTO>.FailureResponse("Error interno del servidor: " + ex.Message);
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

        [HttpPost("seleccionar-aulas")]
        public Response<ReservaDTO> SeleccionarAulas([FromBody] List<AulaDTO> aulaDTOs)
        {
            try
            {
                if (!aulaDTOs.Any())
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<ReservaDTO>.FailureResponse("Seleccione las aulas a reservar");
                }

                var reserva = _reservaService.reservarAulas(aulaDTOs);

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
        }
    }
}
