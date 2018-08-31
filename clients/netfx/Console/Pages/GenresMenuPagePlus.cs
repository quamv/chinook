using ChinookConsole.EzConsole;
using ChinookConsole.Pages;
using EasyConsole;

namespace Demo.Pages
{
    class GenresMenuPagePlus : MenuPagePlus
    {
        public GenresMenuPagePlus(Program program)
            : base("Genres Menu", program,
                  new Option("Add", () => program.NavigateTo<GenresAddPage>()),
                  new Option("List", () => program.NavigateTo<GenresListPage>()),
                  new Option("Delete", () => program.NavigateTo<GenresDeletePage>()))
        {
        }
    }
}
