using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IterUpApi.Model.WorkFlow
{
    [Table("Etapa")]
    public class MensagemOuPergunta
    {
        public int Id{ get; set; } 
        public TipoEtapa TipoEtapa { get; set; }
        public int? NumProxEtapa { get; set; }
        public string TextoEtapa { get; set; } 
    }
}
