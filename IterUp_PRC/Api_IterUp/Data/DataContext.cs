using IterUpApi.Model;
using IterUpApi.Model.WorkFlow;
using Microsoft.EntityFrameworkCore;

namespace IterUpApi.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { } 

        public DbSet<Pessoa> Pessoas { get; set; }        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<WorkFlow> WorkFlow { get; set; }
        public DbSet<MensagemOuPergunta> MensagemOuPergunta { get; set; }
        public DbSet<Resposta> Resposta { get; set; }
    }
}