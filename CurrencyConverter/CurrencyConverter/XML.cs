using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyConverter
{
    public class XML : AvaliableFunctions
    {
        //Create dataList so that the XML list can be accessed in other classes
        private List<Currency> _dataListFromXML;
        public List<Currency> dataListFromXML
        {
            get { return _dataListFromXML; }
            set { _dataListFromXML = value; }
        }

        
        public void ReadXmlFile()
        {
            //Creates an instance of the list
            dataListFromXML = new List<Currency>();

            //Creates new XML doc, named doc which takes in a filename eurocurrencies.
            XmlDocument doc = new XmlDocument();
            doc.Load("eurocurrencies.xml");

            //Gets the chiidnodes/subnodes of the first element
            XmlNodeList nodeList = doc.DocumentElement.ChildNodes;

            //Goes down, selects out the "Cube" attribute
            foreach (XmlNode n in nodeList)
            {
                if (n.Name == "Cube")
                {
                    foreach (XmlNode n2 in n.ChildNodes)
                    {
                        //Saves each date and then steps into it and reads all the currency symbols and rates.
                        string date = n2.Attributes[0].Value;
                        Console.WriteLine(date);
                        foreach (XmlNode n3 in n2.ChildNodes)
                        {
                            string currency = n3.Attributes[0].Value;
                            Console.WriteLine(currency);
                            string rate = n3.Attributes[1].Value;
                            //Converts string rate to double value to match inputs for Currency
                            double value = Convert.ToDouble(rate);
                            Console.WriteLine(rate);
                            dataListFromXML.Add(new Currency(currency, value, date));
                        }
                    }
                }
            }
        }

    }
}
