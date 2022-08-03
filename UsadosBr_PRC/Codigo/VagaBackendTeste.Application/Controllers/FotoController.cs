using Microsoft.AspNetCore.Mvc;
using VagaBackendTeste.Domain.Entity;
using VagaBackendTeste.Repository;

namespace VagaBackendTeste.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FotoController : ControllerBase
    {
        private readonly FotoRepository _foto; 
        public FotoController(FotoRepository foto)
        {
            this._foto = foto;
        }

        [HttpGet("ListaFotosCarro/idCarro")]
        public ActionResult<object> ListaFotosCarro(int idCarro)
        {
            return Ok(_foto.GetFotos(idCarro));
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            return Ok(_foto.GetFoto(id));
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult<object> GetMarcaNome(string nome)
        {
            return Ok(_foto.GetFoto(nome));
        }

        [HttpPost]
        public ActionResult<object> Post(Foto foto)
        {
            _foto.CreateFoto(foto);
            return Ok();
        }

        [HttpPut]
        public ActionResult<object> Put(Foto foto)
        {
            _foto.UpdateFoto(foto);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<object> Delete(Foto foto)
        {
            _foto.DeleteFoto(foto);
            return Ok();
        }
    }
}
