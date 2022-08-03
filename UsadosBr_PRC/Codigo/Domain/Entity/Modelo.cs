using System.ComponentModel.DataAnnotations.Schema;

namespace VagaBackendTeste.Domain.Entity
{
    public class Modelo
    {
        public int Id { get; set; }
        public string NomeModelo { get; set; }
        public int CodigoMarca { get; set; }

        //[ForeignKey("CodigoMarca")]
        //public virtual Marca MarcaModelo { get; set; }
    }
}
