using healthtracker.interfaces;

namespace healthtracker.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> GuardarUsuario(Usuario usuario);
        Task<Usuario> EncontrarPorCorreoElectronico(string correoElectronico);
        Task<Usuario> EncontrarPorId(long id);
    }
}
