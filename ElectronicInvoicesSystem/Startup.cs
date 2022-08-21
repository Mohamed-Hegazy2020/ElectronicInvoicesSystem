using ElectronicInvoicesSystem.Data;
using ElectronicInvoicesSystem.Servcies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<DatabaseContext>(item => item.UseSqlServer(Configuration.GetConnectionString("conStr")));
            services.AddSingleton<IWorker, Worker>();
            services.AddIdentity<IdentityUser, IdentityRole>(
           options => {            
               options.SignIn.RequireConfirmedAccount = false;
               options.Password.RequireDigit = false;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireUppercase = false;
               options.Password.RequiredLength = 4;

               //Other options go here
           }
       ).AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            
            app.UseAuthentication();
            app.UseRouting(); 
            app.UseAuthorization(); 
                
            RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
