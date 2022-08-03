using IterUpApi.Data;
using IterUpApi.Dto; 
using IterUpApi.Dto.ChatBot;
using IterUpApi.Model.WorkFlow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IterUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ChatBot : ControllerBase
    {
        private readonly DataContext _db;

        public ChatBot(DataContext context)
        {
            this._db = context;
        } 

        [HttpPost("Etapas")]
        [AllowAnonymous]
        public ActionResult<object> Etapas(StringChat text)
       {
            if(text.texto == "")
            {
               var result = _db.MensagemOuPergunta.Where(x => x.Id == 1).FirstOrDefault();
                return result;
            }
            else
            {
                var result = _db.MensagemOuPergunta.Where(x => x.Id == Convert.ToInt32(text.texto)).FirstOrDefault();
                return result;
            } 
        }

        [HttpPost("Respostas")]
        [AllowAnonymous]
        public ActionResult<object> Respostas(StringChat text)
        { 
            var result = _db.Resposta.Where(x => x.CodEtapa  == Convert.ToInt32(text.texto)).ToList();
            return result; 
        }

        [HttpPost("CadastroEtapa")]
        [AllowAnonymous]
        public ActionResult<object> CadastroEtapa(MensagemOuPergunta Etapa)
        {
            try
            {
                _db.MensagemOuPergunta.Add(Etapa);
                _db.SaveChanges();
                return _db.MensagemOuPergunta.Max(x => x.Id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("CadastroRespostas")]
        [AllowAnonymous]
        public ActionResult<object> CadastroEtapa(Resposta resposta)
        {
            try
            {
                _db.Resposta.Add(resposta);
                _db.SaveChanges();
                return _db.Resposta.Max(x => x.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


    }
}
