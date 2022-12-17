using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Civica.Core.EPortal.Web;
//using InterviewCode.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestMVC.AutoMapper;
using TestMVC.Filters;
using TestMVC.Services;
using WebAPI.Core.Common;

namespace TestMVC
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
            //IoC.Initialise(services, Configuration.GetValue<string>(GetWebServiceNameAWS()));
            IoC.Initialise(services, Configuration.GetValue<string>(GetWebServiceName()));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddControllersWithViews();
           
            //services.AddKendo();
            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie";
                     config.LoginPath = "/Login/UserLogin";
                 });

            services.AddControllersWithViews();
            //services.AddScoped<LogAttribute>();
            services.Configure<WebAPI.Core.Common.AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton(AutoMapperConfig.CreateMapperConfig());
            services.AddScoped<IDapper, Dapperr>();
            services.AddSession();
            services.AddScoped<CustomActionFilter>();


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
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthenticationMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //pattern: "{controller=Kendo}/{action=Slider}");
            });
            app.UseWelcomePage();
        }

        private string GetWebServiceName()
        {
            string webservice = "";

            //webservice = "AppSettings:CivicaCoreWebService";
            webservice = "AppSettings:CivicaCoreWebServiceSecure";

            return webservice;
        }

        private string GetWebServiceNameAWS()
        {
            string webservice = "";

            webservice = "AppSettings:CivicaCoreWebServiceAWS";

            return webservice;
        }
    }
}

