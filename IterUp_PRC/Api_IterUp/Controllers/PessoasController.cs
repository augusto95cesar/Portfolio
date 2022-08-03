using System.Collections.Generic; 
using Microsoft.AspNetCore.Mvc; 
using IterUpApi.Data;
using IterUpApi.Dto;
using IterUpApi.Model;
using IterUpApi.Service;
using Microsoft.AspNetCore.Authorization;

namespace IterUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pessoas : ControllerBase
    {
        private Get _buscar;
        private Post _save;
        private Put _alterar;
        private Delete _deletar;
        private Map _map;


        public Pessoas(DataContext context)
        {
            _buscar = new Get(context);
            _save = new Post(context);
            _alterar = new Put(context);
            _deletar = new Delete(context);
            _map = new Map();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Pessoa>> Get()
        {
            var listaPesso = _buscar.ListPessoas();
            if (listaPesso == null) { return BadRequest("Lista de Pessoas Vazia"); }
            if (listaPesso.Count == 0) { return BadRequest("Lista de Pessoas Vazia"); }
            return listaPesso;
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> Get(int id)
        {
            var pessoa = _buscar.Pessoa(id);
            if (pessoa == null) {return BadRequest("Não Cadastrado"); }
            return Ok(pessoa);
        }

        [HttpGet("Uf/{uf}")]
        public ActionResult<List<Pessoa>> Get(string uf)
        {
            var listPessoUF = _buscar.Uf(uf);
            if (listPessoUF == null) { return BadRequest("Lista de Pessoas Vazia"); }
            if (listPessoUF.Count == 0) { return BadRequest("Lista de Pessoas Vazia"); }
            return Ok(listPessoUF);
        }

        [HttpPost]
        public ActionResult<Pessoa> Post(PessoaDto pess)
        {
            var pessoa = _map.Pessoa(pess);
            var salvar = _save.Pessoa(pessoa);
            if (salvar == null) { return BadRequest("Error"); }
            if (salvar.Id == 0) { return BadRequest("Pessoa Existente!"); }
            return Ok(salvar);
        }

        [HttpPut("{id}")]
        public ActionResult<Pessoa> Put(PessoaDto pess, int id)
        {
            var pessoa = _map.Pessoa(pess);
            pessoa.Id = id;
            var alterar = _alterar.Pessoa(pessoa);
            if (alterar == null) { return BadRequest("Error"); }
            if (alterar.Id == 0) { return BadRequest("Pessoa Não Auterada!"); }
            return Ok(alterar);
        }


        //[HttpDelete("{id}")]
        [HttpGet("Delete/{id}")]
        public ActionResult<Pessoa> Delete(int id)
        {
            var deletar = _deletar.Pessoa(id);
            if (deletar == null) { return BadRequest("Error"); }
            if (deletar.Id == 0) { return BadRequest("Não Cadastrado!"); }
            return Ok("Deletado Com Sucesso");
        } 
    }
}
