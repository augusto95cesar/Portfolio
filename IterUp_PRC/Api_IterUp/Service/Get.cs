using IterUpApi.Data;
using IterUpApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IterUpApi.Service
{
    public class Get
    {
        private readonly DataContext _db;

        public Get(DataContext db)
        {
            this._db = db;
        }

        public Usuario UsuarioAutorizado(Usuario user)
        {
            try
            {
                var usuario = _db.Usuarios.Where(x => x.Login == user.Login && x.Password == user.Password).FirstOrDefault();
                if(usuario == null) { return new Usuario(); }
                return usuario;
            }
            catch (Exception)
            {
                return new Usuario();
            }
        }

        public List<Pessoa> ListPessoas()
        {
            try
            {
               return  _db.Pessoas.OrderBy(x => x.Nome).ToList();
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Pessoa Pessoa(int id)
        {
            try
            {
                return _db.Pessoas.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Pessoa> Uf(string uf)
        {
            try
            {
                return _db.Pessoas.Where(x => x.UF == uf.ToUpper()).OrderBy(x => x.Nome).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
