

using pontoid.myclinica.Models.Entity;
using System.Collections.Generic;

namespace pontoid.myclinica.Models.ViewModel
{
    public class AgendamentoConsulta
    {
        public paciente Paciente { get; set; }         

        public agendamento Agendamento { get; set; }

        public vagasAtendimento vagasData { get; set; }

        public ICollection<convenio> Convenios { get; set; }       

        public ICollection<clinica> Clinicas { get; set; }
    }
}