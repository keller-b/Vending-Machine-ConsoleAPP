using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.Threading;


namespace Capstone.Classes
{
    public class UI
    {
        private VM VendingMachine;
        private string input = "";
        private string[] validSelection = { "1", "2", "3", "4" };

        public UI()
        {
            VendingMachine = new VM();
        }

        public void Run()
        {
            while (input != "4")
            {
                Landing();
                Console.WriteLine();
            }
        }
        public void Landing()
        {
            Console.Clear();
            Header.Headline();
            Console.WriteLine("1) Display Products");
            Console.WriteLine("2) Purchase");
            Console.WriteLine("3) Sales Report");
            Console.WriteLine("4) Exit");
            Console.WriteLine();
            validSelection = new string[] { "1", "2", "3", "4" };

            input = GetValidInput();
            if (input == "3")
            {
                SalesReport.OpenSalesReport();
            }
            MenuChange();
        }
        public void Display()
        {
            Console.Clear();
            Header.Headline();
            foreach (KeyValuePair<string, Item> item in VendingMachine.Inventory)
            {
                Console.WriteLine($"{item.Key}  {item.Value.Name}   ${item.Value.Price.ToString("#0.00")}");
            }

            Console.WriteLine();
            Console.WriteLine("0) Main Menu");
            Console.WriteLine("2) Purchase");
            Console.WriteLine("3) Sales Report");
            Console.WriteLine("4) Exit");
            validSelection = new String[] { "0", "2", "3", "4" };

            input = GetValidInput();
            if (input == "3")
            {
                SalesReport.OpenSalesReport();
            }
            MenuChange();
        }
        public void Purchase()
        {
            while (input != "3")
            {
                Console.Clear();
                Header.Headline();
                Console.WriteLine("1) Feed Money");
                Console.WriteLine("2) Select Product");
                Console.WriteLine("3) Finished");
                Console.WriteLine();
                Console.WriteLine($"Current balance: ${VendingMachine.Balance.ToString("#0.00")}");
                Console.WriteLine();
                validSelection = new string[] { "1", "2", "3" };
                input = GetValidInput();
                switch (input)
                {
                    case "1":
                        validSelection = new string[] { "1", "2", "5", "10", "20" };
                        decimal moneyInserted = Convert.ToDecimal(GetCashMoney());
                        decimal balanceAfter = VendingMachine.Balance + moneyInserted;
                        LogWriter.WriteLog("FEED MONEY:", VendingMachine.Balance, balanceAfter);
                        VendingMachine.AddMoney(moneyInserted);
                        break;
                    case "2":
                        validSelection = VendingMachine.Inventory.Keys.ToArray();
                        string selection = GetValidSlot();
                        if (VendingMachine.Balance >= VendingMachine.Inventory[selection].Price && VendingMachine.Inventory[selection].Quantity > 0)
                        {
                            decimal balance = VendingMachine.Balance;
                            VendingMachine.Balance -= VendingMachine.Inventory[selection].Price;
                            VendingMachine.Inventory[selection].Quantity--;
                            VendingMachine.Inventory[selection].Sold++;
                            LogWriter.WriteLog($"{VendingMachine.Inventory[selection].Name} {selection}", balance, VendingMachine.Balance);
                            SalesReport.GenerateSalesReport(VendingMachine);
                            Console.WriteLine();
                            Console.WriteLine(VendingMachine.Inventory[selection].Yum());
                            Thread.Sleep(1000);
                        }
                        if (VendingMachine.Inventory[selection].Quantity == 0)
                        {
                            Console.WriteLine("SOLD OUT");
                            LogWriter.WriteLog($"SOLD OUT: {VendingMachine.Inventory[selection].Name}", VendingMachine.Balance, VendingMachine.Balance);
                            Thread.Sleep(2000);
                        }
                        break;
                    case "3":
                        decimal currentBalance = VendingMachine.Balance;
                        Console.WriteLine(VendingMachine.DispenseChange());
                        LogWriter.WriteLog($"GIVE CHANGE:", currentBalance, VendingMachine.Balance);
                        Thread.Sleep(3000);
                        break;
                }
            }
        }
        public void MenuChange()
        {
            switch (input)
            {
                case "0":
                    Landing();
                    break;
                case "1":
                    Display();
                    break;
                case "2":
                    Purchase();
                    break;
            }

        }
        public string GetValidInput()
        {
            Console.Write("\nPlease enter a selection: ");
            return GetValidInputBody();
        }
        public string GetCashMoney()
        {
            Console.Write("\nPlease insert bills: ");
            return GetValidInputBody();
        }
        public string GetValidSlot()
        {
            Console.Write("\nPlease enter product slot: ");
            return GetValidInputBody().ToUpper();
        }
        public string GetValidInputBody()
        {
            string result = "";
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;
            bool firstTime = true;
            do
            {
                if (!firstTime)
                {
                    Console.Beep(550, 75);
                    Console.Beep(550, 75);
                    Console.Beep(550, 75);
                    Console.Beep(550, 75);
                }
                firstTime = false;
                result = Console.ReadLine();
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write("                                ");
                Console.SetCursorPosition(cursorLeft, cursorTop);
            } while (!validSelection.Contains(result));
            return result;

        }

    }
}
