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
using pontoid.myclinica.Models.ViewModel;
using pontoid.myclinica.Models.Entity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace pontoid.myclinica.Controllers
{
    public class AgendamentoConsultasController : Controller
    {
        private MyClinicaBdContext db = new MyClinicaBdContext();

        [HttpPost]
        public JsonResult CadastrarAgendamento(int idPaciente, int idVaga)
        {
            paciente PacienteCadastro = db.pacientes.FirstOrDefault(x => x.Id == idPaciente);
            vagasAtendimento VagaCadastro = db.VagasAtendimento.FirstOrDefault(x => x.Id == idVaga);

            agendamento Agendar = new agendamento();

            Agendar.Paciente = PacienteCadastro;
            Agendar.VagasAtendimento = VagaCadastro;
            Agendar.VagasAtendimento.DateTimeDisponivel = false;

            db.agendamentos.Add(Agendar);
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);            
        }


        [HttpPost]
        public JsonResult CadastrarPaciente(string nomepaciente, string telefone, string email, string cpf, int? matricula, int?cod)
        {
            paciente paciente = new paciente();
            paciente.NomePaciente = nomepaciente;
            paciente.Telefone = telefone;
            paciente.Email = email;
            paciente.CPF = cpf;
            paciente.Matricula = matricula;
            if (matricula != null)
                paciente.ConvenioId = cod;
            else
                paciente.ConvenioId = null;
            try
            {
                db.pacientes.Add(paciente);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(e.Data, JsonRequestBehavior.AllowGet);
            }
            return Json(db.pacientes.Where(x => x.CPF == cpf).FirstOrDefault(), JsonRequestBehavior.AllowGet);           
        }

        [HttpGet]
        public JsonResult ListarDatas(int idClinca,int idPaciente)
        {
            List<vagasAtendimento> Datas = db.VagasAtendimento
                .Where(x => x.ClinicaId == idClinca && x.DateTimeDisponivel == true)
                .ToList();

            if (Datas.Count != 0)
            {
                List<vagasAtendimento> DatasGroup = new List<vagasAtendimento>();
                List<Object> resultado = new List<object>();
                foreach (var item in Datas)
                {
                    List<agendamento> vagas = db.agendamentos
                                                .Where(x => x.VagasAtendimento.ClinicaId == idClinca
                                                && x.VagasAtendimento.DataConsulta == item.DataConsulta
                                                && x.Paciente.Id == idPaciente)
                                                .ToList();
                    if (vagas.Count == 0)
                    {
                        DatasGroup.Add(item);
                    }
                }

                var agupado = from datasss in DatasGroup
                              group datasss by datasss.DataConsulta into ttt
                              select ttt.Key;

                foreach (var item in agupado)
                {
                    resultado.Add(new
                    {
                        dataConsulta = item.ToString("dd/MM/yyyy")
                    });
                }
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ListarHora(int idClinca, int idPaciente, string idData)
        {
            DateTime parsedDate = DateTime.Parse(idData);
            var data =   Convert.ToDateTime(idData);
            List<vagasAtendimento> Datas = db.VagasAtendimento
                .Where(x => x.ClinicaId == idClinca && x.DateTimeDisponivel == true && x.DataConsulta == parsedDate)
                .ToList();
           
            List<Object> resultado = new List<object>();
            foreach (var item in Datas)
            {
                List<agendamento> vagas = db.agendamentos
                                            .Where(x => x.VagasAtendimento.ClinicaId == idClinca
                                            && x.VagasAtendimento.DataConsulta == item.DataConsulta
                                            && x.Paciente.Id == idPaciente)
                                            .ToList();
                if (vagas.Count == 0)
                {
                    resultado.Add(new
                    {
                        id = item.Id,
                        horas = item.Horas.ToString("hh:mm")                        
                    });
                }
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);           
        }

        [HttpGet]
        public JsonResult ListaPaciente(string idCpf)
        {
            if (db.pacientes.Where(x => x.CPF == idCpf).FirstOrDefault() == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                paciente IPaciente = db.pacientes.Where(x => x.CPF == idCpf).FirstOrDefault();
                if (IPaciente != null)
                {
                    convenio IConvenio = db.convenios.Where(x => x.Id == IPaciente.ConvenioId).FirstOrDefault();
                    if (IConvenio != null)
                    {
                        Object resultado = new
                        {
                            id = IPaciente.Id,
                            nome = IPaciente.NomePaciente,
                            email = IPaciente.Email,
                            telefone = IPaciente.Telefone,
                            matricula = IPaciente.Matricula,
                            cpf = IPaciente.CPF,
                            nomeconvenio = IConvenio.NomeConvenio,
                            idcovenio = IPaciente.ConvenioId
                        };
                        return Json(resultado, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Object resultado = new
                        {
                            id = IPaciente.Id,
                            nome = IPaciente.NomePaciente,
                            email = IPaciente.Email,
                            telefone = IPaciente.Telefone,
                            matricula = false,
                            cpf = IPaciente.CPF,
                            nomeconvenio = false,
                            idcovenio = false
                        };
                        return Json(resultado, JsonRequestBehavior.AllowGet);
                    }                    
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }           
        }

        [HttpGet]
        public JsonResult ListarConvenio(int? idConvenio)
        {
            if (db.convenios.Where(x => x.Id == idConvenio).FirstOrDefault() == null)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
                return Json(db.convenios.Where(x => x.Id == idConvenio).FirstOrDefault(), JsonRequestBehavior.AllowGet);            
        }

           

        [HttpGet]
        public ActionResult ListarAgendamento(DateTime dtInicio, DateTime dtfinal, int idStatus)        
        {           
            agendamento statusText = new agendamento();
            if (idStatus == 0)
                statusText.Status = status.AguardandoAtendimento;
            if (idStatus == 1)
                statusText.Status = status.Atendido;
            if (idStatus == 2)
                statusText.Status = status.NaoCompareceu;
            if (idStatus == 3)
                statusText.Status = status.CanceladoPeloUsuario;
            if (idStatus == 4)
                statusText.Status = status.CanceladoPelaClinica;

            List<agendamento> Agendamentos = db.agendamentos.Where(x => x.VagasAtendimento.DataConsulta >= dtInicio && x.VagasAtendimento.DataConsulta <= dtfinal && x.Status == statusText.Status).ToList();
            if (Agendamentos.Count != 0)
            {                
                List<ListaAgendamento> resultados = new List<ListaAgendamento>();
                List<Object> resultado = new List<Object>();

                foreach (var item in Agendamentos.OrderByDescending(y => y.Id))
                {
                    if (item.Paciente.ConvenioId == null)
                    {
                        ListaAgendamento agendar = new ListaAgendamento();
                        agendar.Id = item.Id;
                        agendar.clinica = item.VagasAtendimento.clinica.NomeClinica;
                        agendar.nomeCovenio = "Particular";
                        agendar.convenioId = item.Paciente.ConvenioId;
                        agendar.matricula = item.Paciente.Matricula;
                        agendar.status = item.Status;
                        agendar.nomePaciente = item.Paciente.NomePaciente;
                        agendar.cpf = item.Paciente.CPF;
                        agendar.email = item.Paciente.Email;
                        agendar.telefone = item.Paciente.Telefone;
                        agendar.dataMarcada = item.VagasAtendimento.DataConsulta.ToString("dd/MM/yyyy");
                        agendar.horaMarcada = item.VagasAtendimento.Horas.ToString("hh:mm");
                        resultados.Add(agendar);                       
                    }
                    else
                    {
                        var convenio = db.convenios.Where(x => x.Id == item.Paciente.ConvenioId).FirstOrDefault();
                        ListaAgendamento agendar = new ListaAgendamento();
                        agendar.Id = item.Id;
                        agendar.clinica = item.VagasAtendimento.clinica.NomeClinica;
                        agendar.nomeCovenio = convenio.NomeConvenio;
                        agendar.convenioId = item.Paciente.ConvenioId;
                        agendar.matricula = item.Paciente.Matricula;
                        agendar.status = item.Status;
                        agendar.nomePaciente = item.Paciente.NomePaciente;
                        agendar.cpf = item.Paciente.CPF;
                        agendar.email = item.Paciente.Email;
                        agendar.telefone = item.Paciente.Telefone;
                        agendar.dataMarcada = item.VagasAtendimento.DataConsulta.ToString("dd/MM/yyyy");
                        agendar.horaMarcada = item.VagasAtendimento.Horas.ToString("hh:mm");
                        resultados.Add(agendar);
                    }
                }

                ViewBag.Lista = resultados.OrderByDescending(y => y.Id);
                return Json(resultados, JsonRequestBehavior.AllowGet);              
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }




        // GET: AgendamentoConsultas
        public ActionResult Index()
        {
            List<agendamento> Agendamentos = new List<agendamento>();
            Agendamentos= db.agendamentos.ToList ();
            List<Object> resultado = new List<Object>();
            List<ListaAgendamento> resultados = new List<ListaAgendamento>();
            foreach (var item in Agendamentos)
            {
                if (item.Paciente.ConvenioId == null)
                {
                    ListaAgendamento agendar = new ListaAgendamento();
                    agendar.Id = item.Id;
                    agendar.clinica = item.VagasAtendimento.clinica.NomeClinica;
                    agendar.nomeCovenio = "Particular";
                    agendar.convenioId = item.Paciente.ConvenioId;
                    agendar.matricula = item.Paciente.Matricula;
                    agendar.status = item.Status;
                    agendar.nomePaciente = item.Paciente.NomePaciente;
                    agendar.cpf = item.Paciente.CPF;
                    agendar.email = item.Paciente.Email;
                    agendar.telefone = item.Paciente.Telefone;
                    agendar.dataMarcada = item.VagasAtendimento.DataConsulta.ToString("dd/MM/yyyy");
                    agendar.horaMarcada = item.VagasAtendimento.Horas.ToString("hh:mm");
                    resultados.Add(agendar);
                }
                else
                {
                    var convenio = db.convenios.Where(x => x.Id == item.Paciente.ConvenioId).FirstOrDefault();                   
                    ListaAgendamento agendar = new ListaAgendamento();
                    agendar.Id = item.Id;
                    agendar.clinica = item.VagasAtendimento.clinica.NomeClinica;
                    agendar.nomeCovenio = convenio.NomeConvenio;
                    agendar.convenioId = item.Paciente.ConvenioId;
                    agendar.matricula = item.Paciente.Matricula;
                    agendar.status = item.Status;
                    agendar.nomePaciente = item.Paciente.NomePaciente;
                    agendar.cpf = item.Paciente.CPF;
                    agendar.email = item.Paciente.Email;
                    agendar.telefone = item.Paciente.Telefone;
                    agendar.dataMarcada = item.VagasAtendimento.DataConsulta.ToString("dd/MM/yyyy");
                    agendar.horaMarcada = item.VagasAtendimento.Horas.ToString("hh:mm");
                    resultados.Add(agendar);
                }
            }

            ViewBag.Lista = resultados.OrderByDescending(y => y.Id);
            return View( );
        }
       

        // GET: AgendamentoConsultas/Create
        public ActionResult Create()
        {
            ViewBag.ClinicaId = new SelectList(db.clinicas.ToList(), "Id", "NomeClinica");
            ViewBag.ConvenioList = new SelectList(db.convenios.ToList(), "Id", "NomeConvenio");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DataAgendamento,ConvenioBool,Status,ConvenioId,ClinicaId,PacienteId")] agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.agendamentos.Add(agendamento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClinicaId = new SelectList(db.clinicas, "Id", "NomeClinica",agendamento);             
            return View(agendamento);
        }

        // GET: AgendamentoConsultas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agendamento item = await db.agendamentos.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            Agendamento agendar = new Agendamento();
            agendar.Id = item.Id;
            agendar.status = item.Status;
            return View(agendar);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<ActionResult> Edit([Bind(Include = "Id,Status")] agendamento StatusAgendamento)
        {
            if (ModelState.IsValid)
            {
                agendamento item = await db.agendamentos.FindAsync(StatusAgendamento.Id);
                item.Status = StatusAgendamento.Status;
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClinicaId = new SelectList(db.clinicas, "Id", "NomeClinica");
             return View(StatusAgendamento);
        }

        // GET: AgendamentoConsultas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agendamento agendamento = await db.agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        // POST: AgendamentoConsultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            agendamento agendamento = await db.agendamentos.FindAsync(id);
            db.agendamentos.Remove(agendamento);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
       
    }
}
