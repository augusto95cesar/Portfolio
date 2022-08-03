using System.Collections.Generic;
using System.Linq;
using VagaBackendTeste.Data;
using VagaBackendTeste.Domain.Entity;
using Dapper;
using VagaBackendTeste.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace VagaBackendTeste.Repository
{
    public class CarroRepository
    {
        private readonly VagaBackeneTesteContext _db;
        public CarroRepository(VagaBackeneTesteContext context)
        {
            this._db = context;
        }
        public List<ListaCarroDto> GetCarros()
        {
            var carroList = _db.Carros.Include(x => x.Fotos).Include(x => x.Modelo).Include(x => x.AnoLancamento).ToList();
            List<ListaCarroDto> dto = new List<ListaCarroDto>();
            foreach (var car in carroList)
            {
                ListaCarroDto carro = new ListaCarroDto
                {
                    Placa = car.Placa,
                    Ano = car.AnoLancamento.Ano.ToString("yyyy"),
                    NomeModelo = car.Modelo.NomeModelo,
                    PathFoto = car.Fotos.Select(x => x.Path).ToList()
                };
                var carroAcessorio = _db.CarroAcessorios.Where(x => x.CodigoCarro == car.Id).Include(x => x.Acessorio).ToList();
                carro.Acessorios = carroAcessorio.Select(x => x.Acessorio.NomeAcessorio).ToList();
                dto.Add(carro);
            }

            return dto;
        }
        public ListaCarroDto GetCarro(int id)
        {
            var carroList = _db.Carros.Where(x => x.Id == id).Include(x => x.Fotos).Include(x => x.Modelo).Include(x => x.AnoLancamento).FirstOrDefault();
            if(carroList != null)
            {
                ListaCarroDto carro = new ListaCarroDto
                {
                    Placa = carroList.Placa,
                    Ano = carroList.AnoLancamento.Ano.ToString("yyyy"),
                    NomeModelo = carroList.Modelo.NomeModelo,
                    PathFoto = carroList.Fotos.Select(x => x.Path).ToList()
                };
                var carroAcessorio = _db.CarroAcessorios.Where(x => x.CodigoCarro == carroList.Id).Include(x => x.Acessorio).ToList();
                carro.Acessorios = carroAcessorio.Select(x => x.Acessorio.NomeAcessorio).ToList();
                return carro;
            }
            return null;            
        }
        public ListaCarroDto GetCarro(string placa)
        {
            var carroList = _db.Carros.Where(x => x.Placa == placa).Include(x => x.Fotos).Include(x => x.Modelo).Include(x => x.AnoLancamento).FirstOrDefault();
            if (carroList != null)
            {
                ListaCarroDto carro = new ListaCarroDto
                {
                    Placa = carroList.Placa,
                    Ano = carroList.AnoLancamento.Ano.ToString("yyyy"),
                    NomeModelo = carroList.Modelo.NomeModelo,
                    PathFoto = carroList.Fotos.Select(x => x.Path).ToList()
                };
                var carroAcessorio = _db.CarroAcessorios.Where(x => x.CodigoCarro == carroList.Id).Include(x => x.Acessorio).ToList();
                carro.Acessorios = carroAcessorio.Select(x => x.Acessorio.NomeAcessorio).ToList();
                return carro;
            }
            return null;
        }
        public void CreateCarro(Carro carro)
        {
            _db.Carros.Add(carro);
            _db.SaveChanges();
        } 
        public void UpdateCarro(Carro carro)
        {
            Carro car = _db.Carros.Where(x => x.Id == carro.Id).FirstOrDefault();
            if (car != null)
            {
                car.Placa = carro.Placa;
                car.CodigoModelo = carro.CodigoAno;
                car.CodigoModelo = carro.CodigoModelo;
                _db.Update(car);
                _db.SaveChanges();
            }
        }
        public void DeleteCarro(Carro carro)
        {
            Carro car = _db.Carros.Where(x => x.Id == carro.Id).FirstOrDefault();
            if (car != null)
            {
                foreach(var item in _db.Fotos.Where(x => x.CodigoCarro == carro.Id).ToList())
                {
                    _db.Remove(item);
                    _db.SaveChanges();
                }
                _db.Remove(car);
                _db.SaveChanges();
            }
        }
    }
}
