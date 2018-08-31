using System;
using System.Collections.Generic;

namespace EasyConsole
{
    public static class Input
    {
        const string go_back_menu = "Go back";

        public static int ReadInt(string prompt, List<Option> options)
        {
            Output.DisplayPrompt(prompt);

            string input = Console.ReadLine();

            if (input == "")
            {
                for (var i = 0; i < options.Count; i++)
                {
                    if (options[i].Name == go_back_menu)
                    {
                        return i + 1;
                    }
                }
            }

            int value;
            while (!int.TryParse(input, out value) || ((value < 1) || (value > options.Count)))
            {
                Output.DisplayPrompt("Please enter an integer from 1 to " + options.Count);
                input = Console.ReadLine();
            }

            return value;
        }

        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            int value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadInt();
            }

            return value;
        }

        public static int ReadInt()
        {
            string input = Console.ReadLine();

            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer");
                input = Console.ReadLine();
            }

            return value;
        }

        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            Type type = typeof(TEnum);

            if (!type.IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            Output.WriteLine(prompt);
            Menu menu = new Menu();

            TEnum choice = default(TEnum);
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            return choice;
        }
    }
}
