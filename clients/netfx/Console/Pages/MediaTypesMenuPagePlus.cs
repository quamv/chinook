using ChinookConsole.EzConsole;
using ChinookConsole.Pages;
using EasyConsole;

namespace Demo.Pages
{
    class MediaTypesMenuPagePlus : MenuPagePlus
    {
        public MediaTypesMenuPagePlus(Program program)
            : base("MediaTypes Menu", program,
                  new Option("Add", () => program.NavigateTo<MediaTypesAddPage>()),
                  new Option("List", () => program.NavigateTo<MediaTypesListPage>()))
        {
        }
    }
}
