using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoBemApi.Model
{
    public class Frequencia
    {
        public int Id { get; set; }
        public DateTime Chamada { get; set; }
        public bool Presente { get; set; }
        public int AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public virtual Aluno Aluno { get; set; }
    }
}
