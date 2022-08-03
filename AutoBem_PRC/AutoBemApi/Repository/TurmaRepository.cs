using AutoBemApi.Context;
using AutoBemApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace AutoBemApi.Repository
{
    public class TurmaRepository
    {
        private readonly AutoBemContext _db;
        public TurmaRepository(AutoBemContext context)
        {
            this._db = context;
        }
        public void CadastrarTurma(Turma turma)
        {
            _db.Turmas.Add(turma);
            _db.SaveChanges();
        }
        public void AtualizarTurma(Turma turma)
        {
            var turmaExiste = _db.Turmas.Where(x => x.Id == turma.Id).FirstOrDefault();
            if (turmaExiste != null)
            {
                turmaExiste.Nome = turma.Nome;
                turmaExiste.EscolaId = turma.EscolaId; 
                _db.Turmas.Update(turmaExiste);
                // _db.Entry(escolaExiste).State = System.Data.Entity.EntityState.Modified; ;
                _db.SaveChanges();
            }
        }
        public void DeletarTurma(int id)
        {
            var turmaExiste = _db.Turmas.Where(x => x.Id == id).FirstOrDefault();
            if (turmaExiste != null)
            {
                foreach (var aluno in _db.Alunos.Where(x => x.TurmaId == turmaExiste.Id).ToList())
                {
                    _db.Remove(aluno);
                    _db.SaveChanges();
                }
                _db.Remove(turmaExiste);
                _db.SaveChanges();
            }
        }
        public List<Turma> BuscarTuma()
        {
            return _db.Turmas.ToList();
        }
        public Turma BuscarTurmaId(int id)
        {
            return _db.Turmas.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
