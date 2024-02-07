using SumoLogic.Logging.AspNetCore;

namespace Techievibe.Hub.Auth.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                   Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                        .AddJsonFile("configoverride/appsettings.json", optional: true, reloadOnChange: true)
                                        .AddEnvironmentVariables();
                    })
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder
                                    .ConfigureLogging((hostingContext, logging) =>
                                {
                                    logging.ClearProviders();
                                    logging.AddConsole();
                                    logging.AddSumoLogic(Environment.GetEnvironmentVariable("SumoUrl") ?? "https://endpoint4.collection.sumologic.com/receiver/v1/http/ZaVnC4dhaV099uRmhvlliGfawYRYNssVK6DhBJujN4uDwRryc5sC9MF5K9yoBu0FEg7akL4wbUI1jGYruFU1uERbuQKQ6DSGaWn6z-PQcIvKqGmE43fWkA==");
                                    logging.AddDebug();
                                    logging.AddEventSourceLogger();
                                });
                        webBuilder.UseStartup<Startup>();
                    });
    }
}
