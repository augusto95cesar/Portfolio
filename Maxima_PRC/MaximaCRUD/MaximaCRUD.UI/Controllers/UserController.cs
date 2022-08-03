using MaximaCRUD.Application.Interface;
using MaximaCRUD.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic; 

namespace MaximaCRUD.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _user;

        public UserController(IUserApplication user)
        {
            this._user = user;
        }

        [HttpGet("{pg}/{qtditem}")]
        //[Authorize]
        public ActionResult<List<UserDto>> Get(int pg, int qtditem)
        {
            try
            {
                return Ok(_user.GetUsuarios(pg, qtditem));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpGet("Descricao/{login}")]
        public ActionResult<UserDto> GetUser(string login)
        {
            try
            {
                return Ok(_user.GetUsuario(login));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } 
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserDto> Post(CreateUserDto user)
        {
            try
            {
                return Ok(_user.CreateUsuario(user));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult<bool> Put(UpUserDto user)
        {
            try
            {
                return Ok(_user.UpdateUsuario(user));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return Ok(_user.DeleteUsuario(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
