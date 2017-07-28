using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class Item
    {
        //private string name;
        //private int quantity;
        //private decimal price;
        //private int sold;

        public abstract string Yum();

        public int Sold { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
