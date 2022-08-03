using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VagaBackendTeste.Data;
using VagaBackendTeste.Domain.Entity;

namespace VagaBackendTeste.Repository
{
    public class AcessorioRepository
    {
        private readonly VagaBackeneTesteContext _db;
        public AcessorioRepository(VagaBackeneTesteContext context)
        {
            this._db = context;
        }
        public List<Acessorio> GetAcessorios()
        {
            return _db.Acessorios.ToList();
        }
        public Acessorio GetAcessorio(int id)
        {
            return _db.Acessorios.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Acessorio> GetAcessorioIdCarro(int idCarro)
        {
            var carro = _db.Carros.Where(x => x.Id == idCarro).FirstOrDefault();
            if (carro != null)
            {
                var list = _db.CarroAcessorios.Where(x => x.CodigoCarro == carro.Id).ToList();
                if (list.Count() != 0)
                {
                    List<Acessorio> listAcessorio = new List<Acessorio>();
                    foreach (var carroAcessorios in list)
                    {
                        Acessorio acessorio = _db.Acessorios.Where(x => x.Id == carroAcessorios.CodigoAcessorio).FirstOrDefault();
                        if (acessorio != null)
                        {
                            listAcessorio.Add(acessorio);
                        }
                    }
                    return listAcessorio;
                }
            }
            return null;
        }
        public List<Acessorio> GetAcessorioPlacaCarro(string placaCarro)
        {
            var carro = _db.Carros.Where(x => x.Placa == placaCarro).FirstOrDefault();
            if (carro != null)
            {
                var list = _db.CarroAcessorios.Where(x => x.CodigoCarro == carro.Id).ToList();
                if (list.Count() != 0)
                {
                    List<Acessorio> listAcessorio = new List<Acessorio>();
                    foreach (var carroAcessorios in list)
                    {
                        Acessorio acessorio = _db.Acessorios.Where(x => x.Id == carroAcessorios.CodigoAcessorio).FirstOrDefault();
                        if (acessorio != null)
                        {
                            listAcessorio.Add(acessorio);
                        }
                    }
                    return listAcessorio;
                }
            }
            return null;
        }
        public Acessorio GetAcessorio(string nome)
        {
            return _db.Acessorios.Where(x => x.NomeAcessorio == nome).FirstOrDefault();
        }
        public void CreateAcessorio(Acessorio acessorio)
        {
            _db.Acessorios.Add(acessorio);
            _db.SaveChanges();
        }
        public void UpdateAcessorio(Acessorio acessorio)
        {
            Acessorio mar = _db.Acessorios.Where(x => x.Id == acessorio.Id).FirstOrDefault();
            if (mar != null)
            {
                mar.NomeAcessorio = acessorio.NomeAcessorio;
                _db.Update(mar);
                _db.SaveChanges();
            }
        }
        public void DeleteAcessorio(Acessorio acessorio)
        {
            Acessorio mar = _db.Acessorios.Where(x => x.Id == acessorio.Id).FirstOrDefault();
            if (mar != null)
            {
                mar.NomeAcessorio = acessorio.NomeAcessorio;
                _db.Update(mar);
                _db.SaveChanges();
            }
        }

    }
}
