using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VagaBackendTeste.Business;
using VagaBackendTeste.Data;
using VagaBackendTeste.Repository;

namespace VagaBackendTeste.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VagaBackeneTesteContext>(
                x => x.UseNpgsql(Configuration.GetConnectionString("DataApiConnection").ToString(),
                op => op.MigrationsAssembly("VagaBackendTeste.Application"))); 

            //Injeção de Dependencia
            services.AddScoped<VagaBackeneTesteContext, VagaBackeneTesteContext>();
            services.AddScoped<MarcaRepository, MarcaRepository>();
            services.AddScoped<ModeloRepository, ModeloRepository>();
            services.AddScoped<FotoRepository, FotoRepository>();
            services.AddScoped<CarroRepository, CarroRepository>();
            services.AddScoped<AnoLancamentoRepository, AnoLancamentoRepository>();
            services.AddScoped<AcessorioRepository, AcessorioRepository>(); 
            services.AddScoped<MarcaCarroBusiness, MarcaCarroBusiness>(); 
            services.AddScoped<CarroAcessorioRepository, CarroAcessorioRepository>(); 

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
