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
            XML xmlTest = new XML();

            xmlTest.ReadXmlFile();

            Console.ReadLine();
        }
    }
}
