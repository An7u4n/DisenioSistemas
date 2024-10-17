using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Services.UserService;

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
            if (bedelDTO == null)
            {
                return BadRequest("El Bedel no puede ser nulo.");
            }

            var registradoBedel = _userService.RegistrarBedel(bedelDTO);
            return CreatedAtAction(nameof(RegistrarBedel), new { id = registradoBedel.IdBedel }, registradoBedel);
        }
    }
}
