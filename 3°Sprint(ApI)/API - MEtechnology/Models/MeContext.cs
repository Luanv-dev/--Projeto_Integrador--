using Microsoft.EntityFrameworkCore;

namespace MEtechnology.Models
{
    public class MeContext : DbContext

    {
        public DbSet<ClasseProdutos>? ClasseProdutos { get; set; }
        public DbSet<Produtos>? Produtos { get; set; }
        public DbSet<Login>? Login { get; set; }


        
        protected override void OnConfiguring(DbContextOptionsBuilder Configurar)
        {
            //string credencial = @"Data Source=ME003394;Initial Catalog = MEtechnology;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //Configurar.UseSqlServer(credencial);
            Configurar.UseInMemoryDatabase("MEtechnology");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClasseProdutos>()
                .ToTable("classeprodutos")
                .HasKey(t => t.Id);

            modelBuilder.Entity<Produtos>()
                .ToTable("produtos")
                .HasKey(t => t.Id);

            modelBuilder.Entity<ClasseProdutos>()
                .HasMany(t => t.Produtos);

            modelBuilder.Entity<Login>()
                .HasKey(t => t.Id);
        }
    }
}
