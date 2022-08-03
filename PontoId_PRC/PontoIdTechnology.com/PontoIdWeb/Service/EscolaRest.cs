using Microsoft.Extensions.Configuration;
using PontoIdWeb.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PontoIdWeb.Service
{
    public class EscolaRest
    {
        private readonly IConfiguration _config;

        public EscolaRest(IConfiguration configuration)
        {
            this._config = configuration;
        }
        public RestResult obterEscolas()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_config.GetConnectionString("UrlPontoIdApi").ToString() + "/Escola");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resposta = Task.Run(async () => await client.GetAsync("")).GetAwaiter().GetResult();
            var dados = Task.Run(async () => await resposta.Content.ReadAsStringAsync()).GetAwaiter().GetResult();
            return new RestResult { DadosResut = dados, StatusCodeResult = resposta.StatusCode };
        }
    }
}
