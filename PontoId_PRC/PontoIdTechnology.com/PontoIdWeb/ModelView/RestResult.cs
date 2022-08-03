using System.Net;
namespace PontoIdWeb.ModelView
{
    public class RestResult
    { 
        public HttpStatusCode StatusCodeResult { get; set; }
        public object DadosResut { get; set; } 
    }
}
