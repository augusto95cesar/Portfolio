using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IterUpApi.Dto
{
    public class PessoaDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
       // [DisplayName("Nascimento")]
        public string DataNascimento { get; set; }
    }
}
