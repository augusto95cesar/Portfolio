using System;

namespace IterUpApi.Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }
        public DateTime Nacimento { get; set; }
    }
}