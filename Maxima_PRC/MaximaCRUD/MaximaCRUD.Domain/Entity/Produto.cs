using MaximaCRUD.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MaximaCRUD.Domain.Entity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Status Status { get; set; }
        public int CodigoDepartamento { get; set; }

        [ForeignKey("CodigoDepartamento")]
        public virtual Departamento Departamento { get; set; }
    }
}
