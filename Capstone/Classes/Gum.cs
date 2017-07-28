using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Gum : Item
    {
        public Gum(string name, decimal price)
        {
            Name = name;
            Price = price;
            Quantity = 5;
            Sold = SalesReport.RecallSold(Name);
        }
        public override string Yum()
        {
            YumSpeech.VerballyEnjoy("Chew Chew, Yum!");
            return "Chew Chew, Yum!";
        }
    }
}
