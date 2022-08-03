using MaximaCRUD.Domain.Entity;
using Microsoft.EntityFrameworkCore; 

namespace MaximaCRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Departamento> Departamentos {get; set;}
        public DbSet<User> Users {get; set;}
    }
}
