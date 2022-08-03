
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Funcionarios_Ambev.Models;

namespace Funcionarios_Ambev.Controllers
{
    public class FuncionariosController : Controller
    {
        private Sql_AmbevContext db = new Sql_AmbevContext();
        
        public ActionResult Index()
        {
            return View(db.Funcionarios.ToList());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarCadastro([Bind(Include = "ID,Nome,Idade")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        
        public ActionResult Editar(int? id)
        {           
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarEdicao([Bind(Include = "ID,Nome,Idade")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

       
        public ActionResult Deletar(int? id)
        {           
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        
        [HttpPost, ActionName("DeletarFuncionario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarFuncionario(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
