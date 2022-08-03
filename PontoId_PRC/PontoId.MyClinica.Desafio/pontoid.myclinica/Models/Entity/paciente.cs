using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pontoid.myclinica.Models
{
    public class paciente
    {
        
        public int Id { get; set; }

        public string NomePaciente { get; set; }

        public string Telefone { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public int?  ConvenioId { get; set; }

        public int? Matricula { get; set; }

        public virtual ICollection<agendamento> Agendamento { get; set; }
    }
}