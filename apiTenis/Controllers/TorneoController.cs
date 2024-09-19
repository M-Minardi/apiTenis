
using apiTenis.Interfaces;
using apiTenis.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiTenis.Controllers
{
    /// <summary>
    /// Controlador para gestionar los torneos de tenis.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TorneoController : ControllerBase
    {
        private readonly ITorneoBusiness _torneoBusiness;
        public TorneoController(ITorneoBusiness torneoBusiness) {
            _torneoBusiness = torneoBusiness;   
        }

        /// <summary>
        /// Obtiene la lista de todos los torneos disponibles.
        /// </summary>
        /// <returns>Una lista de torneos.</returns>
        [HttpGet]
        public async Task<ActionResult<List<TorneoDTO>>> Get()
        {            
            var result = await _torneoBusiness.Get();
            if (result == null) return NotFound();
            return Ok(result);
        }
        /// <summary>
        /// Obtiene una lista de torneos filtrados por los criterios especificados.
        /// </summary>
        /// <param name="dto">El filtro que se aplicará para obtener los torneos.</param>
        /// <returns>Una lista de torneos filtrados.</returns>
        [HttpGet("filtro", Name = "getTorneoFiltro")]
        public async Task<ActionResult<List<TorneoDTO>>> GetFiltro([FromQuery] TorneoFiltroDTO dto)
        {
            var result = await _torneoBusiness.GetFiltro(dto);
            if (result == null) return NotFound();
            return Ok(result);
        }
        /// <summary>
        /// Crea un nuevo torneo con simulación de partidos.
        /// </summary>
        /// <param name="dto">Los datos necesarios para crear un torneo.</param>
        /// <returns>El resultado de la creación del torneo.</returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TorneoCrearDTO dto)
        {
            if (dto == null) return BadRequest();
            var result = await _torneoBusiness.CrearTorneoConSimulacion(dto);
            return Ok(result);
        }
    }
}
