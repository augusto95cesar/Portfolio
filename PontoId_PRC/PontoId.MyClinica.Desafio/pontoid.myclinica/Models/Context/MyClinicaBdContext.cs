using pontoid.myclinica.Models.Entity;
using System.Data.Entity;

namespace pontoid.myclinica.Models
{
    public class MyClinicaBdContext : DbContext
    {       
    
        public MyClinicaBdContext() : base("name=ClinicaBdContext")
        {
        }

        public DbSet<agendamento> agendamentos { get; set; }

        public DbSet<clinica> clinicas { get; set; }

        public DbSet<convenio> convenios { get; set; }

        public DbSet<paciente> pacientes { get; set; }

        public DbSet<vagasAtendimento> VagasAtendimento { get; set; }
    }
}
