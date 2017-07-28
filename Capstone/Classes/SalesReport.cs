using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Capstone.Classes
{
    public static class SalesReport
    {
        public static int RecallSold(string productName)
        {
            int result = 0;
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\..\etc\SalesReport.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split('|');
                        if (line[0].Equals(productName))
                        {
                            result = Convert.ToInt32(line[1]);
                        }
                    }
                }
            }
            catch { }
            return result;
        }

        public static void GenerateSalesReport(VM vendingMachine)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"..\..\..\etc\SalesReport.txt", false))
                {
                    decimal revenue = 0;
                    foreach (KeyValuePair<string, Item> item in vendingMachine.Inventory)
                    {
                        revenue += item.Value.Price * item.Value.Sold; 
                        sw.WriteLine($"{item.Value.Name}|{item.Value.Sold}");
                    }
                    sw.WriteLine();
                    sw.WriteLine($"**TOTAL SALES** ${revenue.ToString("#0.00")}");
                }

            }
            catch (IOException)
            {
                Console.WriteLine("There was an error writing to Sales Report.");
            }
        }

        public static void OpenSalesReport()
        {
            try
            {
                if (!File.Exists(@"..\..\..\etc\SalesReport.txt")) { throw new FileNotFoundException(); }
                Process.Start("notepad.exe", @"..\..\..\etc\SalesReport.txt");
            }
            catch
            {
                Console.WriteLine("\nSales report not found.");
                Thread.Sleep(2000);
            }
        }

    }
}
