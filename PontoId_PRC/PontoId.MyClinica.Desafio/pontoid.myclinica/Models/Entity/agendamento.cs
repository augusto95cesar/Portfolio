using pontoid.myclinica.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace pontoid.myclinica.Models
{
    public class agendamento
    {
        public int Id { get; set; }  

        public status Status { get; set; } = status.AguardandoAtendimento;

        public int VagasAtendimentoId { get; set; }

        [ForeignKey("VagasAtendimentoId")]
        public virtual vagasAtendimento VagasAtendimento { get; set; }

        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public virtual paciente Paciente { get; set; }
    }
}