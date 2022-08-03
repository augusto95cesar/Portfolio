using Microsoft.EntityFrameworkCore;
using BrGaap.WebAPI.Model;

namespace BrGaap.WebAPI.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options): base(options){}
               public DbSet<Cliente> Clientes { get; set; } 
    }
}