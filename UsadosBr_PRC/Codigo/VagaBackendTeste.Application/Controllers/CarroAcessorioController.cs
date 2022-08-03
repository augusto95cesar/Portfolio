using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VagaBackendTeste.Domain.Entity;
using VagaBackendTeste.Repository;

namespace VagaBackendTeste.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroAcessorioController : ControllerBase
    {
        private readonly CarroAcessorioRepository _carroAcessorio;

        public CarroAcessorioController(CarroAcessorioRepository modelo)
        {
            this._carroAcessorio = modelo;
        }

        [HttpGet("Lista/{idCarro}")]
        public ActionResult<object> Lista(int idCarro)
        { 
            return Ok(_carroAcessorio.GetCarroAcessorios(idCarro));
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            return Ok(_carroAcessorio.GetCarroAcessorio(id));
        } 

        [HttpPost]
        public ActionResult<object> Post(CarroAcessorio acessorio)
        {
            _carroAcessorio.CreateCarroAcessorio(acessorio);
            return Ok();
        }

        [HttpPut]
        public ActionResult<object> Put(CarroAcessorio acessorio)
        {
            _carroAcessorio.UpdateCarroAcessorio(acessorio);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<object> Delete(CarroAcessorio acessorio)
        {
            _carroAcessorio.DeleteCarroAcessorio(acessorio);
            return Ok();
        }
    }
}
