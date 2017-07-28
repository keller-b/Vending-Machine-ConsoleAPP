using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chips : Item
    {
        public Chips(string name, decimal price)
        {
            Name = name;
            Price = price;
            Quantity = 5;
            Sold = SalesReport.RecallSold(Name);
        }
        public override string Yum()
        {
            YumSpeech.VerballyEnjoy("Crunch Crunch, Yum!");
            return "Crunch Crunch, Yum!";
        }
    }
}
