using MaximaCRUD.Data;
using MaximaCRUD.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximaCRUD.Repository
{
    public class DepartamentoRepository
    {
        private readonly DataContext _db;

        public DepartamentoRepository(DataContext context)
        {
            this._db = context; 
        }

        public List<Departamento> GetDepartamentos(int pagina, int quantidade)
        {
            pagina = (pagina - 1) * quantidade;
            return _db.Departamentos.OrderBy(X => X.Id).Skip(pagina).Take(quantidade).ToList();
        }

        public Departamento GetDepartamento(string dp)
        {
            return _db.Departamentos.Where(x => x.NomeDepartamento == dp).FirstOrDefault();
        }

        public Departamento CreateDepartamento(Departamento dp)
        {
            _db.Add(dp);
            _db.SaveChanges();
            return _db.Departamentos.Where(x => x.NomeDepartamento == dp.NomeDepartamento).FirstOrDefault();
        }

        public bool UpdateDepartamento(Departamento dp)
        {
            var dpUpdate = _db.Departamentos.Where(x => x.Id == dp.Id).FirstOrDefault();
            if (dpUpdate != null)
            {
                //Atualizar
                dpUpdate.NomeDepartamento = dp.NomeDepartamento; 
                _db.Update(dpUpdate);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteDepartamento(int id)
        {
            var dpDelete = _db.Departamentos.Where(x => x.Id == id).FirstOrDefault();
            if (dpDelete != null)
            { 
                _db.Remove(dpDelete);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
