using CohesionApp.Api.Middleware;
using CohesionApp.Data;
using CohesionApp.Data.Entities;
using CohesionApp.Data.Enums;
using CohesionApp.Data.Repositories;
using CohesionApp.Domain.Interfaces;
using CohesionApp.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohesionApp.Domain.Mapper;

namespace CohesionApp.Api
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
            services.AddAutoMapper(typeof(RequestProfile));
            services.AddDbContext<MyDbContext>(options => options.UseInMemoryDatabase(databaseName: "ServiceRequests"));
            services.AddScoped<IServiceRequestRepository,ServiceRequestRepository>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeData(dbContext);
        }

        public static void InitializeData(MyDbContext dbContext)
        {
            if (dbContext.ServiceRequests.Any())
            {
                return;
            }

            dbContext.ServiceRequests.AddRange(
                new ServiceRequest()
                {
                    Id = Guid.Parse("0584ea2a-e90d-4ac3-8daa-66998d7df55b"),
                    BuildingCode = "COH",
                    Description = "Please turn up the AC in suite 1200D. It is too hot here.",
                    CurrentStatus = CurrentStatus.Created,
                    CreatedBy = "Noe",
                    CreatedDate = DateTime.Now
                },
                new ServiceRequest()
                {
                    Id = Guid.Parse("a6b36453-1f9e-4ea1-9b61-a5b3a4ecd199"),
                    BuildingCode = "AHQ",
                    Description = "The TV doesn't work in suite 1500C.",
                    CurrentStatus = CurrentStatus.Created,
                    CreatedBy = "Joe",
                    CreatedDate = DateTime.Now
                });

            dbContext.SaveChanges();
        }
    }
}
