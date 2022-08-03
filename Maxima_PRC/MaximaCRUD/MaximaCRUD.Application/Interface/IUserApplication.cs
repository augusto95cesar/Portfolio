using MaximaCRUD.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaximaCRUD.Application.Interface
{
    public interface IUserApplication
    {
        public List<UserDto> GetUsuarios(int pgAtual, int qtdItem);
        public UserDto GetUsuario(string login);
        public UserDto CreateUsuario(CreateUserDto user);
        public bool UpdateUsuario(UpUserDto user);
        public bool DeleteUsuario(int id);
    }
}
