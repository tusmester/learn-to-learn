using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MathMagic
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            WriteStartInfo();

            var module = host.Services.GetServices<IMathModule>().First();

            await module.ExecuteAsync();

            Console.ReadKey();
        }

        private static void WriteStartInfo()
        {
            ConsoleEx.WriteLineColored($"Szia {Environment.UserName}!", ConsoleColor.Magenta);
            Console.WriteLine();
            ConsoleEx.WriteLineBold("Így használd a programot:");
            Console.WriteLine("   1. írd be a megoldást");
            Console.WriteLine("   2. Nyomd meg az ENTER-t");
            Console.WriteLine();
            Console.WriteLine("Ha ki akarsz lépni, csak üresen nyomd meg az ENTER-t!");
            Console.WriteLine();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hb, services) => services
                    .AddLogging(logging =>
                    {
                        logging.AddConsole();
                        logging.AddFile("Logs/mathmagic-{Date}.txt", LogLevel.Trace);
                    })
                    .AddSingleton<IMathModule, MultiplicationModule>()
                );
    }
}
