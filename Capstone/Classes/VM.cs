using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VM
    {
        private Dictionary<string, Item> inventory;
        private decimal balance;

        public VM()
        {
            inventory = new Dictionary<string, Item>();

            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\..\etc\vendingmachine.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split('|');
                        char category = line[0].First();

                        switch (category)
                        {
                            case 'A':
                                inventory.Add(line[0], new Chips(line[1], Convert.ToDecimal(line[2])));
                                break;
                            case 'B':
                                inventory.Add(line[0], new Candy(line[1], Convert.ToDecimal(line[2])));
                                break;
                            case 'C':
                                inventory.Add(line[0], new Drink(line[1], Convert.ToDecimal(line[2])));
                                break;
                            case 'D':
                                inventory.Add(line[0], new Gum(line[1], Convert.ToDecimal(line[2])));
                                break;
                        }

                    }
                }
            }
            catch (IOException e) { Console.WriteLine("There was an error retrieving the inventory"); }
        }

        public Dictionary<string, Item> Inventory
        {
            get
            {
                return inventory;
            }
        }

        public Decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public void AddMoney(Decimal money)
        {
            balance += money;
        }

        public string DispenseChange()
        {
            Dictionary<string, int> coins = new Dictionary<string, int>()
            {
                { "Quarters", 0},
                {"Dimes", 0 },
                {"Nickles", 0 },
            };
            do
            {
                if (balance >= .25m) { coins["Quarters"] += 1; balance -= .25m; }
                else if (balance >= .10m) { coins["Dimes"] += 1; balance -= .10m; }
                else if (balance >= .05m) { coins["Nickles"] += 1; balance -= .05m; }
            } while (balance != 0.00m);

            string CoinCall()
            {
                string result = "";
                foreach (KeyValuePair<string, int> coin in coins)
                {
                    result += $"{coin.Value} {coin.Key} ";
                }
                return result;
            }

            return ($"\nDispensing change: {CoinCall()}");
        }
    }
}
