using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VagaBackendTeste.Domain.Dtos
{
    public  class ListaCarroDto
    { 
        public string Placa { get; set; }
        public string NomeModelo { get; set; }

       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy}")]
        public string Ano { get; set; }
        public  List<string> PathFoto { get; set; }
        public  List<string> Acessorios { get; set; }
    }
}
