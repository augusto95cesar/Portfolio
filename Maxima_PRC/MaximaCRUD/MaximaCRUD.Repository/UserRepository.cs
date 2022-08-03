using MaximaCRUD.Data;
using MaximaCRUD.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximaCRUD.Repository
{
    public class UserRepository
    {
        private readonly DataContext _db;

        public UserRepository(DataContext context)
        {
            this._db = context;
        }

        public List<User> GetUsuarios(int pagina, int quantidade)
        {
           pagina = (pagina - 1) * quantidade;
          return _db.Users.OrderBy(X => X.Id).Skip(pagina).Take(quantidade).ToList();
        }

        public User GetUsuario(string login)
        { 
            return _db.Users.Where(x => x.Login == login).FirstOrDefault();
        }

        public User CreateUsuario(User user)
        {
            _db.Add(user);
            _db.SaveChanges();
            return _db.Users.Where(x => x.Login == user.Login).FirstOrDefault();
        }

        public bool UpdateUsuario(User user)
        {
            var userUpdate = _db.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (userUpdate != null)
            {
                //Atualizar
                userUpdate.Login = user.Login;
                userUpdate.PassWord =  user.PassWord;

                _db.Update(userUpdate);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUsuario(int id)
        {
            var userDelete = _db.Users.Where(x => x.Id == id).FirstOrDefault();
            if (userDelete != null)
            { 
                _db.Remove(userDelete);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
