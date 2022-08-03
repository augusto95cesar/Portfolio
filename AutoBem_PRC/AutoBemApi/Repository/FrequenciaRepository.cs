using AutoBemApi.Context; 
using AutoBemApi.Model; 
using System.Linq;

namespace AutoBemApi.Repository
{
    public class FrequenciaRepository
    {
        private readonly AutoBemContext _db;
        public FrequenciaRepository(AutoBemContext context)
        {
            this._db = context;
        }

        public object obterFrequeciaAlunos(int idTurma)
        {
            return (from turma in _db.Turmas
                    join alunos in _db.Alunos on turma.Id equals alunos.TurmaId
                    join freq in _db.Frequencias on alunos.Id equals freq.AlunoId
                    where turma.Id == idTurma
                    select new
                    {
                        turma = turma.Nome,
                        nome = alunos.Nome,
                        data = freq.Chamada,
                        preseca = freq.Presente
                    }).ToList();
        }

        public void registrarFrequecia(Frequencia freq)
        { 
            _db.Frequencias.Add(freq);
            _db.SaveChanges(); 
        }

        public void alterarFrequencia(Frequencia freq)
        {
            var item = _db.Frequencias.Where(x => x.Id == freq.Id).FirstOrDefault();
            if (item != null)
            {
                item.Chamada = freq.Chamada;
                item.Presente = freq.Presente;
                _db.Frequencias.Update(item);
                _db.SaveChanges();
            }
        }

        public void deletarFrequenciaId(int id)
        {
            var item = _db.Frequencias.Where(x => x.Id == id).FirstOrDefault();
            if (item != null)
            {
                _db.Remove(item);
                _db.SaveChanges();
            }
        }
    }
}
