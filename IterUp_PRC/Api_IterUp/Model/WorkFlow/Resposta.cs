using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IterUpApi.Model.WorkFlow
{
    public class Resposta
    {
        public int Id { get; set; }
        public int CodEtapa { get; set; }
        public int NumResposta { get; set; }
        public string Legenda { get; set; }
        public int CodProxEtapa { get; set; }
    }
}
