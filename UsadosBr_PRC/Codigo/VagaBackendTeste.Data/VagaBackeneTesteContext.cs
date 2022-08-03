using Microsoft.EntityFrameworkCore; 
using VagaBackendTeste.Domain.Entity;

namespace VagaBackendTeste.Data
{
    public class VagaBackeneTesteContext : DbContext
    {
        public VagaBackeneTesteContext(DbContextOptions<VagaBackeneTesteContext> options) : base(options) { }
        public DbSet<Acessorio> Acessorios { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<CarroAcessorio> CarroAcessorios { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<AnoLancamento> AnoLancamentos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
    }
}
