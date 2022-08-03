using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funcionarios_Ambev.Models
{
    [Table("dbo.Funcioanrio")]
    public class Funcionario
    {
        [Key,Column("FuncionarioId")]
        public int ID { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}