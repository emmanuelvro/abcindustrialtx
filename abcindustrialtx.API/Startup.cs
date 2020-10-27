using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using abcindustrialtx.Business.Implements;
using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.DAO.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace abcindustrialtx.API
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

            services.AddDbContext<AbcIndustrialDbContext>(option =>
            {
                option.UseMySQL(Configuration.GetConnectionString("DefaultConnection"),
                    assambly => assambly.MigrationsAssembly("abcindustrialtx.API"));
            });

            services.AddTransient<ICatColoresDAO, CatColoresRepository>();
            services.AddTransient<ICatColores, CatColores>();
            services.AddControllers();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
