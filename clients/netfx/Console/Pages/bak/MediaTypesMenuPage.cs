using EasyConsole;

namespace Demo.Pages
{
    class MediaTypesMenuPage : MenuPage
    {
        public MediaTypesMenuPage(Program program)
            : base("MediaTypes Menu", program,
                  new Option("Add", () => program.NavigateTo<Page1A>()),
                  new Option("List", () => program.NavigateTo<Page1B>()))
        {
        }
    }
}
