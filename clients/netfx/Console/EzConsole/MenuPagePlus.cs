using EasyConsole;
using System.Collections.Generic;

namespace ChinookConsole.EzConsole
{
    public abstract class MenuPagePlus : Page
    {
        protected ChinookMenu Menu { get; set; }

        public MenuPagePlus(string title, Program program, params Option[] options)
            : base(title, program)
        {
            Menu = new ChinookMenu();

            foreach (var option in options)
                Menu.Add(option);
        }

        public override void Display()
        {
            // display the page header (title and breadcrumbs)
            base.Display();

            // determine if we should stuff a 'go back' option onto the menu
            if (Program.NavigationEnabled && !Menu.Contains("Go back"))
                Menu.Add("Go back", () => { Program.NavigateBack(); });

            // just show the menu, but don't do the auto-prompt
            Menu.DisplayOnly();

            // we prompt here, using the override that takes the list of options
            int choice = Input.ReadInt("Choose an option:", (List<Option>)Menu.Options);
            Menu.Options[choice - 1].Callback();
        }
    }
}
