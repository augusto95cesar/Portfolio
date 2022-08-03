using MaximaCRUD.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaximaCRUD.Domain.Dtos
{
   public class ProdutoDto
    {
        public string CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Status Status { get; set; }
        public string CodigoDepartamento { get; set; }        
        public string Departamento { get; set; }
    }
}
