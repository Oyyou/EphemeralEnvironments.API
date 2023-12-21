using EphemeralEnvironments.API.Interfaces;
using EphemeralEnvironments.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EphemeralEnvironments.API
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
            dynamic envVars = Environment.GetEnvironmentVariables();
            var connectionString = $"Host={envVars.EE_POSTGRES_SERVICE_HOST};Port=5432;Database=postgres;Username=postgres;Password=Password123!";
            // string connectionString = Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"ConfigureServices connectionstring: {connectionString}");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IVibesRepository, VibesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
