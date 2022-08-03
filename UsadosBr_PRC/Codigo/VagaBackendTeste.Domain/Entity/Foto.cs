using System.ComponentModel.DataAnnotations.Schema;

namespace VagaBackendTeste.Domain.Entity
{
    public class Foto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int CodigoCarro { get; set; }

        [ForeignKey("CodigoCarro")]
        public virtual Carro Carro { get; set; }
    }
}
