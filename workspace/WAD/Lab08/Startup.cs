using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab08.Repositories;
using Lab08.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab08
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

            // Connection
            string strConnection = "Data Source=.\\sqlexpress;Initial Catalog=Lab08DB;User ID=sa;Password=848028;Pooling=False";
            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(strConnection));

            // Interface, Implement
            services.AddScoped<ICountryServices, CountryServicesImpl>();
            services.AddScoped<ICityServices, CityServicesImpl>();
            services.AddScoped<ICountryCityServices, CountryCityServiceImpl>();

            services.AddSession();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
