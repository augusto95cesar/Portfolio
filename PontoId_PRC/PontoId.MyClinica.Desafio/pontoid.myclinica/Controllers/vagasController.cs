using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using pontoid.myclinica.Models;
using pontoid.myclinica.Models.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using pontoid.myclinica.Models.ViewModel;

namespace pontoid.myclinica.Controllers
{
    public class vagasController : Controller
    {
        private MyClinicaBdContext db = new MyClinicaBdContext();

        // GET: vagas
        public  ActionResult Index()
        {
            var vagasAtendimento =  db.VagasAtendimento.Include(y => y.clinica).OrderBy(y => y.DataConsulta).OrderBy(x => x.clinica.NomeClinica).ToList();

            List<VagasViewModel> lista = new List<VagasViewModel>();

            foreach (var item in vagasAtendimento)
            {
                VagasViewModel vaga = new VagasViewModel();
                vaga.Id = item.Id;
                vaga.DataString = item.DataConsulta.ToString("dd/MM/yyyy");
                vaga.HoraString = item.Horas.ToString("hh:mm");
                vaga.DateTimeDisponivel = item.DateTimeDisponivel;
                vaga.ClinicaId = item.ClinicaId;
                vaga.NomeClinica = db.clinicas.Where(x => x.Id == item.ClinicaId).First().NomeClinica;
                lista.Add(vaga);              
            }


            ViewBag.ListaVagas = lista;
            ViewBag.ListaClinica = new SelectList(db.clinicas.ToList(),"Id", "NomeClinica");
            return View();
        }

        [HttpGet]
        public  JsonResult IndexList(int idclinica, DateTime dataInicio, DateTime dataFim)
        {
            var vagasAtendimento = db.VagasAtendimento.Where(x => x.DataConsulta >= dataInicio && x.DataConsulta <= dataFim && x.ClinicaId == idclinica).ToList();
            if (vagasAtendimento.Count != 0)
            {

                List<VagasViewModel> lista = new List<VagasViewModel>();

                foreach (var item in vagasAtendimento)
                {
                    VagasViewModel vaga = new VagasViewModel();
                    vaga.Id = item.Id;
                    vaga.DataString = item.DataConsulta.ToString("dd/MM/yyyy");
                    vaga.HoraString = item.Horas.ToString("hh:mm");
                    vaga.DateTimeDisponivel = item.DateTimeDisponivel;
                    vaga.ClinicaId = item.ClinicaId;
                    vaga.NomeClinica = db.clinicas.Where(x => x.Id == item.ClinicaId).First().NomeClinica;
                    lista.Add(vaga);
                }                
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: vagas/Create
        public ActionResult Create()
        {
            ViewBag.ClinicaId = new SelectList(db.clinicas, "Id", "NomeClinica");
            return View();
        }
        // GET: vagas/Create
        public ActionResult ErroAction()
        {
            ViewBag.ClinicaId = new SelectList(db.clinicas, "Id", "NomeClinica");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DataConsulta,Horas,DateTimeDisponivel,ClinicaId")] vagasAtendimento vagas)
        {
            if (ModelState.IsValid)
            {
                List<vagasAtendimento> ListarVagas = db.VagasAtendimento.Where(x => x.DataConsulta == vagas.DataConsulta).ToList();
                if(ListarVagas.Count == 20)
                {
                   
                    return RedirectToAction("ErroAction");
                }
                else
                {
                    db.VagasAtendimento.Add(vagas);
                    await db.SaveChangesAsync();                    
                    return RedirectToAction("Index");
                }    
            }

            ViewBag.ClinicaId = new SelectList(db.clinicas, "Id", "NomeClinica", vagas.ClinicaId);
            return View(vagas);
        }

        // GET: vagas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vagasAtendimento vagasAtendimento = await db.VagasAtendimento.FindAsync(id);
            if (vagasAtendimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClinicaId = new SelectList(db.clinicas, "Id", "NomeClinica", vagasAtendimento.ClinicaId);
            return View(vagasAtendimento);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( vagasAtendimento vagasAtendimento)
        {
            if (ModelState.IsValid)
            {                
                db.Entry(vagasAtendimento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClinicaId = new SelectList(db.clinicas, "Id", "NomeClinica", vagasAtendimento.ClinicaId);
            return View(vagasAtendimento);
        }
       
    }
}
