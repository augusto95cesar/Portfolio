using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using pontoid.myclinica.Models;

namespace pontoid.myclinica.Controllers
{
    public class conveniosController : Controller
    {
        private MyClinicaBdContext db = new MyClinicaBdContext();

        // GET: convenios
        public async Task<ActionResult> Index()
        {
            return View(await db.convenios.ToListAsync());
        }    

       
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NomeConvenio")] convenio convenio)
        {
            if (ModelState.IsValid)
            {
                db.convenios.Add(convenio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(convenio);
        }

        // GET: convenios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            convenio convenio = await db.convenios.FindAsync(id);
            if (convenio == null)
            {
                return HttpNotFound();
            }
            return View(convenio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NomeConvenio")] convenio convenio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(convenio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(convenio);
        }

        // GET: convenios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            convenio convenio = await db.convenios.FindAsync(id);
            if (convenio == null)
            {
                return HttpNotFound();
            }
            return View(convenio);
        }

        // POST: convenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            convenio convenio = await db.convenios.FindAsync(id);
            db.convenios.Remove(convenio);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }      
    }
}
