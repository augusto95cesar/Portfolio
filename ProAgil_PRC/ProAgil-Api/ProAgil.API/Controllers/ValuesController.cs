using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            return new Evento[] { 
                new Evento(){
                    EventoId = 1,
                    Tema  = "Angular ",
                    Local = "Goiania",
                    //Lote  = "1° Lote",
                    QtdPessoas = 30,
                    //DataEvento = DateTime.Now.AddDays(2).ToString("dd/mm/yyyy")
                },
                new Evento(){
                    EventoId = 2,
                    Tema  = "Angular Plasma",
                    Local = "Goiania-GO",
                    //Lote  = "2° Lote"
                    QtdPessoas = 350,
                    //DataEvento = DateTime.Now.AddDays(3).ToString("dd/mm/yyyy")
                },
                new Evento(){
                    EventoId = 3,
                    Tema  = "Plasma Crisma",
                    Local = "Goiania-GOias",
                    //Lote  = "25° Lote",
                    QtdPessoas = 15009,
                    //DataEvento = DateTime.Now.AddDays(1).ToString("dd/mm/yyyy")
                }
             };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            return new Evento[] { 
                new Evento(){
                    EventoId = 1,
                    Tema  = "Angular ",
                    Local = "Goiania",
                    //Lote  = "1° Lote"
                    QtdPessoas = 30
                   // DataEvento = DateTime.Now.AddDays(2).ToString("dd/mm/yyyy")
                },
                new Evento(){
                    EventoId = 2,
                    Tema  = "Angular Plasma",
                    Local = "Goiania-GO",
                    //Lote  = "2° Lote"
                    QtdPessoas = 350
                    //DataEvento = DateTime.Now.AddDays(3).ToString("dd/mm/yyyy")
                }
            }.FirstOrDefault(x => x.EventoId == id);
        }
        

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
