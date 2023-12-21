using Serilog;

namespace EphemeralEnvironments.API
{
    public class Program
    {
        private static IConfigurationRoot configuration;

        public static void Main(string[] args)
        {
            try
            {
                SetupConfig();

                Log.Information("Starting web host...");
                CreateHostBuilder(args).Build().Run();
                Log.Information("Web host stopped");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Exception starting API: {ex.Message}");
                throw;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .ConfigureAppConfiguration((_, config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        config.AddEnvironmentVariables();
                        Console.WriteLine($"BasePath: {Directory.GetCurrentDirectory()}");
                    })
                    .UseStartup<Startup>();
                });
        }

        private static void SetupConfig()
        {
            configuration = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();
        }
    }
}
