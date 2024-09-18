using healthtracker.interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthtracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Habito> Habitos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales
            base.OnModelCreating(modelBuilder);
        }
    }
}
