using IterUpApi.Data;
using IterUpApi.Model;
using System; 
using System.Linq; 

namespace IterUpApi.Service
{
    public class Post
    {
        private readonly DataContext _db;
        public Post(DataContext db)
        {
            this._db = db;
        }

        public Usuario Usuario(Usuario user)
        {
            try 
            {
                if (_db.Usuarios.Where(x => x.Login == user.Login).FirstOrDefault() != null)
                {
                    _db.Usuarios.Add(user);
                    _db.SaveChanges();
                    return user;
                }
                return new Usuario();
            }
            catch (Exception)
            {
                return null;
            } 
        }

        public Pessoa Pessoa(Pessoa user)
        {
            try
            {
                var pessoa = _db.Pessoas.Where(x => x.CPF == user.CPF).FirstOrDefault();


                if (pessoa == null)
                {
                    var uf = user.UF;
                    user.UF = uf.ToUpper();
                    _db.Pessoas.Add(user);
                    _db.SaveChanges();
                    return user;
                }
                return new Pessoa();                
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
