using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMagic
{
    internal class ConsoleEx
    {
        internal static void WriteWarning(string text)
        {
            WriteLineColored(text, ConsoleColor.Yellow);
        }
        internal static void WriteColored(string text, ConsoleColor foreGround)
        {
            var original = Console.ForegroundColor;

            Console.ForegroundColor = foreGround;
            Console.Write(text);
            Console.ForegroundColor = original;
        }
        internal static void WriteColored(string text, ConsoleColor foreGround, ConsoleColor backGround)
        {
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            Console.ForegroundColor = foreGround;
            Console.BackgroundColor = backGround;
            Console.Write(text);
            Console.ForegroundColor = originalForeground;
            Console.BackgroundColor = originalBackground;
        }
        internal static void WriteLineColored(string text, ConsoleColor color)
        {
            var original = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = original;
        }
        internal static void WriteLineColored(string text, ConsoleColor foreGround, ConsoleColor backGround)
        {
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            Console.ForegroundColor = foreGround;
            Console.BackgroundColor = backGround;
            Console.WriteLine(text);
            Console.ForegroundColor = originalForeground;
            Console.BackgroundColor = originalBackground;
        }

        internal static void WriteLineBold(string text)
        {
            WriteLineColored(text, ConsoleColor.White);
        }
        internal static void WriteLineSuccess(string text)
        {
            WriteLineColored(text, ConsoleColor.Green);
        }
        internal static void WriteSuccessHighlight(string text)
        {
            WriteColored(text, ConsoleColor.Black, ConsoleColor.Green);
        }
    }
}
