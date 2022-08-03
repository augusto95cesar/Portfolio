using MaximaCRUD.Domain.Dtos;
using MaximaCRUD.Domain.Entity;
using System;
using System.Collections.Generic;

namespace MaximaCRUD.Service.Map
{
   public static class MapProduto
    {
        public static List<ProdutoDto> MapearProdutosDtos(this List<Produto> produtos)
        {
            List<ProdutoDto> dto = new List<ProdutoDto>();
            foreach(var item in produtos)
            {
                ProdutoDto prod = new ProdutoDto
                {
                    CodigoDepartamento = item.CodigoDepartamento.ToString(),
                    CodigoProduto = item.Id.ToString(),
                    Descricao = item.Descricao,
                    Preco = item.Preco,
                    Departamento = item.Departamento.NomeDepartamento,
                    Status = item.Status
                };
                dto.Add(prod);
            }
            return dto;
        }
        public static Produto MapearProdutoDto(this CreateProdutoDto prod)
        {
            return new Produto
            {
                Preco = prod.Preco,
                Descricao = prod.Descricao,
                Status = prod.Status,
                CodigoDepartamento = prod.CodigoDepartamento
            };
        }
        public static ProdutoDto MapearProduto(this Produto prod)
        {
            return new ProdutoDto
            {
                CodigoDepartamento = prod.CodigoDepartamento.ToString(),
                CodigoProduto = prod.Id.ToString(),
                Status = prod.Status,
                Descricao = prod.Descricao,
                Preco = prod.Preco,
                Departamento = prod.Departamento.NomeDepartamento
            };
        }
        public static Produto  MapearProduto(this ProdutoDto prod)
        {
            return new Produto 
            {
                 Id = Convert.ToInt32(prod.CodigoProduto),
                 Descricao = prod.Descricao,
                 Preco = prod.Preco,
                 Status = prod.Status,
                 CodigoDepartamento = Convert.ToInt32(prod.CodigoDepartamento)
            };
        }
    }
}
