using chinook_lib_netstandard_ef.Model;
using Demo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole
{
    class ChinookConsoleProgram
    {
        static void Main(string[] args)
        {

            //while(true)
            //{
            //    System.Console.WriteLine("Window Height: " + System.Console.WindowHeight);
            //    System.Console.ReadLine();
            //}

            new ChinookEasyConsole().Run();
        }

        //static void Main(string[] args)
        //{
        //    initialize_db();
        //    show_menu();
        //    get_user_input();
        //    perform_requested_action();
        //}

        //private static void perform_requested_action()
        //{
        //    throw new NotImplementedException();
        //}

        //private static void get_user_input()
        //{
        //    throw new NotImplementedException();
        //}

        //private static void show_menu()
        //{
        //    throw new NotImplementedException();
        //}

        //private static void initialize_db()
        //{
        //    using (var db = new ChinookDbContext())
        //    {
        //        // file is only created on call to Migrate
        //        db.Database.Migrate();
        //    }
        //}
    }
}
