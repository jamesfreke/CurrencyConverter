using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyConverter
{
    class Program
    {
        static List<Currency> xmllist;

        public static void AskOperation()
        {
            Console.WriteLine("\nPlease enter the number of what operation you wish to do. \n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
                "1. Convert to another currency",
                "2. List of average rate for each currency for the last ninty days",
                "3. List of currencies in order of strength, as compared to x",
                "4. List of currencies that are stronger than x",
                "5. List of highest and lowest rate for each currencies, as compared to x, for the last ninty days",
                "6. List of currencies with the greatest change againist x for the last 90 days",
                "7. List of the ten weakest currencies in the last ninty days, as compared to x",
                "8. Exit HULK");
            
            switch (Console.ReadLine())
            {
                case "1":
                    Average a = new Average(xmllist);
                    foreach (Currency c in a.FindAverage())
                    {
                        Console.WriteLine(c.value + " "+c.symbol);
                    }
                    break;

                case "2":

                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "5":

                    break;

                case "6":

                    break;

                case "7":

                    break;

                case "8":
                    break;

                default:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nIncorrect Value");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    AskOperation();
                    break;
            } 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HULK  (TM)!");
            Console.WriteLine("Note: The data is correct for the 18/11/2015 and 90 days prior to this date.");
            Console.WriteLine("-------");
            Console.WriteLine("Preparing the data. Please wait...");
            Console.WriteLine("-------");
            XML xml = new XML();
            xmllist = new List<Currency>();
           xmllist =  xml.XMLSetUp();

            do
            {
                AskOperation();

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDo you wish to exit HULK? Y/N");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            } while (Console.ReadLine().ToUpper() == "N");

        }
    }
}
