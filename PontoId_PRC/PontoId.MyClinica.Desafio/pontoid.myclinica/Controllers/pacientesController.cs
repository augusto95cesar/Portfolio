using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pontoid.myclinica.Models;

namespace pontoid.myclinica.Controllers
{
    public class pacientesController : Controller
    {
        private MyClinicaBdContext db = new MyClinicaBdContext();

        // GET: pacientes
        public async Task<ActionResult> Index()
        {
            return View(await db.pacientes.ToListAsync());
        }

       

        // GET: pacientes/Create
        public ActionResult Create()
        {
            return View();
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NomePaciente,Telefone,CPF,Email")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.pacientes.Add(paciente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: pacientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = await db.pacientes.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NomePaciente,Telefone,CPF,Email")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: pacientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = await db.pacientes.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            paciente paciente = await db.pacientes.FindAsync(id);
            db.pacientes.Remove(paciente);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        } 
    }
}
