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
            string path = "C:/Users/victor.hearn-yeates/Source/Repos/CurrencyConverter/CurrencyConverter/CurrencyConverter/bin/Debug/eurocurrencies.xml";

            XML xmlTest = new XML();

            xmlTest.ReadXmlFile(path);

            Console.ReadLine();
        }
    }
}
