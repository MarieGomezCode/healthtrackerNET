using healthtracker.Data;
using healthtracker.interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthtracker.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GuardarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> EncontrarPorCorreoElectronico(string correoElectronico)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.CorreoElectronico == correoElectronico);
        }

        public async Task<Usuario> EncontrarPorId(long id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}
