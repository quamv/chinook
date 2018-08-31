using chinook_lib_netstandard_ef.Model;
using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole.Pages
{
    class MediaTypesAddPage : SimplePromptPage
    {
        public MediaTypesAddPage(Program program)
            : base("Add media types", program) { }

        public override void Display()
        {
            Display("Enter the new media type (or [Enter] to exit): ", (db, new_media_type) =>
            {
                db.media_types.Add(new media_type() { Name = new_media_type });
            });
        }
    }
}
