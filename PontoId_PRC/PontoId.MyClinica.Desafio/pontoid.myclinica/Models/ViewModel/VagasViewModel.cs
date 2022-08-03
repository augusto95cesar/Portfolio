using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pontoid.myclinica.Models.ViewModel
{
    public class VagasViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataConsulta { get; set; }

        [DataType(DataType.Time)]
        public DateTime Horas { get; set; }
        
        public string DataString { get; set; }
         
        public string HoraString { get; set; }

        public bool DateTimeDisponivel { get; set; }

        public int ClinicaId { get; set; }
        
        public string NomeClinica { get; set; }
    }
}