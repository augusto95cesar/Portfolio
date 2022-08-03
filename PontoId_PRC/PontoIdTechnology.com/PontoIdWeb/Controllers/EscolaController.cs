using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PontoIdWeb.Models;
using PontoIdWeb.ModelView;
using PontoIdWeb.Service;
using System.Collections.Generic;

namespace PontoIdWeb.Controllers
{
    public class EscolaController : Controller
    {
        public EscolaRest _serviceEscola { get; }
        public EscolaController(IConfiguration configuration)
        {
            _serviceEscola = new EscolaRest(configuration);
        }
        public IActionResult Index() 
        {            
            var resultObterEscola = _serviceEscola.obterEscolas();
            if(resultObterEscola.StatusCodeResult == HttpStatusCode.OK)
            {
                List<EscolaView> listaEscola = JsonSerializer.Deserialize<List<EscolaView>>(resultObterEscola.DadosResut.ToString()); 
                return View(listaEscola);
            }
            return RedirectToAction("Error");
        }

        public IActionResult CadastrarEditar(int? id)       
        {
            ViewBag.Teste = id;
            return View();
        }

        public IActionResult DeletarEscola(int? id)
        {             
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
