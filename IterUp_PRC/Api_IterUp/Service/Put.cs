using IterUpApi.Data;
using IterUpApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IterUpApi.Service
{
    public class Put
    {
        private readonly DataContext _db;

        public Put(DataContext context)
        {
            this._db = context;
        }

        public Pessoa Pessoa(Pessoa pess)
        {

            try
            {
                var pessoa = _db.Pessoas.Where(x => x.Id ==  pess.Id).FirstOrDefault();
                if(pessoa == null) { return new Pessoa(); }
                else
                {
                    pessoa.Nome = pess.Nome;
                    pessoa.CPF = pess.CPF;
                    pessoa.UF = pess.UF;
                    pessoa.Nacimento = pess.Nacimento;

                    _db.Entry(pessoa).State = EntityState.Modified;
                   _db.SaveChanges();

                    return pessoa;
                }   
            }
            catch (Exception)
            {
                return  null;
            } 
        }
    }
}
