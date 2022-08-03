using MaximaCRUD.Domain.Entity;
using MaximaCRUD.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaximaCRUD.Domain.Dtos
{
   public class CreateProdutoDto
    { 
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Status Status { get; set; }
        public int CodigoDepartamento { get; set; } 
    }
}
