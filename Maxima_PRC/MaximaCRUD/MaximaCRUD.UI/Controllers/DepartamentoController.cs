using MaximaCRUD.Application.Interface;
using MaximaCRUD.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic; 

namespace MaximaCRUD.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoApplication _application;

        public DepartamentoController(IDepartamentoApplication application)
        {
            this._application = application;
        }

        [HttpGet("{pg}/{qtditem}")]
        public ActionResult<List<DepartamentoDto>> Get(int pg, int qtditem)
        {
            try
            {
                return Ok(_application.GetDepartamentos(pg, qtditem));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Descricao/{departamento}")]
        public ActionResult<DepartamentoDto> GetDepartamento(string departamento)
        {
            try
            {
                return Ok(_application.GetDepartamento(departamento));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<DepartamentoDto> Post(CreateDepartamentoDto dp)
        {
            try
            {
                return Ok(_application.CreateDepartamento(dp));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult<bool> Put(DepartamentoDto dp)
        {
            try
            {
                return Ok(_application.UpdateDepartamento(dp));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return Ok(_application.DeleteDepartamento(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
