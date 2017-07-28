using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy : Item
    {
        public Candy(string name, decimal price)
        {
            Name = name;
            Price = price;
            Quantity = 5;
            Sold = SalesReport.RecallSold(Name);
        }
        public override string Yum()
        {
            YumSpeech.VerballyEnjoy("Munch Munch, Yum!");
            return "Munch Munch, Yum!";
        }
    }
}
