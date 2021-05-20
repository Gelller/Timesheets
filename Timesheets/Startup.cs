using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Domain.Implementation;
using AutoMapper;
using Timesheets.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore.Design;


namespace Timesheets
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
            services.AddSwaggerGen();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddScoped<IUsersManager, UsersManager>();
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);        
            services.AddDbContext<TimesheetDbContext>(options =>
             options.UseNpgsql(Configuration.GetConnectionString("PostgreConnectionString")));         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API сервис");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });         
        }
    }
}
