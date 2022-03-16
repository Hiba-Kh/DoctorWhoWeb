using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Db.Domain.Services;
using DoctorWho.Db.Repositories;
using DoctorWho.Domain;
using DoctorWho.Web.Controllers.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using DoctorWho.Web.Services;

namespace DoctorWho.Web
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
            services.AddControllers();
            services.AddDbContext<DoctorWhoCoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"))
                  .EnableSensitiveDataLogging();
            });
           
            services.AddScoped<IDoctorRepository, DoctorRepository>();
           
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICompanionRepository, CompanionRepository>();
            services.AddScoped<IEnemyRepository, EnemyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IEnemyService, EnemyService>();
            services.AddScoped<IEpisodeService, EpisodeService>();
            services.AddScoped<ICompanionService, CompanionService>();
            services.AddScoped<IAuthorService, AuthorService>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
