using IterUpApi.Model.WorkFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IterUpApi.Dto
{
    public class Chat
    {
        public MensagemOuPergunta Etapas { get; set; }
        public Resposta OpcaoResposta { get; set; } 
        public string Resosta { get; set; } 
    }
}
