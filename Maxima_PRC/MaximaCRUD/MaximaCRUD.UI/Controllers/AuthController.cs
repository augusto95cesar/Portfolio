using MaximaCRUD.Application.Interface;
using MaximaCRUD.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace MaximaCRUD.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApplication _user;

        public AuthController(IAuthApplication user)
        {
            this._user = user;
        }
        //[HttpPost("Registrar")]
        //[AllowAnonymous]
        //public ActionResult<string> Registrar(UsuarioDto user)
        //{
        //    var usuario = _map.Usuario(user);
        //    var regi = _save.Usuario(usuario);
        //    if (regi == null) { return BadRequest("Error"); }
        //    if (regi.Login == "") { return BadRequest("Usuario Existente!"); }
        //    return Ok();
        //}

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> Post(LoginDto user)
        { 
            return Ok(new { token = _user.AuthUsuario(user) });
        } 
    }
}
