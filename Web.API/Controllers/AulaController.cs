using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Services.AulaService;
using Web.API.Utilities;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {

        private IAulaService _aulaService { get; set; }
        
        public AulaController(IAulaService aulaService)
        {
            _aulaService = aulaService;
        }

        [HttpGet("disponibilidad-aula/{periodo}")]
        public Response<HashSet<AulaDTO>> GetDisponibilidadAula(string periodo)
        {
            if (periodo == null)
            {
                return Response<HashSet<AulaDTO>>.FailureResponse("Periodo nulo");
            }

            try
            {
                _aulaService.GetDisponibilidadAula(periodo);
            }catch (Exception ex)
            {
                HttpContext.Response.StatusCode=500;
                return Response<HashSet<AulaDTO>>.FailureResponse("Error interno");

            }


            return null;
        }
    }
}
