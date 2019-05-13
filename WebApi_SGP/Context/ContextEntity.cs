using Microsoft.EntityFrameworkCore;
using WebApi_SGP.Maps;
using WebApi_SGP.Model;

namespace WebApi_SGP.Context
{
    public class ContextEntity : DbContext
    {
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<FolhaPonto> FolhaPonto { get; set; }
        public DbSet<Lancamento> Lancamento { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new FolhaPontoMap());
            modelBuilder.ApplyConfiguration(new LancamentoMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=juliano\julianno;Database=SGP21;Trusted_Connection=True;User ID=sa;Password=garciajtc241188;");
        }
    }
}
