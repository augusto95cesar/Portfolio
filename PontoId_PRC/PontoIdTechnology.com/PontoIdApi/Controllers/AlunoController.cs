using Microsoft.AspNetCore.Mvc;
using PontoIdApi.Context;
using PontoIdApi.Context.ServiceContext;
using PontoIdApi.Model;
using System;

namespace PontoIdApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoServiceContext _alunoService;
        public AlunoController(PontoIdContext context)
        {
            this._alunoService = new AlunoServiceContext(context);
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            try
            {
                return Ok(_alunoService.BuscarAluno());
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
                return Ok(_alunoService.BuscarAlunoId(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<object> Post(Aluno aluno)
        {
            try
            {
                _alunoService.CadastrarAluno(aluno);
                return Ok($"Aluno {aluno.Nome} foi salva com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<object> Put(Aluno aluno)
        {
            try
            {
                _alunoService.AtualizarAluno(aluno);
                return Ok($"Aluno {aluno.Nome} foi Atualizada com sucesso!");
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
                _alunoService.DeletarAluno(id);
                return Ok($"Aluno foi Deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
