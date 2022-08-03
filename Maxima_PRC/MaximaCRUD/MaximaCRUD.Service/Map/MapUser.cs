using MaximaCRUD.Domain.Dtos;
using MaximaCRUD.Domain.Entity;
using System;
using System.Collections.Generic; 

namespace MaximaCRUD.Service.Map
{
    public static class MapUser
    {
        public static List<UserDto> MapearUsers(this List<User> list)
        {
            List<UserDto> dto = new List<UserDto>();
            foreach (var usuario in list)
            {
                UserDto user = new UserDto
                {
                    Login = usuario.Login,
                    CodigoUsuario = usuario.Id.ToString()
                };
                dto.Add(user);
            }
            return dto;
        }
        public static List<User> MapearUsersDtos(this List<UserDto> list)
        {
            List<User> user = new List<User>();
            foreach (var usuario in list)
            {
                User us = new User
                {
                    Login = usuario.Login
                };
                user.Add(us);
            }
            return user;
        }
        public static User MapearCreateUserDto(this CreateUserDto user)
        {
            User us = new User
            {
                Login = user.Login,
                PassWord = user.Senha.GerarHashSenha()
            };
            return us;
        }
        public static UserDto MapearUser(this User user)
        {
            UserDto us = new UserDto
            {
                Login = user.Login,
                CodigoUsuario = user.Id.ToString()
            };
            return us;
        }
        public static User MapearUser(this UpUserDto user)
        {
            User us = new User
            {
                Login = user.Login,
                Id = Convert.ToInt32(user.CodigoUsuario),
                PassWord = user.Senha.GerarHashSenha()

            };
            return us;
        }

        public static User MapearLogin(this LoginDto user)
        {
            User us = new User
            {
                Login = user.Login
            };
            return us;
        }
    }
}
