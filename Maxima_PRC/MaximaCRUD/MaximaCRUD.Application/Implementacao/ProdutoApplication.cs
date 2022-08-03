using MaximaCRUD.Application.Interface;
using MaximaCRUD.Data;
using MaximaCRUD.Domain.Dtos;
using MaximaCRUD.Repository;
using System;
using System.Collections.Generic;
using MaximaCRUD.Service.Map;

namespace MaximaCRUD.Application.Implementacao
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly ProdutoRepository _prod;

        public ProdutoApplication(DataContext context)
        {
            this._prod = new ProdutoRepository(context);
        }
        public ProdutoDto CreateProduto(CreateProdutoDto prod)
        {
            return _prod.CreateProduto(prod.MapearProdutoDto()).MapearProduto();
        }

        public bool DeleteProduto(int codigoProduto)
        {
            return _prod.DeleteProduto(codigoProduto);
        }

        public ProdutoDto GetProduto(string nome)
        {
            return _prod.GetProduto(nome).MapearProduto();
        }

        public List<ProdutoDto> GetProdutos(int pagina, int quantidade)
        {
            return _prod.GetProdutos(pagina, quantidade).MapearProdutosDtos();
        }

        public bool UpdateProduto(ProdutoDto prod)
        {
            return _prod.UpdateProduto(prod.MapearProduto());
        }
    }
}
