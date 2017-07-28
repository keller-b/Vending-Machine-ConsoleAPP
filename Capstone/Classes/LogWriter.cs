using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes;

namespace Capstone.Classes
{
    public static class LogWriter
    {
        public static void WriteLog(string newEvent, decimal balance, decimal balanceAfter)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"..\..\..\etc\log.txt", true))
                {
                    sw.WriteLine("{0,-21}{1,-19:C}{2,-10}{3}", $"{DateTime.Now}", $"{newEvent}", $"${balance.ToString("#0.00")}", $"${balanceAfter.ToString("#0.00")}");
                }

            }
            catch(IOException)
            {
                Console.WriteLine( "There was an error writing to log.");
            }
            
        }
        
    
    }
}
