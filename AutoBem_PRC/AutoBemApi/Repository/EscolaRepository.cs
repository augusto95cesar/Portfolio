using AutoBemApi.Context;
using AutoBemApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; 
using System.Collections.Generic;
using System.Linq;

namespace AutoBemApi.Repository
{
    public class EscolaRepository
    {
        private readonly AutoBemContext _db; 

        public EscolaRepository(AutoBemContext context)
        {
            this._db = context; 
        }

        public void CadastrarEscola(Escola escola)
        {
            _db.Escolas.Add(escola);
            _db.SaveChanges();
        }
        public void AtualizarEscola(Escola escola, int id)
        {
            var escolaExiste = _db.Escolas.Where(x => x.Id == id).FirstOrDefault();
            if(escolaExiste != null)
            {
                escolaExiste.Nome = escola.Nome; 
                _db.Escolas.Update(escolaExiste);
               // _db.Entry(escolaExiste).State = System.Data.Entity.EntityState.Modified; ;
                _db.SaveChanges();
            }
        }
        public void DeletarEscola(int id)
        {
            var escolaExiste = _db.Escolas.Where(x => x.Id == id).FirstOrDefault();
            if (escolaExiste != null)
            {
                foreach (var turma in _db.Turmas.Where(x => x.EscolaId == escolaExiste.Id).ToList())
                {
                    foreach (var aluno in _db.Alunos.Where(x => x.TurmaId == turma.Id).ToList())
                    {
                        _db.Remove(aluno);
                        _db.SaveChanges();
                    }
                    _db.Remove(turma);
                    _db.SaveChanges();
                }

                _db.Remove(escolaExiste);
                _db.SaveChanges();
            }
        }
        public List<Escola> BuscarEscola()
        {
            return _db.Escolas.ToList();
        }
        public Escola BuscarEscolaId(int id)
        {
            return _db.Escolas.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
