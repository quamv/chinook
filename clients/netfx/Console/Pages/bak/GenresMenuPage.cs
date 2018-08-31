using ChinookConsole.EzConsole;
using EasyConsole;

namespace Demo.Pages
{
    class GenresMenuPage : MenuPage
    {
        public GenresMenuPage(Program program)
            : base("Genres Menu", program,
                  new Option("Add", () => program.NavigateTo<Page1A>()),
                  new Option("List", () => program.NavigateTo<Page1B>()))
        {
        }

        public override void Display()
        {
            base.Display();

            //var prompt_linenbr = 2 + Menu.Options.Count + 1;
            //var lines_left = Output.WindowHeight - (prompt_linenbr + 1);
            //for (var i = 0; i < lines_left; i++)
            //{
            //    Output.WriteLine(i + " of " + lines_left);
            //}

            //System.Console.SetCursorPosition(0, prompt_linenbr);
            //int choice = Input.ReadInt("Choose an option:", min: 1, max: Menu.Options.Count);
            //Menu.Options[choice - 1].Callback();
        }

        //public void DisplayMenu()
        //{
        //    for (int i = 0; i < Options.Count; i++)
        //    {
        //        Console.WriteLine("{0}. {1}", i + 1, Options[i].Name);
        //    }
        //    int choice = Input.ReadInt("Choose an option:", min: 1, max: Options.Count);

        //    Options[choice - 1].Callback();
        //}


    }
}
