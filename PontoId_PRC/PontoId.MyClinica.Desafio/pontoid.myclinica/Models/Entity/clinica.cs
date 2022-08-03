using pontoid.myclinica.Models.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pontoid.myclinica.Models
{
    public class clinica
    {
        
        public int Id { get; set; }

        public string NomeClinica { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public virtual ICollection<vagasAtendimento> VagasAtendimentos { get; set; }
    }
}