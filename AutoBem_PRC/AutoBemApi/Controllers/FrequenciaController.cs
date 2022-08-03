using AutoBemApi.Context;
using AutoBemApi.Dto;
using AutoBemApi.Model;
using AutoBemApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AutoBemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FrequenciaController : ControllerBase
    {
        private readonly FrequenciaRepository _frequenciaRepository;
        public FrequenciaController(AutoBemContext context)
        {
            this._frequenciaRepository = new FrequenciaRepository(context);
        }



        [HttpGet("{idTurma}")]
        [AllowAnonymous]
        public ActionResult<object> Get(int idTurma)
        {
            try
            {               
                return Ok(_frequenciaRepository.obterFrequeciaAlunos(idTurma));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<object> Post(Frequencia freq)
        {
            try
            {
                _frequenciaRepository.registrarFrequecia(freq);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<object> Put(Frequencia freq)
        {
            try
            {
                _frequenciaRepository.alterarFrequencia(freq);
                return Ok();
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
                _frequenciaRepository.deletarFrequenciaId(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
