using PontoIdApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace PontoIdApi.Context.ServiceContext
{
    public class AlunoServiceContext
    {
        private readonly PontoIdContext _db;

        public AlunoServiceContext(PontoIdContext context)
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
                alunoExiste.Cpf = aluno.Cpf; 
                alunoExiste.DataNascimento = aluno.DataNascimento; 
                alunoExiste.CodTurma = aluno.CodTurma; 
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
