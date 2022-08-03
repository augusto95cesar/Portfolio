using System;
using System.Collections.Generic;
using System.Text;

namespace MaximaCRUD.Domain.Dtos
{
    public class CreateUserDto
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
