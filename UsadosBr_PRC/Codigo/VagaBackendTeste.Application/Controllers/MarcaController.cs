using Microsoft.AspNetCore.Mvc;
using VagaBackendTeste.Business;
using VagaBackendTeste.Domain.Entity;
using VagaBackendTeste.Repository;

namespace VagaBackendTeste.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly MarcaRepository _marcas;
        private readonly MarcaCarroBusiness _marcaBusiness;
        public MarcaController(MarcaRepository marcas, MarcaCarroBusiness marcaBusiness)
        {
            this._marcas = marcas;
            this._marcaBusiness = marcaBusiness;
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            var marcas =_marcas.GetMarcas();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            var marcas = _marcas.GetMarca(id);
            return Ok(marcas);
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult<object> GetMarcaNome(string nome)
        {
            var marcas = _marcas.GetMarca(nome);
            return Ok(marcas);
        }

        [HttpPost]
        public ActionResult<object> Post(Marca marca)
        {
            var qtd = _marcaBusiness.QtdCaractereMarca(marca);
            if(qtd == false)
            {
                return BadRequest("Quantidade de caracter da marca ultrapassou o limite permitido!");
            }
            _marcas.CreateMarca(_marcaBusiness.UpperMarca(marca));
            return Ok();
        }

        [HttpPut]
        public ActionResult<object> Put(Marca marca)
        {
            var qtd = _marcaBusiness.QtdCaractereMarca(marca);
            if (qtd == false)
            {
                return BadRequest("Quantidade de caracter da marca ultrapassou o limite permitido!");
            }
            _marcas.UpdateMarca(_marcaBusiness.UpperMarca(marca));
            return Ok();
        }

        [HttpDelete]
        public ActionResult<object> Delete(Marca marca)
        {
            _marcas.DeleteMarca(marca);
            return Ok();
        }

    }
}
