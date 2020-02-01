using College.Api.BAL;
using College.Api.Common;
using College.Api.HealthChecks;
using College.Api.Persistence;
using College.Api.RPCServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace College.Api
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

            _ = services.AddHealthChecks()
                .AddCheck<SimpleHealthCheck>("A Simple Web API Health Check");

            services.AddGrpc();

            // Adding EF Core
            var connectionString = Configuration[Constants.ConnectionString];
            services.AddDbContext<CollegeDbContext>(o => o.UseSqlServer(connectionString));

            // Application Services
            //TODO: THIS SHOULD BE DONE USING INTERFACES
            services.AddScoped<ProfessorsBal>();
            services.AddScoped<ProfessorsDal>();
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
                endpoints.MapGrpcService<CollegeGrpcService>();

                endpoints.MapControllers();

                endpoints.MapHealthChecks("/api/health");
            });
        }
    }
}
