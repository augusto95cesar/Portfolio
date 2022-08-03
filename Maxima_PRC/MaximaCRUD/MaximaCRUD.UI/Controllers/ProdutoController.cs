using MaximaCRUD.Application.Interface;
using MaximaCRUD.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximaCRUD.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produto;

        public ProdutoController(IProdutoApplication produto)
        {
            this._produto = produto;
        }

        [HttpGet("{pg}/{qtditem}")]
        public ActionResult<List<ProdutoDto>> Get(int pg, int qtditem)
        {
            try
            {
                return Ok(_produto.GetProdutos(pg, qtditem));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Descricao/{produto}")]
        public ActionResult<ProdutoDto> GetUser(string produto)
        {
            try
            {
                return Ok(_produto.GetProduto(produto));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<ProdutoDto> Post(CreateProdutoDto produto)
        {
            try
            {
                return Ok(_produto.CreateProduto(produto));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult<bool> Put(ProdutoDto produto)
        {
            try
            {
                return Ok(_produto.UpdateProduto(produto));
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
                return Ok(_produto.DeleteProduto(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
