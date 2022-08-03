using System.Collections;
using System.Collections.Generic;

namespace BrGaap.WebAPI.Model
{
    public class Cliente
    {
        public int Id { get; set; }        
        public string NomeCliente { get; set; }
        public string  Cnpj { get; set; }
        public int Cep { get; set; }        
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        
    } 
}