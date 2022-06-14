using GarsonApp.Business.Concrete;
using GarsonApp.Services.Catalog.Abstract;
using GarsonApp.Services.Catalog.Abstract.Dal;
using GarsonApp.Services.Catalog.Abstract.Repositories;
using GarsonApp.Services.Catalog.Abstract.Services;
using GarsonApp.Services.Catalog.Business;
using GarsonApp.Services.Catalog.Core;
using GarsonApp.Services.Catalog.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTYS_PROJE.Business.Concrete;

namespace GarsonApp.Services.Catalog
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
            services.AddSingleton<ISubCategoryService, SubCategoryService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IRestourantService, RestourantService>();

            services.AddSingleton<ICategoryDal, CategoryDal>();
            services.AddSingleton<ISubCategoryDal, SubCategoryDal>();
            services.AddSingleton<IProductDal, ProductDal>();
            services.AddSingleton<IRestourantDal, RestourantDal>();

            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ISubCategoryRepository, SubCategoryRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IRestourantRepository, RestourantRepository>();


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GarsonApp.Services.Catalog", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GarsonApp.Services.Catalog v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
