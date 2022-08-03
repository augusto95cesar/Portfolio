using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoIdApi.Model
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Cpf { get; set; }
        public int CodTurma { get; set; }
    }
}
