using System; 
namespace PontoIdWeb.ModelView
{
    public class AlunoView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Cpf { get; set; }
        public int CodTurma { get; set; }
    }
}
