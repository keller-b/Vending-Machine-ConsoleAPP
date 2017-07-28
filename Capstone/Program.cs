using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Vending Machine";
            Console.SetWindowSize(147, 40);
            VM test = new VM();
            UI ui = new UI();
            ui.Run();
        }
    }
}
