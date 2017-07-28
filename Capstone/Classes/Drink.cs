using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Drink : Item
    {
        public Drink(string name, decimal price)
        {
            Name = name;
            Price = price;
            Quantity = 5;
            Sold = SalesReport.RecallSold(Name);
        }
        public override string Yum()
        {
            YumSpeech.VerballyEnjoy("Glug Glug, Yum!");
            return "Glug Glug, Yum!";
        }
    }
}
