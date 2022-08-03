using MaximaCRUD.Application.Interface;
using MaximaCRUD.Data;
using MaximaCRUD.Domain.Dtos;
using MaximaCRUD.Domain.Entity;
using MaximaCRUD.Repository;
using MaximaCRUD.Service;
using MaximaCRUD.Service.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaximaCRUD.Application.Implementacao
{
    public class AuthApplication : IAuthApplication
    {
        private readonly UserRepository _user;

        public AuthApplication(DataContext context)
        {
            this._user = new UserRepository(context);
        }
        public string AuthUsuario(LoginDto login)
        {
            User user = _user.GetUsuario(login.Login);
            if(user != null)
            {
                var hash = login.Senha.GerarHashSenha();
                if (user.PassWord == hash )
                {
                    return user.GenerateJWT();
                }
            }
            return null;
        }
    }
}
