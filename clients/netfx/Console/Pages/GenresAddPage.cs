using chinook_lib_netstandard_ef.Model;
using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole.Pages
{
    class GenresAddPage : SimplePromptPage
    {
        public GenresAddPage(Program program)
            : base("Add a genre", program)
        {
        }

        public override void Display()
        {
            Display("Enter the new genre (or [Enter] to exit): ", (db, new_genre) =>
            {
                db.genres.Add(new genre() { Name = new_genre });
            });
        }
        //public override void Display()
        //{
        //    bool done = false;
        //    var new_genre = "";
        //    while (!done)
        //    {
        //        base.Display();

        //        new_genre = Input.ReadString("Enter the new genre (or [Enter] to exit): ");

        //        if (new_genre != "")
        //        {
        //            using (var db = new ChinookDbContext())
        //            {
        //                try
        //                {
        //                    db.genres.Add(new genre() { Name = new_genre });
        //                    db.SaveChanges();
        //                    new_genre = "";
        //                }
        //                catch (Exception ex)
        //                {
        //                    Output.WriteLine(ex.Message);
        //                    if (ex.InnerException != null)
        //                    {
        //                        Output.WriteLine(ex.InnerException.Message);
        //                    }
        //                    Input.ReadString("Press Enter");
        //                }
        //            }
        //            Output.Clear();
        //        }
        //        else
        //            done = true;
        //    }
        //    Program.NavigateBack();
        //}

    }
}
