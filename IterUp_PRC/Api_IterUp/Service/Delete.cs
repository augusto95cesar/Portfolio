using IterUpApi.Data;
using IterUpApi.Model;
using System;
using System.Linq;

namespace IterUpApi.Service
{
    public class Delete
    {
        private readonly DataContext _db;

        public Delete(DataContext context)
        {
            this._db = context;
        }

        public Pessoa Pessoa(int id)
        {
            try
            {
                var pessoa = _db.Pessoas.Where(x => x.Id == id).FirstOrDefault();
                if(pessoa != null)
                {
                    _db.Pessoas.Remove(pessoa);
                    _db.SaveChanges();
                    return pessoa;
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
