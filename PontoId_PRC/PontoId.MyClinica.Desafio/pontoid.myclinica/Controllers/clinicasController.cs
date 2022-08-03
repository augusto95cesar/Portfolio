using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using pontoid.myclinica.Models;

namespace pontoid.myclinica.Controllers
{
    public class clinicasController : Controller
    {
        private MyClinicaBdContext db = new MyClinicaBdContext();

       
        public async Task<ActionResult> Index()
        {
            return View(await db.clinicas.ToListAsync());
        }    

        public ActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NomeClinica,CNPJ,Telefone,Endereco,QtdDisponivel")] clinica clinica)
        {
            if (ModelState.IsValid)
            {
                db.clinicas.Add(clinica);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clinica);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinica clinica = await db.clinicas.FindAsync(id);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            return View(clinica);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NomeClinica,CNPJ,Telefone,Endereco,QtdDisponivel")] clinica clinica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clinica);
        }        
    }
}
