using PontoIdApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace PontoIdApi.Context.ServiceContext
{
    public class TurmaServiceContext
    {
        private readonly PontoIdContext _db;
        public TurmaServiceContext(PontoIdContext context)
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
                turmaExiste.Descricao = turma.Descricao;
                turmaExiste.Serie = turma.Serie;
                turmaExiste.Turno = turma.Turno;
                turmaExiste.CodEscola = turma.CodEscola;
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
                foreach (var aluno in _db.Alunos.Where(x => x.CodTurma == turmaExiste.Id).ToList())
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
