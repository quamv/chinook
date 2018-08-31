using EasyConsole;

namespace Demo.Pages
{
    class MainPage : MenuPage
    {
        public MainPage(Program program)
            : base("Main Page", program,
                  new Option("Media Types", () => program.NavigateTo<MediaTypesMenuPagePlus>()),
                  new Option("Genres", () => program.NavigateTo<GenresMenuPagePlus>()))
        {
        }
    }
}
