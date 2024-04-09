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

        //public Startup(IWebHostEnvironment env)
        //{
        //    ConfigurationBuilder builder = new ConfigurationBuilder();
        //    // builder.SetBasePath(env.ContentRootPath);
        //    // builder.AddJsonFile("appsettings.json");
        //    IConfigurationRoot config = builder.Build();
        //    AppSettings.ConnectionString = config["Data:DefaultConnection:ConnectionString"];
        //}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AppSettings.ConnectionString = configuration["Data:DefaultConnection:ConnectionString"];

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(opt => opt.EnableEndpointRouting = false);
            services.AddControllersWithViews();


            //services.AddEntityFrameworkSqlServer();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

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
