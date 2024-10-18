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

        [HttpPost]
        public Response<BedelDTO> RegistrarBedel([FromBody] BedelDTO bedelDTO)
        {
            try
            {
                if (bedelDTO == null)
                {
                    HttpContext.Response.StatusCode = 400; // Código de estado HTTP 400
                    return new Response<BedelDTO>(false, "El Bedel no puede ser nulo.", null);
                }

                if (string.IsNullOrEmpty(bedelDTO.Apellido) || string.IsNullOrEmpty(bedelDTO.Nombre))
                {
                    HttpContext.Response.StatusCode = 400; // Código de estado HTTP 400
                    return new Response<BedelDTO>(false, "El nombre y apellido del Bedel son obligatorios.", null);
                }

                if (!Enum.IsDefined(typeof(Turno), bedelDTO.Turno))
                {
                    HttpContext.Response.StatusCode = 400; // Código de estado HTTP 400
                    return new Response<BedelDTO>(false, "El turno especificado no es válido.", null);
                }

                var registradoBedel = _userService.RegistrarBedel(bedelDTO);

                HttpContext.Response.StatusCode = 201; // Código de estado HTTP 201
                return new Response<BedelDTO>(true, "Bedel registrado con éxito.", registradoBedel);
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = 500; // Código de estado HTTP 500
                return new Response<BedelDTO>(false, "Error interno del servidor", null);
            }
        }
    }
}
