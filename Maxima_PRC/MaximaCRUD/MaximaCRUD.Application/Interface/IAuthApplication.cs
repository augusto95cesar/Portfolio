using MaximaCRUD.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaximaCRUD.Application.Interface
{
    public interface  IAuthApplication
    {
        public string AuthUsuario(LoginDto user);
    }
}
