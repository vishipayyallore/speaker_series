using College.Microservice.BAL;
using College.Microservice.Common;
using College.Microservice.Persistence;
using College.Services.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace College.Microservice
{
    public class Startup
    {
        const string AllowSpecificOrigins = "onlyFromMyPC";
        const string LocalApplicationAddress = "https://localhost:44320";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins, builder => {
                    builder.WithOrigins(LocalApplicationAddress);
                });
            });

            services.AddControllers();

            // Adding EF Core
            var connectionString = Configuration[Constants.DataStore.SqlConnectionString];
            services.AddDbContext<CollegeDbContext>(o => o.UseSqlServer(connectionString));

            // Application Services
            services.AddScoped<ProfessorsBal>();
            services.AddScoped<ProfessorsDal>();

            // Adding Redis Cache 
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = Configuration[Constants.DataStore.RedisConnectionString];
                option.InstanceName = Constants.RedisCacheStore.InstanceName;
            });
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

            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
