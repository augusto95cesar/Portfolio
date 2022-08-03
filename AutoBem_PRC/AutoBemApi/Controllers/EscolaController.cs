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
    public class EscolaController : ControllerBase
    {
        private readonly EscolaRepository _escolaRepository;
        private readonly IMapper _mapper;

        public EscolaController(AutoBemContext context, IMapper mapper)
        {
            this._escolaRepository = new EscolaRepository(context);
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            try
            { 
                return Ok(_mapper.Map<ICollection<EscolaDto>>(_escolaRepository.BuscarEscola()));
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
                return Ok(_mapper.Map<EscolaDto>(_escolaRepository.BuscarEscolaId(id)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<object> Post(EscolaDto escola)
        {
            try
            {
                _escolaRepository.CadastrarEscola(_mapper.Map<Escola>(escola));
                return Ok($"Escola {escola.Nome} foi salva com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<object> Put(EscolaDto escola, int id)
        {
            try
            {
                _escolaRepository.AtualizarEscola(_mapper.Map<Escola>(escola), id);
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
                _escolaRepository.DeletarEscola(id);
                return Ok($"Escola foi Deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
