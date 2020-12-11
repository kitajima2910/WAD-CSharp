using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pretest02.Repositories;
using pretest02.Services;

namespace pretest02
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
            string strConnection = "Data Source=.\\sqlexpress;Initial Catalog=SaleManeger;User ID=sa;Password=848028;Pooling=False";
            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(strConnection));

            //services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=SaleManeger;User ID=sa;Password=848028;Pooling=False"));

            // Interface, Implement
            //services.AddScoped<IEmployeesServices, EmployeesServicesImpl>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employees}/{action=ViewEmployeeList}/{id?}");
            });
        }
    }
}
