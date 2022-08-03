using Microsoft.AspNetCore.Mvc;
using PontoIdApi.Context;
using PontoIdApi.Context.ServiceContext;
using PontoIdApi.Model;
using System;

namespace PontoIdApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly TurmaServiceContext _turmaService;
        public TurmaController(PontoIdContext context)
        {
            this._turmaService = new TurmaServiceContext(context);
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            try
            {
                return Ok(_turmaService.BuscarTuma());
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
                return Ok(_turmaService.BuscarTurmaId(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<object> Post(Turma turma)
        {
            try
            {
                _turmaService.CadastrarTurma(turma);
                return Ok($"Turma {turma.Descricao} foi salva com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<object> Put(Turma turma)
        {
            try
            {
                _turmaService.AtualizarTurma(turma);
                return Ok($"Turma {turma.Descricao} foi Atualizada com sucesso!");
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
                _turmaService.DeletarTurma(id);
                return Ok($"Turma foi Deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
