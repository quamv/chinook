using chinook_lib_netstandard_ef.Model;
using EasyConsole;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Pages
{
    class MediaTypesListPage : Page
    {
        public MediaTypesListPage(Program program)
            : base("Media Types", program)
        {
        }

        private List<media_type> get_media_types()
        {
            using (var db = new ChinookDbContext())
            {
                return db.media_types.ToList();
            }
        }

        public override void Display()
        {
            base.Display();

            var media_types = get_media_types();

            foreach(var media_type in media_types)
            {
                Output.WriteLine(media_type.Name);
            }

            Input.ReadString("Press [Enter]");
            Program.NavigateBack();
        }
    }
}
