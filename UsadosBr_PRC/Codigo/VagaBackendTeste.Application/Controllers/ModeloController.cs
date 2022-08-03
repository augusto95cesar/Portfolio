using Microsoft.AspNetCore.Mvc; 
using VagaBackendTeste.Domain.Entity;
using VagaBackendTeste.Repository;

namespace VagaBackendTeste.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModeloController : ControllerBase
    {
        private readonly ModeloRepository _modelo;

        public ModeloController(ModeloRepository modelo)
        {
            this._modelo = modelo;
        }

        [HttpGet]
        public ActionResult<object> Get()
        { 
            return Ok(_modelo.GetModelos());
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        { 
            return Ok(_modelo.GetModelo(id));
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult<object> GetMarcaNome(string nome)
        { 
            return Ok(_modelo.GetModelo(nome));
        }

        [HttpPost]
        public ActionResult<object> Post(Modelo modelo)
        {
            _modelo.CreateModelo(modelo);
            return Ok();
        }

        [HttpPut]
        public ActionResult<object> Put(Modelo modelo)
        {
            _modelo.UpdateModelo(modelo);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<object> Delete(Modelo modelo)
        {
            _modelo.DeleteModelo(modelo);
            return Ok();
        }
    }
}
