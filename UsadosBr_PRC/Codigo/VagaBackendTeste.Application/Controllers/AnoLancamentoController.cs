using Microsoft.AspNetCore.Mvc;
using VagaBackendTeste.Domain.Entity;
using VagaBackendTeste.Repository;

namespace VagaBackendTeste.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnoLancamentoController : ControllerBase
    {
        private readonly AnoLancamentoRepository _ano;

        public AnoLancamentoController(AnoLancamentoRepository ano)
        {
            this._ano = ano;
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            return Ok(_ano.GetAnoLancamentos());
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            return Ok(_ano.GetAnoLancamento(id));
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult<object> GetMarcaNome(string nome)
        {
            return Ok(_ano.GetAnoLancamento(nome));
        }

        [HttpPost]
        public ActionResult<object> Post(AnoLancamento anoLancamento)
        {
            _ano.CreateAnoLancamento(anoLancamento);
            return Ok();
        }

        [HttpPut]
        public ActionResult<object> Put(AnoLancamento anoLancamento)
        {
            _ano.UpdateAnoLancamento(anoLancamento);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<object> Delete(AnoLancamento anoLancamento)
        {
            _ano.DeleteAnoLancamento(anoLancamento);
            return Ok();
        }
    }
}
