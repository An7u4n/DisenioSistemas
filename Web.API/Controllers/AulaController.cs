using Microsoft.AspNetCore.Http;
using Data.Utilities;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Enums;
using Services.AulaService;
using Web.API.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;
using Model.Abstract;
using Model.Entity;

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
        [HttpPost]
        public IActionResult CrearAula([FromBody] AulaDTO aulaDto)
        {
            try
            {
                Aula aula;

                if (aulaDto is AulaInformaticaDTO aulaInformaticaDto)
                {
                    aula = new AulaInformatica(
                        aulaInformaticaDto.numero,
                        aulaInformaticaDto.piso,
                        aulaInformaticaDto.aireAcondicionado,
                        aulaInformaticaDto.estado,
                        aulaInformaticaDto.capacidad,
                        aulaInformaticaDto.tipoDePizarron,
                        aulaInformaticaDto.canion,
                        aulaInformaticaDto.cantidadComputadoras
                    );
                }
                else if (aulaDto is AulaMultimediosDTO aulaMultimediosDto)
                {
                    aula = new AulaMultimedios(
                        aulaMultimediosDto.numero,
                        aulaMultimediosDto.piso,
                        aulaMultimediosDto.aireAcondicionado,
                        aulaMultimediosDto.estado,
                        aulaMultimediosDto.capacidad,
                        aulaMultimediosDto.tipoDePizarron,
                        aulaMultimediosDto.televisor,
                        aulaMultimediosDto.poseeVentiladores,
                        aulaMultimediosDto.canion,
                        aulaMultimediosDto.cantidadComputadoras
                    );
                }
                else if (aulaDto is AulaSinRecursosAdicionalesDTO aulaSinRecursosDto)
                {
                    aula = new AulaSinRecursosAdicionales(
                        aulaSinRecursosDto.numero,
                        aulaSinRecursosDto.piso,
                        aulaSinRecursosDto.aireAcondicionado,
                        aulaSinRecursosDto.estado,
                        aulaSinRecursosDto.capacidad,
                        aulaSinRecursosDto.tipoDePizarron,
                        aulaSinRecursosDto.poseeVentiladores
                    );
                }
                else
                {
                    return BadRequest("Tipo de aula no soportado.");
                }

                // Llamar al DAO para guardar el aula
                _aulaService.CrearAula(aula);

                return CreatedAtAction(nameof(CrearAula), new { id = aula.getIdAula() }, aula);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el aula: {ex.Message}");
            }
        }

        [HttpPost("aulaInformatica")]
        public IActionResult crearAulaInformatica(AulaInformaticaDTO aulaInformaticaDto)
        {
            try
            {
                AulaInformatica aulaInformatica = new AulaInformatica(
                    aulaInformaticaDto.numero,
                    aulaInformaticaDto.piso,
                    aulaInformaticaDto.aireAcondicionado,
                    aulaInformaticaDto.estado,
                    aulaInformaticaDto.capacidad,
                    aulaInformaticaDto.tipoDePizarron,
                    aulaInformaticaDto.canion,
                    aulaInformaticaDto.cantidadComputadoras
                );

                _aulaService.CrearAula(aulaInformatica);

                return CreatedAtAction(nameof(crearAulaInformatica), new { id = aulaInformatica.getIdAula() }, aulaInformatica);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el aula: {ex.Message}");
            }    
        }
        
        
    }
}
