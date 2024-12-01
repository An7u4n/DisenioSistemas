using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Services.ReservaService;
using Web.API.Utilities;



namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        IReservaService reservaService { get; set; }
        public ReservaController(IReservaService reservaService)
        {
            this.reservaService = reservaService;
        }

        // GET: api/<ReservaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReservaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReservaController>
        [HttpPost("reserva-esporadica")]
        public Response<ReservaEsporadicaDTO> Post([FromBody] ReservaEsporadicaDTO reservaEsporadicaDTO)
        {
            try
            {

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // PUT api/<ReservaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
