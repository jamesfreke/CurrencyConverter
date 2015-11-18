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
            XMLController xmlTest2 = new XMLController();

            xmlTest.XMLSetUp();
            //xmlTest2.ReadXmlFile();
            

            Console.ReadLine();
        }
    }
}
