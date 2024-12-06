using Microsoft.AspNetCore.Http;
using Data.Utilities;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Enums;
using Services.AulaService;
using Web.API.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly IAulaService _aulaService;

        private IAulaService _aulaService { get; set; }
        
        public AulaController(IAulaService aulaService)
        {
            _aulaService = aulaService;
        }

        [HttpPut("modificar-aula-informatica")]
        public Response<AulaInformaticaDTO> ModificarAulaInformatica([FromBody] AulaInformaticaDTO aulaDTO)
        {
            try
            {
                if (aulaDTO == null)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaInformaticaDTO>.FailureResponse("El AulaInformatica no puede ser nula.");
                }

                if (aulaDTO.numero <= 0)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaInformaticaDTO>.FailureResponse("El número del aula debe ser positivo.");
                }

                if (aulaDTO.piso <= 0)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaInformaticaDTO>.FailureResponse("El piso del aula debe ser positivo.");
                }

                if (aulaDTO.capacidad <= 0)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaInformaticaDTO>.FailureResponse("La capacidad del aula debe ser mayor que 0.");
                }

                var aulaActualizada = _aulaService.actualizarAulaInformatica(aulaDTO);

                HttpContext.Response.StatusCode = 200;
                return Response<AulaInformaticaDTO>.SuccessResponse(aulaActualizada, "AulaInformatica modificada con éxito.");
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                return Response<AulaInformaticaDTO>.FailureResponse("Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut("modificar-aula-multimedios")]
        public Response<AulaMultimediosDTO> ModificarAulaMultimedios([FromBody] AulaMultimediosDTO aulaDTO)
        {
            try
            {
                if (aulaDTO == null)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaMultimediosDTO>.FailureResponse("El AulaMultimedios no puede ser nula.");
                }

        [HttpGet("disponibilidad-aula")]
        public Response<HashSet<AulaDTO>> GetDisponibilidadAula([FromBody] ReservaDTO reservaDto)
                if (aulaDTO.numero <= 0)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaMultimediosDTO>.FailureResponse("El número del aula debe ser positivo.");
                }

                if (aulaDTO.piso <= 0)
        {
            if (reservaDto == null)
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaMultimediosDTO>.FailureResponse("El piso del aula debe ser positivo.");
                }

                if (aulaDTO.capacidad <= 0)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaMultimediosDTO>.FailureResponse("La capacidad del aula debe ser mayor que 0.");
                }

                var aulaActualizada = _aulaService.actualizarAulaMultimedios(aulaDTO);

                HttpContext.Response.StatusCode = 200;
                return Response<AulaMultimediosDTO>.SuccessResponse(aulaActualizada, "AulaMultimedios modificada con éxito.");
            }
            catch (Exception ex)
            {
                return Response<HashSet<AulaDTO>>.FailureResponse("Reserva nula");
                HttpContext.Response.StatusCode = 500;
                return Response<AulaMultimediosDTO>.FailureResponse("Error interno del servidor: " + ex.Message);
            }
            }

        [HttpPut("modificar-aula-sin-recursos-adicionales")]
        public Response<AulaSinRecursosAdicionalesDTO> ModificarAulaSinRecursosAdicionales([FromBody] AulaSinRecursosAdicionalesDTO aulaDTO)
        {
            try
            {
                _aulaService.GetDisponibilidadAula(reservaDto);
            }catch (Exception ex)
                if (aulaDTO == null)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaSinRecursosAdicionalesDTO>.FailureResponse("El AulaSinRecursosAdicionales no puede ser nula.");
                }

                if (aulaDTO.numero <= 0)
            {
                HttpContext.Response.StatusCode=500;
                return Response<HashSet<AulaDTO>>.FailureResponse("Error interno");
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaSinRecursosAdicionalesDTO>.FailureResponse("El número del aula debe ser positivo.");
                }

                if (aulaDTO.piso <= 0)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaSinRecursosAdicionalesDTO>.FailureResponse("El piso del aula debe ser positivo.");
                }

                if (aulaDTO.capacidad <= 0)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<AulaSinRecursosAdicionalesDTO>.FailureResponse("La capacidad del aula debe ser mayor que 0.");
            }

                var aulaActualizada = _aulaService.actualizarAulaSinRecursosAdicionales(aulaDTO);

            return null;
                HttpContext.Response.StatusCode = 200;
                return Response<AulaSinRecursosAdicionalesDTO>.SuccessResponse(aulaActualizada, "AulaSinRecursosAdicionales modificada con éxito.");
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                return Response<AulaSinRecursosAdicionalesDTO>.FailureResponse("Error interno del servidor: " + ex.Message);
            }
        }
    }
}
