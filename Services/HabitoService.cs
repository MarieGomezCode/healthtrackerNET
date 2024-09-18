using healthtracker.Data;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using healthtracker.interfaces;

namespace healthtracker.Services
{
    public class HabitoService : IHabitoService
    {
        private readonly ApplicationDbContext _context;

        public HabitoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Habito> GuardarHabito(Habito habito, long usuarioId)
        {
            habito.UsuarioId = usuarioId;  // Asegúrate de asignar el usuarioId correctamente
            _context.Habitos.Add(habito);
            await _context.SaveChangesAsync();
            return habito;
        }

        public async Task<List<Habito>> EncontrarPorUsuarioId(long usuarioId)
        {
            return await _context.Habitos
                .Where(h => h.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
