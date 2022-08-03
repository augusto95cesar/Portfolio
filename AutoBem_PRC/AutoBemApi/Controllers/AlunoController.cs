using AutoBemApi.Context;
using AutoBemApi.Dto;
using AutoBemApi.Model;
using AutoBemApi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using System; 
using System.Collections.Generic;

namespace AutoBemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoController(AutoBemContext context, IMapper mapper)
        {
            this._alunoRepository = new AlunoRepository(context);
            this._mapper = mapper;
        }

        [HttpGet]
       // [AllowAnonymous]
        public ActionResult<object> Get()
        {
            try
            {
                return Ok(_mapper.Map<ICollection<AlunoDto>>( _alunoRepository.BuscarAluno()));
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
                return Ok(_mapper.Map <AlunoDto>(_alunoRepository.BuscarAlunoId(id)));
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
                _alunoRepository.CadastrarAluno(aluno);
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
                _alunoRepository.AtualizarAluno(aluno);
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
                _alunoRepository.DeletarAluno(id);
                return Ok($"Aluno foi Deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
