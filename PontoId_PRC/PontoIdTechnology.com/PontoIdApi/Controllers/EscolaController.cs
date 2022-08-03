using Microsoft.AspNetCore.Mvc; 
using PontoIdApi.Context;
using PontoIdApi.Context.ServiceContext;
using PontoIdApi.Model;
using System;

namespace PontoIdApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EscolaController : ControllerBase
    {
        private readonly EscolaServiceContext _escolaService;
        public EscolaController(PontoIdContext context)
        {
            this._escolaService = new EscolaServiceContext(context);
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            try
            {                
                return Ok(_escolaService.BuscarEscola());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            try
            {
                return Ok(_escolaService.BuscarEscolaId(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<object> Post(Escola escola)
        {
            try
            {
                _escolaService.CadastrarEscola(escola);
                return Ok($"Escola {escola.Nome} foi salva com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<object> Put(Escola escola)
        {
            try
            {
                _escolaService.AtualizarEscola(escola);
                return Ok($"Escola {escola.Nome} foi Atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<object> Delete(int id)
        {
            try
            {
                _escolaService.DeletarEscola(id);
                return Ok($"Escola foi Deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
