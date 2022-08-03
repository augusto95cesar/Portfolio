using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pontoid.myclinica.Models.Entity
{
    public class vagasAtendimento
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataConsulta { get; set; }       

        [DataType(DataType.Time)]
        public DateTime Horas { get; set; }

        public bool DateTimeDisponivel { get; set; }        

        public int ClinicaId { get; set; }        

        [ForeignKey("ClinicaId")]
        public virtual clinica clinica { get; set; }

        public virtual ICollection<agendamento> Agendamento { get; set; }        
    }
}