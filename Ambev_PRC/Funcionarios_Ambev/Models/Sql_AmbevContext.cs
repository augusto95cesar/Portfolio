using System.Data.Entity;

namespace Funcionarios_Ambev.Models
{
    public class Sql_AmbevContext : DbContext
    {
        public Sql_AmbevContext() : base("name=AmbevContext")
        {
        }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
