using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VagaBackendTeste.Data;
using VagaBackendTeste.Domain.Entity;

namespace VagaBackendTeste.Repository
{
    public class ModeloRepository
    {
        private readonly VagaBackeneTesteContext _db;
        public ModeloRepository(VagaBackeneTesteContext context)
        {
            this._db = context;
        }
        public List<Modelo> GetModelos()
        {
            return _db.Modelos.ToList();
        }
        public List<Modelo> GetModelosNomeMarca(string nomeMarca)
        {
            Marca marca = _db.Marcas.Where(x => x.NomeMarca == nomeMarca).FirstOrDefault();
            if (marca != null)
            {
                return _db.Modelos.Where(x => x.CodigoMarca == marca.Id).ToList();
            }
            return null;
        }
        public List<Modelo> GetModelosIdMarca(int idMarca)
        {
            Marca marca = _db.Marcas.Where(x => x.Id == idMarca).FirstOrDefault();
            if (marca != null)
            {
                return _db.Modelos.Where(x => x.CodigoMarca == marca.Id).ToList();
            }
            return null;
        }
        public Modelo GetModelo(int id)
        {
            return _db.Modelos.Where(x => x.Id == id).FirstOrDefault();
        }
        public Modelo GetModelo(string nome)
        {
            return _db.Modelos.Where(x => x.NomeModelo == nome).FirstOrDefault();
        }
        public void CreateModelo(Modelo modelo)
        {
            _db.Modelos.Add(modelo);
            _db.SaveChanges();
        } 
        public void UpdateModelo(Modelo modelo)
        {
            Modelo mod = _db.Modelos.Where(x => x.Id == modelo.Id).FirstOrDefault();
            if (mod != null)
            {
                mod.NomeModelo = modelo.NomeModelo;
                mod.CodigoMarca = modelo.CodigoMarca;
                _db.Update(mod);
                _db.SaveChanges();
            }
        }
        public void DeleteModelo(Modelo modelo)
        {
            Modelo mod = _db.Modelos.Where(x => x.Id == modelo.Id).FirstOrDefault();
            if (mod != null)
            { 
                _db.Remove(mod);
                _db.SaveChanges();
            }
        } 
    }
}
