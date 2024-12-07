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
        
        public AulaController(IAulaService aulaService)
        {
            _aulaService = aulaService;
        }

        
    }
}
