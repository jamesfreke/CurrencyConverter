using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyConverter
{
    public class XMLController : XML
    {
        public List<Currency> ReadXmlFile(XmlNodeList nodeList)
        {
            List<Currency> xmlList = new List<Currency>();
            //Goes down, selects out the "Cube" attribute
            foreach (XmlNode n in nodeList)
            {
                if (n.Name == "Cube")
                {
                    foreach (XmlNode n2 in n.ChildNodes)
                    {
                        //Saves each date and then steps into it and reads all the currency symbols and rates.
                        string date = n2.Attributes[0].Value;
                        //Console.WriteLine(date);
                        foreach (XmlNode n3 in n2.ChildNodes)
                        {
                            string currency = n3.Attributes[0].Value;
                            //Console.WriteLine(currency);
                            string rate = n3.Attributes[1].Value;
                            //Converts string rate to double value to match inputs for Currency
                            double value = Convert.ToDouble(rate);
                            //Console.WriteLine(rate);
                            xmlList.Add(new Currency(currency, value, date));
                        }
                        xmlList.Add(new Currency("EUR", 1.0, date));
                        //Console.WriteLine("EUR");
                    }
                }
            }
            return xmlList;
        }
    }
}
