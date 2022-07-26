using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace MEtechnology.Models
{
    public class MeContext : DbContext
    {
        public MeContext(DbContextOptions<MeContext> options) : base(options) { }
        public DbSet<Classe_Produtos> Classe_Produtos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Login> Login { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classe_Produtos>()
                .ToTable("classe_produtos")
                .HasKey(t => t.Classe);
            
            modelBuilder.Entity<Produtos>()
                .ToTable("produtos")
                .HasKey(t => t.id);

            modelBuilder.Entity<Classe_Produtos>()
                .HasMany(t => t.Produtos);

            modelBuilder.Entity<Login>()
                .HasKey(t => t.id);
        }

    }
}
