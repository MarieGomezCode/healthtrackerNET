using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using healthtracker.Services.Interfaces;
using healthtracker.Services;
using healthtracker.DTOs;

using System.Linq;

namespace healthtracker.Controllers
{
    

    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioRegistroDTO usuarioDTO)
        {
            var usuarioExistente = await _usuarioService.EncontrarPorCorreoElectronico(usuarioDTO.CorreoElectronico);

            if (usuarioExistente != null)
            {
                return BadRequest(new { mensaje = "Correo ya registrado" });
            }

            var usuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                CorreoElectronico = usuarioDTO.CorreoElectronico,
                Contrasena = usuarioDTO.Contrasena
            };

            var usuarioGuardado = await _usuarioService.GuardarUsuario(usuario);
            return Ok(new { mensaje = "Usuario registrado exitosamente", id = usuarioGuardado.Id });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO loginDTO)
        {
            var usuario = await _usuarioService.EncontrarPorCorreoElectronico(loginDTO.CorreoElectronico);

            if (usuario != null && usuario.Contrasena == loginDTO.Contrasena)
            {
                return Ok(new { mensaje = "Login exitoso" });
            }

            return Unauthorized(new { mensaje = "Credenciales inválidas" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(long id)
        {
            var usuario = await _usuarioService.EncontrarPorId(id);

            if (usuario != null)
            {
                return Ok(usuario);
            }

            return NotFound();
        }
    }

}
