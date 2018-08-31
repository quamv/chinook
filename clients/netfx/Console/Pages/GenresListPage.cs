using chinook_lib_netstandard_ef.Model;
using EasyConsole;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Pages
{
    class GenresListPage : Page
    {
        public GenresListPage(Program program)
            : base("List Genres", program)
        { }

        private List<genre> get_genres()
        {
            using (var db = new ChinookDbContext())
            {
                return db.genres.ToList();
            }
        }

        public override void Display()
        {
            base.Display();

            var genres = get_genres();

            foreach(var genre in genres)
            {
                Output.WriteLine(genre.Name);
            }

            Input.ReadString("Press [Enter]");
            Program.NavigateBack();
        }
    }
}



//public class BasicListPage<T> : Page
//{
//    public BasicListPage(string title, Program program)
//        : base(title, program)
//    { }

//    public void MyDisplay(IEnumerable<T> objects)
//    {
//        base.Display();

//        foreach (var obj in objects)
//        {

//        }
//    }
//}

