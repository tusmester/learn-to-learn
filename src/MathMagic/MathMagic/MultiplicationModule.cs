using System;
using System.Threading.Tasks;

namespace MathMagic
{
    public interface IMathModule
    {
        Task ExecuteAsync();
    }
    internal class MultiplicationModule : IMathModule
    {
        private readonly Random _random = new();
        private int _successCount;

        public Task ExecuteAsync()
        {
            var finish = false;
            _successCount = 0;

            do
            {
                int n1;
                int n2;

                do
                {
                    n1 = _random.Next(50, 499);
                    n2 = _random.Next(2, 10);
                } while (n1 * n2 > 1000);

                ConsoleEx.WriteLineBold(n1 + " x " + n2);

                while (true)
                {
                    //UNDONE: ReadKey and handle character individually
                    var orig = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    
                    var input = Console.ReadLine();
                    Console.ForegroundColor = orig;

                    if (string.IsNullOrEmpty(input))
                    {
                        finish = true;
                        break;
                    }

                    if (!int.TryParse(input, out var number))
                    {
                        ConsoleEx.WriteWarning("Kérlek, számokat írj be :)");
                        continue;
                    }

                    if (n1 * n2 == number)
                    {
                        ConsoleEx.WriteLineSuccess("Ez az!");
                        Console.WriteLine();
                        _successCount++;
                        break;
                    }
                    else
                    {
                        ConsoleEx.WriteWarning("Próbáld újra");
                    }
                }
            } while (!finish);

            if (_successCount > 0)
            {
                ConsoleEx.WriteSuccessHighlight(_successCount.ToString());
                ConsoleEx.WriteLineSuccess(" jó válaszod volt!");
            }

            return Task.CompletedTask;
        }
    }
}
