using Data.Utilities;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Services.AuthService;
using Web.API.Utilities;



namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {

            if (loginDTO == null)
            {
                var response = Response<LoginDTO>.FailureResponse("Datos Nulos", loginDTO);
                return StatusCode(400, response);
            }

            if (loginDTO.name == null || loginDTO.password == null)
            { 
                    var response = Response<LoginDTO>.FailureResponse("Datos Nulos", loginDTO);
                return StatusCode(400, response);
            }

            try
            {
                var login = _authService.login(loginDTO);
                var response = Response<LoginDTO>.SuccessResponse(login, "Usuario autenticado con éxito");
                return StatusCode(200, response);
            }catch (NotFoundException ex)
            {
                var response = Response<LoginDTO>.FailureResponse(ex.Message, loginDTO);
                return StatusCode(404, response);
            }catch(UnauthorizedAccessException ex)
            {
                var response = Response<LoginDTO>.FailureResponse(ex.Message, loginDTO);
                return StatusCode(401, response);
            }catch(Exception ex)
            {
                var response = Response<LoginDTO>.FailureResponse(ex.Message, loginDTO);
                return StatusCode(500, response);
            }

        }

       
    }
}
