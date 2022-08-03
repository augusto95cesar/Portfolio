using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository _repo;
        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get() { 
            try
            {
                var results = await _repo.GetAllEventoAsyn(true);
                return Ok(results);
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "O Banco de Dados Falhou");
            }            
        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId) { 
            try
            {
                var results = await _repo.GetAllEventoAsynById( EventoId ,true);
                return Ok(results);
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "O Banco de Dados Falhou");
            }            
        }

        [HttpGet("getByTema{tema}")]
        public async Task<IActionResult> Get(string tema) { 
            try
            {
                var results = await _repo.GetAllEventoAsynByTema(tema, true);
                return Ok(results);
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "O Banco de Dados Falhou");
            }            
        }
        [HttpPost]
        public async Task<IActionResult> Post(Evento model) { 
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.EventoId}", model);
                }                
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "O Banco de Dados Falhou");
            }  
            return BadRequest();          
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(int EventoId, Evento model) { 
            try
            {
                var evento = await _repo.GetAllEventoAsynById(EventoId, false);
                if(evento == null) return NotFound();
                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.EventoId}", model);
                }                
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "O Banco de Dados Falhou");
            }  
            return BadRequest();          
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int EventoId) { 
            try
            {
                var evento = await _repo.GetAllEventoAsynById(EventoId, false);
                if(evento == null) return NotFound();
                _repo.Delete(evento);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }                
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "O Banco de Dados Falhou");
            }  
            return BadRequest();          
        }
    }
}