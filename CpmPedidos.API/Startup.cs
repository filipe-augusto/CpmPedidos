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
using CpmPedidos.API;
using CpmPedidos.Repository;
using System.Data.Common;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public DbConnection Dbconnection =>
            new NpgsqlConnection(Configuration.GetConnectionString("App"));


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(
                    Dbconnection, assembly =>
                    assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });
            DependencyInjection.Register(services);
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
