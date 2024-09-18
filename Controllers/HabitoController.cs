using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using healthtracker.interfaces;
using healthtracker.Services.Interfaces;
using healthtracker.DTOs;
using System.Linq;
using healthtracker.Services;
namespace healthtracker.Controllers
{

   

    [Route("api/habitos")]
    [ApiController]
    public class HabitoController : ControllerBase
    {
        private readonly IHabitoService _habitoService;

        public HabitoController(IHabitoService habitoService)
        {
            _habitoService = habitoService;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearHabito([FromBody] HabitoDTO habitoDTO)
        {
            try
            {
                var habito = new Habito
                {
                    Nombre = habitoDTO.Nombre,
                    Descripcion = habitoDTO.Descripcion,
                    CreadoEn = habitoDTO.CreadoEn
                };

                var habitoGuardado = await _habitoService.GuardarHabito(habito, habitoDTO.UsuarioId);
                return Ok(habitoGuardado);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> ObtenerHabitosPorUsuarioId(long usuarioId)
        {
            var habitos = await _habitoService.EncontrarPorUsuarioId(usuarioId);
            return Ok(habitos);
        }
    }

}
