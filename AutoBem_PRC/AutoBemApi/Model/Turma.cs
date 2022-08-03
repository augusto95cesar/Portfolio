using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoBemApi.Model
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Aluno> Aluno { get; set; }
        public int EscolaId { get; set; }

        [ForeignKey("EscolaId")]
        public virtual Escola Escola { get; set; }
    }
}
