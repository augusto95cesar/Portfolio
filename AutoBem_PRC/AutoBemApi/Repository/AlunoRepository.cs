using AutoBemApi.Context;
using AutoBemApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace AutoBemApi.Repository
{
    public class AlunoRepository
    {
        private readonly AutoBemContext _db;

        public AlunoRepository(AutoBemContext context)
        {
            this._db = context;
        }
        public void CadastrarAluno(Aluno aluno)
        {
            _db.Alunos.Add(aluno);
            _db.SaveChanges();
        }
        public void AtualizarAluno(Aluno aluno)
        {
            var alunoExiste = _db.Alunos.Where(x => x.Id == aluno.Id).FirstOrDefault();
            if (alunoExiste != null)
            {
                alunoExiste.Nome = aluno.Nome; 
                
                _db.Alunos.Update(alunoExiste);
                // _db.Entry(escolaExiste).State = System.Data.Entity.EntityState.Modified; ;
                _db.SaveChanges();
            }
        }
        public void DeletarAluno(int id)
        {
            var alunoExiste = _db.Alunos.Where(x => x.Id == id).FirstOrDefault();
            if (alunoExiste != null)
            {
                _db.Remove(alunoExiste);
                _db.SaveChanges();
            }
        }
        public List<Aluno> BuscarAluno()
        {
            return _db.Alunos.ToList();
        }
        public Aluno BuscarAlunoId(int id)
        {
            return _db.Alunos.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
