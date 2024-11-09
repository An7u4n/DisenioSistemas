using Data.Utilities;
using DisenioSistemas.Model.Enums;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Services.UserService;
using Web.API.Utilities;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registrar-bedel")]
        public Response<BedelDTO> PostBedel([FromBody] BedelDTO bedelDTO)
        {
            System.Console.WriteLine(bedelDTO);
            try
            {
                if (bedelDTO == null)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<BedelDTO>.FailureResponse("El Bedel no puede ser nulo.");
                }

                if (string.IsNullOrEmpty(bedelDTO.Apellido) || string.IsNullOrEmpty(bedelDTO.Nombre))
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<BedelDTO>.FailureResponse("El nombre y apellido del Bedel son obligatorios.");
                }

                if (!Enum.IsDefined(typeof(Turno), bedelDTO.Turno))
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<BedelDTO>.FailureResponse("El turno especificado no es válido.");
                }

                var registradoBedel = _userService.registrarBedel(bedelDTO);

                HttpContext.Response.StatusCode = 201; 
                return Response<BedelDTO>.SuccessResponse(registradoBedel, "Bedel registrado con éxito.");
            }
            catch (ArgumentException ex) when (ex.Message == "El usuario ya existe")
            {
                
                HttpContext.Response.StatusCode = 409;  // Código 409 - Conflicto
                return Response<BedelDTO>.FailureResponse("El usuario ya existe.");
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                return Response<BedelDTO>.FailureResponse("Error interno del servidor: " + ex.Message);
            }
        }

        [HttpGet("buscar-bedeles")]
        public Response<List<BedelDTO>> GetBedeles([FromQuery] string apellido, [FromQuery] string turno)
        {
            try
            {
                Turno? turnoEnum = null;
                if (!string.IsNullOrEmpty(turno))
                {
                    if (!Enum.TryParse(turno, out Turno parsedTurno))
                    {
                        HttpContext.Response.StatusCode = 400;
                        return Response<List<BedelDTO>>.FailureResponse("El turno especificado no es válido.");
                    }
                    turnoEnum = parsedTurno;
                }

                var bedeles = _userService.buscarBedel(apellido, turnoEnum);

                return Response<List<BedelDTO>>.SuccessResponse(bedeles, "Bedeles encontrados con éxito.");
            }
            catch (NotFoundException)
            {
                HttpContext.Response.StatusCode = 404;
                return Response<List<BedelDTO>>.FailureResponse("No se encontraron bedeles con los datos proporcionados.");
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                return Response<List<BedelDTO>>.FailureResponse("Error interno del servidor: " + ex.Message);
            }
        }
        [HttpDelete("eliminar-bedel")]
        public Response<BedelDTO> DeleteBedel([FromQuery] string usuario)
        {
            try
            {
                if (usuario == null)
                {
                    HttpContext.Response.StatusCode = 400;
                    return Response<BedelDTO>.FailureResponse("El usuario no puede ser nulo.");
                }

                HttpContext.Response.StatusCode = 200;
                var bedel = _userService.eliminarBedelLogico(usuario);
                return Response<BedelDTO>.SuccessResponse(bedel, "Bedel eliminado con éxito.");
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                return Response<BedelDTO>.FailureResponse("Error interno del servidor: " + ex.Message);
            }
        }
    }
}
