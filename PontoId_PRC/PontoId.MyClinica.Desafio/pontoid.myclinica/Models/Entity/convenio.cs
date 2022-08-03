using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace pontoid.myclinica.Models
{
    public class convenio
    {
        public int Id { get; set; }

        public string NomeConvenio { get; set; }
    }
}