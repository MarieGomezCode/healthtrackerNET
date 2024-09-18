using healthtracker.interfaces;

namespace healthtracker.Repositorios
{
    public interface IHabitoRepositorio : IRepository<Habito>
    {
        Task<List<Habito>> FindByUsuarioId(long usuarioId);
    }
}
