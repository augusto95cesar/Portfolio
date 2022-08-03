using System;
using System.Collections.Generic;
using System.Text;

namespace VagaBackendTeste.Domain.Entity
{
    public class Marca
    {
        public int Id { get; set; }
        public string NomeMarca { get; set; }
        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
