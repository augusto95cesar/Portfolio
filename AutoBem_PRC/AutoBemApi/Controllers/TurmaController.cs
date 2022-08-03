using AutoBemApi.Context;
using AutoBemApi.Dto;
using AutoBemApi.Model;
using AutoBemApi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections;
using System.Collections.Generic;

namespace AutoBemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TurmaController : ControllerBase
    {
        private readonly TurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public TurmaController(AutoBemContext context, IMapper mapper)
        {
            this._turmaRepository = new TurmaRepository(context);
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            try
            {
                return Ok(_mapper.Map<ICollection<TurmaDto>>( _turmaRepository.BuscarTuma()));
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
                return Ok(_mapper.Map<ICollection<TurmaDto>>(_turmaRepository.BuscarTurmaId(id)));
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
                _turmaRepository.CadastrarTurma(turma);
                return Ok($"Turma {turma.Nome} foi salva com sucesso!");
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
                _turmaRepository.AtualizarTurma(turma);
                return Ok($"Turma {turma.Nome} foi Atualizada com sucesso!");
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
                _turmaRepository.DeletarTurma(id);
                return Ok($"Turma foi Deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
