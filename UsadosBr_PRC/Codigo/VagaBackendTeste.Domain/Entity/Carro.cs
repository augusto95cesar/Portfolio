using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; 

namespace VagaBackendTeste.Domain.Entity
{
    public class Carro
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int CodigoModelo { get; set; }
        
        [ForeignKey("CodigoModelo")]
        public virtual Modelo Modelo { get; set; }

        public int CodigoAno { get; set; }
        [ForeignKey("CodigoAno")]
        public virtual AnoLancamento AnoLancamento { get; set; } 

        // public virtual ICollection<Acessorio> Acessorios { get; set; }
        public virtual ICollection<Foto> Fotos { get; set; }
    }
}
