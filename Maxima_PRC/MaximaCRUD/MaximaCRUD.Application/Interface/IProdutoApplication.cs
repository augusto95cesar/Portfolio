using MaximaCRUD.Domain.Dtos; 
using System.Collections.Generic; 

namespace MaximaCRUD.Application.Interface
{
    public interface IProdutoApplication
    {
        public List<ProdutoDto> GetProdutos(int pagina, int quantidade);
        public ProdutoDto GetProduto(string nome);
        public ProdutoDto CreateProduto(CreateProdutoDto prod);
        public bool UpdateProduto(ProdutoDto prod);
        public bool DeleteProduto(int codigoProduto);
    }
}
