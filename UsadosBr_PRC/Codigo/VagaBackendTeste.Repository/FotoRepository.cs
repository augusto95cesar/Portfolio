using System.Collections.Generic;
using System.Linq;
using VagaBackendTeste.Data;
using VagaBackendTeste.Domain.Entity;

namespace VagaBackendTeste.Repository
{
    public class FotoRepository
    {
        private readonly VagaBackeneTesteContext _db;
        public FotoRepository(VagaBackeneTesteContext context)
        {
            this._db = context;
        }
        public List<Foto> GetFotos(int idCarro)
        {
            return _db.Fotos.Where(x => x.CodigoCarro == idCarro).ToList();
        }
        public Foto GetFoto(int id)
        {
            return _db.Fotos.Where(x => x.Id == id).FirstOrDefault();
        }
        public Foto GetFoto(string path)
        {
            return _db.Fotos.Where(x => x.Path == path).FirstOrDefault();
        }
        public void CreateFoto(Foto foto)
        {
            _db.Fotos.Add(foto);
            _db.SaveChanges();
        }
        public void UpdateFoto(Foto foto)
        {
            Foto fot = _db.Fotos.Where(x => x.Id == foto.Id).FirstOrDefault();
            if (fot != null)
            {
                fot.Path = foto.Path;
                _db.Update(fot);
                _db.SaveChanges();
            }
        }
        public void DeleteFoto(Foto foto)
        {
            Foto fot = _db.Fotos.Where(x => x.Id == foto.Id).FirstOrDefault();
            if (fot != null)
            {
                _db.Remove(fot);
                _db.SaveChanges();
            }
        }
    }
}
