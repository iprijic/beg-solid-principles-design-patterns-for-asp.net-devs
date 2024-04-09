using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


using SRP.Core;
using Microsoft.Extensions.Hosting;

namespace SRP
{
    public class Startup
    {

        public Startup(IWebHostEnvironment env)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            AppSettings.ConnectionString = config["Data:DefaultConnection:ConnectionString"];
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(opt => opt.EnableEndpointRouting = false);
            services.AddControllersWithViews();


            services.AddEntityFrameworkSqlServer();
        }

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

            //app.UseMvc(routes =>
            app.UseEndpoints(routes =>
            {
            // routes.MapRoute(
            routes.MapControllerRoute(
                 name: "default",
                    //template: "{controller=Home}/{action=Index}/{id?}");
                  pattern: "{controller=Home}/{action=Index}/{id?}");
        });
        }
    }
}
