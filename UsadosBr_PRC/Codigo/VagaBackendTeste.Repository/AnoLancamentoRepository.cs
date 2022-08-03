using System;
using System.Collections.Generic;
using System.Linq; 
using VagaBackendTeste.Data;
using VagaBackendTeste.Domain.Entity;

namespace VagaBackendTeste.Repository
{
    public class AnoLancamentoRepository
    {
        private readonly VagaBackeneTesteContext _db;
        public AnoLancamentoRepository(VagaBackeneTesteContext context)
        {
            this._db = context;
        }
        public List<AnoLancamento> GetAnoLancamentos()
        {
            return _db.AnoLancamentos.ToList();
        }
        public AnoLancamento GetAnoLancamento(int id)
        {
            return _db.AnoLancamentos.Where(x => x.Id == id).FirstOrDefault();
        }
        public AnoLancamento GetAnoLancamento(string ano)
        {
            //return _db.AnoLancamentos.Where(x => x.Ano == ano).FirstOrDefault();
            return null;
        }
        public void CreateAnoLancamento(AnoLancamento ano)
        {
            _db.AnoLancamentos.Add(ano);
            _db.SaveChanges();
        }
        public void UpdateAnoLancamento(AnoLancamento ano)
        {
            AnoLancamento anoLancamento = _db.AnoLancamentos.Where(x => x.Id == ano.Id).FirstOrDefault();
            if (anoLancamento != null)
            {
                anoLancamento.Ano = ano.Ano;
                _db.Update(anoLancamento);
                _db.SaveChanges();
            }
        }
        public void DeleteAnoLancamento(AnoLancamento ano)
        {
            AnoLancamento anoLancamento = _db.AnoLancamentos.Where(x => x.Id == ano.Id).FirstOrDefault();
            if (anoLancamento != null)
            {
                _db.Remove(anoLancamento);
                _db.SaveChanges();
            }
        }
    }
}
