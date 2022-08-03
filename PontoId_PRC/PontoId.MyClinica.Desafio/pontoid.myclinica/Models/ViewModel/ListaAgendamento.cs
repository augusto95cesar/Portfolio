using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pontoid.myclinica.Models.ViewModel
{
    public class ListaAgendamento
    {
        public int Id { get; set; }
        public string nomeCovenio { get; set; }
        public int? convenioId { get; set; }
        public status status { get; set; }
        public string nomePaciente { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string telefone  { get; set; }
        public string clinica      { get; set; }
        public int? matricula { get; set; }
        //[DataType(DataType.Date)]
        public string dataMarcada { get; set; }
        //[DataType(DataType.Time)]
        public string horaMarcada { get; set; }       
    }
}