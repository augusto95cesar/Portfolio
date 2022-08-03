using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; 

namespace VagaBackendTeste.Domain.Entity
{
    public class Carro
    {
        public int Id { get; set; }
        public string NomeCarro { get; set; }
        public int CodigoModelo { get; set; }
        
        //[ForeignKey("CodigoModelo")]
        //public virtual Modelo ModeloCarro { get; set; }
        
        //public int CodigoMarca { get; set; }        
        //[ForeignKey("CodigoMarca")]
        //public virtual Marca MarcaCarro { get; set; }
        public DateTime Ano { get; set; }

        // public virtual ICollection<Acessorio> Acessorios { get; set; }
        //public virtual ICollection<Foto> Fotos { get; set; }
    }
}
