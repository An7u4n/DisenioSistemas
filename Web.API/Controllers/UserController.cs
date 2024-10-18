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
        public IActionResult RegistrarBedel([FromBody] BedelDTO bedelDTO)
        {
            try
            {
                if (bedelDTO == null)
                {
                    return BadRequest(new Response<string>(false, "El Bedel no puede ser nulo.", null));
                }

                if (string.IsNullOrEmpty(bedelDTO.Apellido) || string.IsNullOrEmpty(bedelDTO.Nombre))
                {
                    return BadRequest(new Response<string>(false, "El nombre y apellido del Bedel son obligatorios.", null));
                }

                if (!Enum.IsDefined(typeof(Turno), bedelDTO.Turno))
                {
                    return BadRequest(new Response<string>(false, "El turno especificado no es válido.", null));
                }

                var registradoBedel = _userService.RegistrarBedel(bedelDTO);
                return CreatedAtAction(nameof(RegistrarBedel), new { id = registradoBedel.IdBedel }, new Response<BedelDTO>(true, "Bedel registrado con éxito.", registradoBedel));
            }
            catch (Exception)
            {
                return StatusCode(500, new Response<string>(false, "Error interno del servidor", null));
            }
        }
    }
}
