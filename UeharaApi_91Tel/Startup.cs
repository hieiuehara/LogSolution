using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UeharaApi_91Tel.EntityFramework;
using UeharaApi_91Tel.Repositories;
using UeharaApi_91Tel.Service;
using UeharaApi_91Tel.Controllers;
using System;
using RestSharp;

namespace UeharaApi_91Tel
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IServiceProvider, ServiceProvider>();
            services.AddTransient<ILogResponseRepository, LogResponseRepository>();
            services.AddSingleton<IClientApi91>(new ClientApi91(new Uri(@"http://integracao.epbx.com.br:5050")));
            services.AddDbContext<LogResponseDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(options =>
            options.AddPolicy("AllowSpecific", p => p.WithOrigins("http://localhost:4200")
                              .WithMethods("GET")));
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
            app.UseCors("AllowSpecific");
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
