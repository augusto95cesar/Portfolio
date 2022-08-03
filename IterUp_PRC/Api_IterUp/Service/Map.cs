using IterUpApi.Dto;
using IterUpApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IterUpApi.Service
{
    public class Map
    { 
        public Usuario Usuario(UsuarioDto user)
        {
            Usuario us = new Usuario
            {
                Login = user.Login,
                Password = user.Senha
            };
            return us;
        }

        public Pessoa Pessoa(PessoaDto pessoa)
        {
            DateTime nacimento = Convert.ToDateTime(pessoa.DataNascimento);
            Pessoa pess = new Pessoa
            {
                Nome = pessoa.Nome,
                Nacimento = nacimento,
                CPF = pessoa.CPF,
                UF = pessoa.UF.ToUpper()
            };
            return pess;
        }
    }
}
