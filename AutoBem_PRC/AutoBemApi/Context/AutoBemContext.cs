using AutoBemApi.Model;
using Microsoft.EntityFrameworkCore; 

namespace AutoBemApi.Context
{
    public class AutoBemContext : DbContext
    {
        public AutoBemContext(DbContextOptions<AutoBemContext> options) : base(options) { }

        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }

    }
}
