using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Minesweeper
{
    class Program
    {
        public static async Task Main()
        {
            using var host = CreateHostBuilder().Build();

            var game = host.Services.GetRequiredService<IGame>();
            game.Run();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.Configure<AppSettings>(GetAppConfiguration());
                    services.AddSingleton<IGameFactory, GameFactory>();
                    services.AddTransient<IGame, Game>();
                    // Additional services and configurations can be added as required.
                });

        private static IConfiguration GetAppConfiguration()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();


            return config;
        }
    }
}
