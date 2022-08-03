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
    public class CarroController: ControllerBase
    {
        private readonly CarroRepository _carro;

        public CarroController(CarroRepository carro)
        {
            this._carro = carro;
        }
        [HttpGet]
        public ActionResult<object> Get()
        {
            return Ok(_carro.GetCarros());
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            return Ok(_carro.GetCarro(id));
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult<object> GetMarcaNome(string nome)
        {
            return Ok(_carro.GetCarro(nome));
        }

        [HttpPost]
        public ActionResult<object> Post(Carro carro)
        {
            _carro.CreateCarro(carro);
            return Ok();
        } 

        [HttpPut]
        public ActionResult<object> Put(Carro carro)
        {
            _carro.UpdateCarro(carro);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<object> Delete(Carro carro)
        {
            _carro.DeleteCarro(carro);
            return Ok();
        }

    }
}
