using chinook_lib_netstandard_ef.Model;
using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole.Pages
{
    class GenresDeletePage : Page
    {
        public GenresDeletePage(Program program)
            : base("Delete Genres", program)
        {
        }

        public override void Display()
        {
            const string prompt = "Enter the genre to delete: ";

            var buff = "";
            var done = false;
            do
            {
                Console.Clear();
                base.Display();
                Console.Write(prompt + buff);

                if (buff != "")
                {
                    using (var db = new ChinookDbContext())
                    {
                        var matches = db.genres.Where(g => g.Name.StartsWith(buff)).ToList();
                        Console.SetCursorPosition(0, 4);
                        Output.WriteLine("Matches");
                        foreach (var matching_genre in matches)
                        {
                            Output.WriteLine(matching_genre.Name);
                        }
                    }
                }

                Console.SetCursorPosition(prompt.Length + buff.Length, 2);
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                    done = true;
                else if (key.Key == ConsoleKey.Backspace)
                    buff = (buff.Length > 0) ? buff.Substring(0, buff.Length - 1) : "";
                else
                    buff = buff + key.KeyChar.ToString();
            } while (!done);

            if (buff == "")
            {
                Program.NavigateBack();
            }
            else
            {
                // do deletion
                Program.NavigateBack();
            }
        }
    }
}
