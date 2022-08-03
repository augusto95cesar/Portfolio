using MaximaCRUD.Application.Implementacao;
using MaximaCRUD.Application.Interface;
using MaximaCRUD.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using Microsoft.IdentityModel.Tokens; 
using System.Text; 

namespace MaximaCRUD.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
         
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(
               x => x.UseNpgsql(Configuration.GetConnectionString("DataApiConnection").ToString(),
               op => op.MigrationsAssembly("MaximaCRUD.UI")));

            //Auth Config 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("MaximaCRUD Melhor Empresa 2020")),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });

            //Inject
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IProdutoApplication, ProdutoApplication>();
            services.AddScoped<IDepartamentoApplication, DepartamentoApplication>();
            services.AddScoped<IAuthApplication, AuthApplication>();

            var politicaAutorizacao = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            services.AddControllers(option =>
                    option.Filters.Add(new AuthorizeFilter(politicaAutorizacao))
            );
            //services.AddControllers();            
        } 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
