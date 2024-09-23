using Data.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private AnioLectivoDAO _anioDao;
        public TestController(AnioLectivoDAO anioLectivoDao)
        {
            _anioDao = anioLectivoDao;
        }

        [HttpGet]
        public IActionResult GuardarYDevolverAnio(string anio)
        {
            _anioDao.GuardarAnioLectivo(anio);
            var anioGuardado = _anioDao.GetAnioLectivo(anio);
            return Ok(new AnioLectivoDTO(anioGuardado.GetAnio(), anioGuardado.GetIdAnioLectivo()));
        }
    }
}
