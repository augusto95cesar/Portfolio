using MaximaCRUD.Data;
using MaximaCRUD.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximaCRUD.Repository
{
   public class ProdutoRepository
    {
        private readonly DataContext _db;

        public ProdutoRepository(DataContext context)
        {
            this._db = context;
        }

        public List<Produto> GetProdutos(int pagina, int quantidade)
        {
            pagina = (pagina - 1) * quantidade;
            return _db.Produtos.Include(x => x.Departamento).OrderBy(X => X.Id).Skip(pagina).Take(quantidade).ToList();
        }

        public List<Produto> GetProdutosDepartamento(int idDepartamento)
        { 
            return _db.Produtos.Where(x => x.CodigoDepartamento == idDepartamento).ToList();
        }

        public Produto GetProduto(string nome)
        {
            return _db.Produtos.Where(x => x.Descricao == nome).Include(x => x.Departamento).FirstOrDefault();
        }

        public Produto CreateProduto(Produto prod)
        {
            _db.Add(prod);
            _db.SaveChanges();
            return _db.Produtos.Where(x => x.Descricao == prod.Descricao).Include(x => x.Departamento).FirstOrDefault();
        }

        public bool UpdateProduto(Produto prod)
        {
            var prodUpdate = _db.Produtos.Where(x => x.Id == prod.Id).FirstOrDefault();
            if (prodUpdate != null)
            {
                //Atualizar
                prodUpdate.Descricao = prod.Descricao;
                prodUpdate.CodigoDepartamento = prod.CodigoDepartamento;
                prodUpdate.Status = prod.Status;
                prodUpdate.Preco = prod.Preco; 
                _db.Update(prodUpdate);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteProduto(int id)
        {
            var prodDelete = _db.Produtos.Where(x => x.Id == id).FirstOrDefault();
            if (prodDelete != null)
            {
                _db.Remove(prodDelete);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
