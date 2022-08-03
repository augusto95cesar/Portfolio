using IterUpApi.Data;
using IterUpApi.Dto;
using IterUpApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IterUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private  Post _save;
        private  Get _get;
        private  Map _map;
        private  GerarToken _token;

        public AuthController(DataContext db)
        {            
            this._save = new Post(db);
            this._get = new Get(db);
            this._map = new Map();
            this._token = new GerarToken();
        }
        
        
        [HttpPost("Registrar")]
        [AllowAnonymous]
        public ActionResult<string> Registrar(UsuarioDto user)
        {            
            var usuario = _map.Usuario(user);
            var regi = _save.Usuario(usuario);            
            if(regi == null) { return BadRequest("Error"); }
            if(regi.Login == "") { return BadRequest("Usuario Existente!"); }
            return Ok();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult<string> Login(UsuarioDto user)
        {
            var mapUsuario = _map.Usuario(user);
            var buscarUsuario = _get.UsuarioAutorizado(mapUsuario);
            if (buscarUsuario == null) { return Unauthorized(); }
            return Ok(new
            {
                token = _token.GenerateJWT(buscarUsuario)
            });
        }

      
    }
}
