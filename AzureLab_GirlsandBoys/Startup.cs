using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureLab_GirlsandBoys.Models.Task;

namespace AzureLab_GirlsandBoys
{
    public class Startup
    {
        private IWebHostEnvironment _env;
        public Startup(IWebHostEnvironment env)
        {
            //Configuration = configuration;
            _env = env;
        }
        //Switching Services depending on the Environnement Variable
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            if (_env.IsDevelopment())
            {
                services.AddTransient<ITaskService, TeacherTaskService>();
            }
            else
            {
                services.AddTransient<ITaskService, StudentTaskService>();
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /**
        * HERE, WE ARE DEFINING AND EXPOSING THE ENDPOINTS FOR THE AREAS(BOYS, GIRLS, AND TEACHERS)
        */
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
                //This endpoint is for the boys and redirects to the boys Area
                //with the areaName and to the homeController/index and the only view available is index no idea needed
                endpoints.MapAreaControllerRoute(
                    name: "boys",
                    areaName: "Boys",
                    pattern: "Boys/{controller=Home}/{action=Index}/{id?}");

                //This endpoint is for the girls and redirects to the girls Area
                //with the areaName and to the homeController/index and the only view available is index no idea needed
                endpoints.MapAreaControllerRoute(
                    name: "girls",
                    areaName:"Girls",
                    pattern: "Girls/{controller=Home}/{action=Index}/{id?}");

                //This endpoint is for the teachers and redirects to the teachers Area
                //with the areaName and to the homeController/index and the only view available is index no idea needed
                endpoints.MapAreaControllerRoute(
                    name: "teachers",
                    areaName: "Teachers",
                    pattern: "Teachers/{controller=Home}/{action=Index}/{id?}");

                //This endpoint is for the default area, it redirects to the home page.
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
               
            });
        }
    }
}
