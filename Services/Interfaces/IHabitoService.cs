using healthtracker.interfaces;

namespace healthtracker.Services.Interfaces
{
    public interface IHabitoService
    {
        Task<Habito> GuardarHabito(Habito habito, long usuarioId);
        Task<List<Habito>> EncontrarPorUsuarioId(long usuarioId);
    }
}
