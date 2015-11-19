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
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HULK  (TM)!");
            Console.WriteLine("Note: The data is correct for the 18/11/2015 and 90 days prior to this date.");
            Console.WriteLine("-------");
            Console.WriteLine("Preparing the data. Please wait...");
            Console.WriteLine("-------");
            XML xml = new XML();
            xml.XMLSetUp();

            Console.WriteLine("System is ready.");

            //Console.WriteLine("What do you want to do? {0}", );
            
            switch (Console.ReadLine())
	    {
                case "1":

                    break;

		    default:
                    break;
	    } 

            Console.ReadLine();

        }
    }
}
