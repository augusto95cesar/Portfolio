using Microsoft.EntityFrameworkCore;
using PontoIdApi.Model;

namespace PontoIdApi.Context
{
    public class PontoIdContext : DbContext
    {
        public PontoIdContext(DbContextOptions<PontoIdContext> options) : base(options) { } 
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
    } 
}
