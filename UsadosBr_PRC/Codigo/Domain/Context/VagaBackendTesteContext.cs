
using Microsoft.EntityFrameworkCore;
using VagaBackendTeste.Domain.Entity;

namespace VagaBackendTeste.Domain.Context
{
    public class VagaBackendTesteContext : DbContext
    {
        public VagaBackendTesteContext(DbContextOptions<VagaBackendTesteContext> options) : base(options) { }
        public DbSet<Acessorio> Acessorios { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<CarroAcessorio> CarroAcessorios { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

    }
}
