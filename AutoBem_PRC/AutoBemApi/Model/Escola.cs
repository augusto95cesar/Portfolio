using System.Collections.Generic;

namespace AutoBemApi.Model
{
    public class Escola
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Turma> Turma { get; set; }

    }
}
