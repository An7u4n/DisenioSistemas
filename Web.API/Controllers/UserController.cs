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

        [HttpPost("RegistrarBedel")]
        public Response<BedelDTO> RegistrarBedel([FromBody] BedelDTO bedelDTO)
        {
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
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
                return Response<BedelDTO>.FailureResponse("Error interno del servidor");
            }
        }

        [HttpGet("{id}")]
        public Response<BedelDTO> ObtenerBedelPorId(int id)
        {
            try
            {
                var bedel = _userService.buscarBedel(id);

                return Response<BedelDTO>.SuccessResponse(bedel, "Bedel encontrado con éxito.");
            }
            catch (KeyNotFoundException ex)
            {
                HttpContext.Response.StatusCode = 404;
                return Response<BedelDTO>.FailureResponse(ex.Message); 
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500;
                return Response<BedelDTO>.FailureResponse("Error interno del servidor");
            }
        }
    }
}
