using chinook_lib_netstandard_ef.Model;
using ChinookConsole.Pages;
using Demo.Pages;
using EasyConsole;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    class ChinookEasyConsole : Program
    {
        public ChinookEasyConsole()
            : base("EasyConsole Demo", breadcrumbHeader: true)
        {

            using (var db = new ChinookDbContext())
            {
                db.Database.Migrate();
            }
            AddPage(new MainPage(this));
            AddPage(new MediaTypesMenuPagePlus(this));
            AddPage(new MediaTypesAddPage(this));
            AddPage(new MediaTypesListPage(this));
            AddPage(new GenresDeletePage(this));
            AddPage(new GenresAddPage(this));
            AddPage(new GenresListPage(this));
            AddPage(new GenresMenuPagePlus(this));

            SetPage<MainPage>();
        }
    }
}
