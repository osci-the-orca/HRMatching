using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain;
using Infrastructure;
using Common.Interfaces;

namespace Presentation
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
            services.AddControllersWithViews();

            TempConsoleUI tempConsoleUI = new();
            tempConsoleUI.FransRun();
            tempConsoleUI.CarlRun();

            //Ger Presentation global access b�de IDataAccess och ICalculator
            services.AddScoped<IDataAccessCommands, DataAccessCommands>();
            services.AddScoped<IDataAccessQuerys, DataAccessQuerys>();

            //Vi m�ste l�gga till dessa f�rst, s� att ASP.NET vet att hon skall skicka in dessa n�r hon skapar en Caclulator
            services.AddScoped<CheckExperience>();
            services.AddScoped<CheckSector>();
            services.AddScoped<CheckLicense>();
            services.AddScoped<ICalculator, Calculator>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
