using Microsoft.AspNetCore.Mvc; 
using VagaBackendTeste.Domain.Entity;
using VagaBackendTeste.Repository;

namespace VagaBackendTeste.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessorioController : ControllerBase
    {
        private readonly AcessorioRepository _acessorio;

        public AcessorioController(AcessorioRepository acessorio)
        {
            this._acessorio = acessorio;
        }
        [HttpGet]
        public ActionResult<object> Get()
        { 
            return Ok(_acessorio.GetAcessorios());
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        { 
            return Ok(_acessorio.GetAcessorio(id));
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult<object> GetMarcaNome(string nome)
        { 
            return Ok(_acessorio.GetAcessorio(nome));
        }

        [HttpPost]
        public ActionResult<object> Post(Acessorio acessorio)
        {
            _acessorio.CreateAcessorio(acessorio);
            return Ok();
        }

        [HttpPut]
        public ActionResult<object> Put(Acessorio acessorio)
        {
            _acessorio.UpdateAcessorio(acessorio);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<object> Delete(Acessorio acessorio)
        {
            _acessorio.DeleteAcessorio(acessorio);
            return Ok();
        }
    }
}
