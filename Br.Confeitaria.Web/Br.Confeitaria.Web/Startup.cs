using Br.Confeitaria.Web.Models.Database;
using Br.Confeitaria.Web.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Br.Confeitaria.Web
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

            var connection = Configuration.GetConnectionString("AzureMySqlConnection");

            services.AddDbContext<ClassDBContext>(options => options.UseMySQL(connection));
            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Admin/Login/Index";
                options.AccessDeniedPath = "/Admin/Login/Index";
            });

       
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/Login/Index");
                options.AccessDeniedPath = new PathString("/Admin/Login/Index");
                options.LogoutPath = new PathString("/Admin/Login/Logout");
            });

            services.AddScoped<AjudaRepository>();
            services.AddScoped<BannersRepository>();
            services.AddScoped<ClientesRepository>();
            services.AddScoped<ContatoRepository>();
            services.AddScoped<CorRepository>();
            services.AddScoped<ModuloRepository>();
            services.AddScoped<NewslatterRepository>();
            services.AddScoped<NivelUsuarioRepository>();
            services.AddScoped<PermissoesRepository>();
            services.AddScoped<PhotoRepository>();
            services.AddScoped<ProdutoDetalheRepository>();
            services.AddScoped<ProdutoRepository>();
            services.AddScoped<TamanhoRepository>();
            services.AddScoped<TipoRepository>();
            services.AddScoped<UsuariosRepository>();
            services.AddScoped<CarrinhoRepository>();
            services.AddScoped<PedidoRepository>();
            services.AddScoped<ItemPedidoRepository>();
            services.AddScoped<PaymentRepository>();
            services.AddScoped<StatusRepository>();
            services.AddScoped<OrcamentoRepository>();
            services.AddScoped<SuporteRepository>();
            services.AddScoped<SalesRepository>();
            services.AddScoped<VagasRepository>();
            services.AddScoped<CandidaturasRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
