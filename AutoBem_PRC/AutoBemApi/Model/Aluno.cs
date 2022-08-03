using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoBemApi.Model
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Frequencia> Frequecia { get; set; }
        public int TurmaId { get; set; }

        [ForeignKey("TurmaId")]
        public virtual Turma Turma { get; set; }
    }
}
