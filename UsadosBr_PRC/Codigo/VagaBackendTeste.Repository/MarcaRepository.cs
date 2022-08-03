using System;
using System.Collections.Generic;
using System.Linq;
using VagaBackendTeste.Data;
using VagaBackendTeste.Domain.Entity;

namespace VagaBackendTeste.Repository
{
    public class MarcaRepository
    {
        private readonly VagaBackeneTesteContext _db;
        public MarcaRepository(VagaBackeneTesteContext context)
        {
            this._db = context;
        }
        public List<Marca> GetMarcas()
        {
            return _db.Marcas.ToList();
        }
        public Marca GetMarca(int id)
        {
            return _db.Marcas.Where(x => x.Id == id).FirstOrDefault();
        }
        public Marca GetMarca(string nome)
        {
            return _db.Marcas.Where(x => x.NomeMarca == nome).FirstOrDefault();
        }
        public void CreateMarca(Marca marca)
        {
            _db.Marcas.Add(marca);
            _db.SaveChanges();
        }
        public void UpdateMarca(Marca marca)
        {
            Marca mar = _db.Marcas.Where(x => x.Id == marca.Id).FirstOrDefault();
            if (mar != null)
            {
                mar.NomeMarca = marca.NomeMarca;
                _db.Update(mar);
                _db.SaveChanges();
            }
        }
        public void DeleteMarca(Marca marca)
        {
            Marca mar = _db.Marcas.Where(x => x.Id == marca.Id).FirstOrDefault();
            if (mar != null)
            { 
                _db.Remove(mar);
                _db.SaveChanges();
            }
        }
    }
}
