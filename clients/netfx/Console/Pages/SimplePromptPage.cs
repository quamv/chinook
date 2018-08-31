using chinook_lib_netstandard_ef.Model;
using EasyConsole;
using System;

namespace ChinookConsole.Pages
{
    public class SimplePromptPage : Page
    {
        public SimplePromptPage(string title, Program program)
            : base(title, program) { }

        public void Display(string prompt, Action<ChinookDbContext, string> processor)
        {
            bool done = false;
            var new_value = "";
            while (!done)
            {
                base.Display();

                new_value = Input.ReadString(prompt);

                if (new_value != "")
                {
                    using (var db = new ChinookDbContext())
                    {
                        try
                        {
                            processor(db, new_value);
                            db.SaveChanges();
                            new_value = "";
                        }
                        catch (Exception ex)
                        {
                            Output.WriteLine(ex.Message);
                            if (ex.InnerException != null)
                            {
                                Output.WriteLine(ex.InnerException.Message);
                            }
                            Input.ReadString("Press Enter");
                        }
                    }
                    Output.Clear();
                }
                else
                    done = true;
            }
            Program.NavigateBack();
        }
    }
}
