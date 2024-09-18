using healthtracker.interfaces;

namespace healthtracker.Repositorios
{
    public interface IUsuarioRepositorio : IRepository<Usuario>
    {
        Task<Usuario> FindByCorreoElectronico(string correoElectronico);
    }
}
