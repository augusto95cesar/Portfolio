using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VagaBackendTeste.Data;
using VagaBackendTeste.Domain.Entity;

namespace VagaBackendTeste.Repository
{
    public class CarroAcessorioRepository
    {

        private readonly VagaBackeneTesteContext _db;
        public CarroAcessorioRepository(VagaBackeneTesteContext context)
        {
            this._db = context;
        }
        public List<CarroAcessorio> GetCarroAcessorios(int idCarro)
        {
            return _db.CarroAcessorios.Where(x => x.CodigoCarro == idCarro).ToList();
        }
        public CarroAcessorio GetCarroAcessorio(int id)
        {
            return _db.CarroAcessorios.Where(x => x.Id == id).FirstOrDefault();
        }
        public void CreateCarroAcessorio(CarroAcessorio carroAcessorio)
        {
            _db.CarroAcessorios.Add(carroAcessorio);
            _db.SaveChanges();
        }
        public void UpdateCarroAcessorio(CarroAcessorio carroAcessorio)
        {
            CarroAcessorio carro = _db.CarroAcessorios.Where(x => x.Id == carroAcessorio.Id).FirstOrDefault();
            if (carro != null)
            {
                carro.CodigoAcessorio = carroAcessorio.CodigoAcessorio;
                carro.CodigoCarro = carroAcessorio.CodigoCarro;
                _db.Update(carro);
                _db.SaveChanges();
            }
        }
        public void DeleteCarroAcessorio(CarroAcessorio carro)
        {
            foreach (var item in _db.CarroAcessorios.Where(x => x.Id == carro.Id).ToList())
            {
                _db.Remove(item);
                _db.SaveChanges();
            };
        }
    }
}
