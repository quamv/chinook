using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole.EzConsole
{
    public class ChinookMenu //: Menu
    {
        public IList<Option> Options { get; set; }

        public ChinookMenu()
        {
            Options = new List<Option>();
        }

        public void DisplayOnly()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                Output.WriteLine("{0}. {1}", i + 1, Options[i].Name);
            }
        }

        public void Display()
        {
            DisplayOnly();
            int choice = Input.ReadInt("Choose an option:", min: 1, max: Options.Count);
            Options[choice - 1].Callback();
        }

        public void Add(string option, Action callback)
        {
            Add(new Option(option, callback));
        }

        public void Add(Option option)
        {
            Options.Add(option);
        }

        public bool Contains(string option)
        {
            return Options.FirstOrDefault((op) => op.Name.Equals(option)) != null;
        }
    }
}
