using MaximaCRUD.Application.Interface;
using MaximaCRUD.Data;
using MaximaCRUD.Domain.Dtos;
using MaximaCRUD.Repository;
using MaximaCRUD.Service.Map;
using System;
using System.Collections.Generic;

namespace MaximaCRUD.Application.Implementacao
{
    public class UserApplication : IUserApplication
    {
        private readonly UserRepository _user;

        public UserApplication(DataContext context)
        {
            this._user = new UserRepository(context);
        }
        public UserDto CreateUsuario(CreateUserDto user)
        {
            if(_user.GetUsuario(user.Login) != null)
            {
                //Servico de Mensageria.

                return null;
            }
            return _user.CreateUsuario(user.MapearCreateUserDto()).MapearUser();
        }

        public bool DeleteUsuario(int id)
        {
            return _user.DeleteUsuario(id);
        }

        public UserDto GetUsuario(string login)
        {
            return _user.GetUsuario(login).MapearUser();
        }

        public List<UserDto> GetUsuarios(int pgAtual, int qtdItem)
        {
            return _user.GetUsuarios(pgAtual, qtdItem).MapearUsers();
        }

        public bool UpdateUsuario(UpUserDto user)
        {
            return _user.UpdateUsuario(user.MapearUser());
        }
    }
}
