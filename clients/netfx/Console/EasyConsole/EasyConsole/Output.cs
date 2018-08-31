using System;

namespace EasyConsole
{
    public static class Output
    {
        public static void WriteLine(ConsoleColor color, string format, params object[] args)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(format, args);
            Console.ResetColor();
        }

        public static void WriteLine(ConsoleColor color, string value)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            LineNbr++;
        }

        public static void DisplayPrompt(string format, params object[] args)
        {
            format = format.Trim() + " ";
            Console.Write(format, args);
        }

        public static int LineNbr = 0;
        public static void Clear()
        {
            Console.Clear();
            LineNbr = 0;
        }

        public static int WindowHeight
            => System.Console.WindowHeight;
    }
}
