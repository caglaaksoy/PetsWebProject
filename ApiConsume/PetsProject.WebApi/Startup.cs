using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PetsProject.BusinessLayer.Abstract;
using PetsProject.BusinessLayer.Concrete;
using PetsProject.DataAccessLayer.Abstract;
using PetsProject.DataAccessLayer.Concrete;
using PetsProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.WebApi
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
            services.AddDbContext<Context>();

            //registerlar --> hafýzada bir kez nesne oluþtur ve onu kullan
            services.AddScoped<IStaffDal, EfStaffDal>();
            services.AddScoped<IStaffService, StaffManager>();

            services.AddScoped<IPetsDal, EfPetsDal>();
            services.AddScoped<IPetsService, PetsManager>();

            services.AddScoped<IOwnerDal, EfOwnerDal>();
            services.AddScoped<IOwnerService, OwnerManager>();

            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IShopProcessDal, EfShopProcessDal>();
            services.AddScoped<IShopProcessService, ShopProcessManager>();

            services.AddScoped<IBlogDal, EfBlogDal>();
            services.AddScoped<IBlogService, BlogManager>();

            services.AddScoped<IClientLogoDal, EfClientLogoDal>();
            services.AddScoped<IClientLogoService, ClientLogoManager>();

            services.AddScoped<IFooterDal, EfFooterDal>();
            services.AddScoped<IFooterService, FooterManager>();

            services.AddScoped<ITeamDal, EfTeamDal>();
            services.AddScoped<ITeamService, TeamManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IFoodDal, EfFoodDal>();
            services.AddScoped<IFoodService, FoodManager>();

            services.AddScoped<IPetTypeDal, EfPetTypeDal>();
            services.AddScoped<IPetTypeService, PetTypeManager>();

            services.AddScoped<IBreedDal, EfBreedDal>();
            services.AddScoped<IBreedService, BreedManager>();

            //api cors izinleri veriliyor

            services.AddCors(opt =>
            {
                opt.AddPolicy("PetsCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

            });




            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetsProject.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetsProject.WebApi v1"));
            

            //app.UseHttpsRedirection();

            app.UseRouting();

            //cors keyinin tanýmlýyoruz
            app.UseCors("PetsCors");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
