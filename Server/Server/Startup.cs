using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Server.Contracts;
using Server.Service;
using FluentValidation.AspNetCore;

namespace Server
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
            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Server=USER-PC;Database=Selection;Trusted_Connection=True;"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fvc =>
                fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<IVacancyService, VacancySecrvice>();
            services.AddScoped<ILastWorkService, LastWorkService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IResultService, ResultService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
