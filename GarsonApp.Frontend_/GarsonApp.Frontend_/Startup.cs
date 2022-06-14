using GarsonApp.Frontend.Services;
using GarsonApp.Frontend.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarsonApp.Frontend_
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
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddHttpClient<ICategoryService, CategoryService>();

            services.AddSingleton<IRestourantService, RestourantService>();
            services.AddHttpClient<IRestourantService, RestourantService>();

            services.AddHttpClient<IProductService, ProductService>();
            services.AddHttpClient<IProductService, ProductService>();

            services.AddHttpClient<IBasketService, BasketService>();
            services.AddHttpClient<IBasketService, BasketService>();

            services.AddHttpClient<IAccountService, AccountService>();
            services.AddHttpClient<IAccountService, AccountService>();

            services.AddControllersWithViews();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login";
                });
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
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
