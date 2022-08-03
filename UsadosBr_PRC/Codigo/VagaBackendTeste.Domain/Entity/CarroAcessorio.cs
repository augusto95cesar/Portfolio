using System.ComponentModel.DataAnnotations.Schema;

namespace VagaBackendTeste.Domain.Entity
{
    public class CarroAcessorio
    {
        public int Id { get; set; }
        public int CodigoAcessorio { get; set; }

        [ForeignKey("CodigoAcessorio")]
        public virtual Acessorio Acessorio { get; set; }

        public int CodigoCarro { get; set; }
        
        [ForeignKey("CodigoCarro")]
        public virtual Carro Carro { get; set; }
    }
}
