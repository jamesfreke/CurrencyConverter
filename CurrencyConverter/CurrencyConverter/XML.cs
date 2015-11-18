using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyConverter
{
    public class XML
    {
        private List<Currency> _dataListFromXML;
        public List<Currency> dataListFromXML
        {
            get { return _dataListFromXML; }
            set { _dataListFromXML = value; }
        }

        
        public void ReadXmlFile(string filename)
        {
            dataListFromXML = new List<Currency>();

            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            XmlNodeList nodeList = doc.DocumentElement.ChildNodes;

            foreach (XmlNode n in nodeList)
            {
                if (n.Name == "Cube")
                {
                    foreach (XmlNode n2 in n.ChildNodes)
                    {
                        string date = n2.Attributes[0].Value;
                        Console.WriteLine(date);
                        foreach (XmlNode n3 in n2.ChildNodes)
                        {
                            string currency = n3.Attributes[0].Value;
                            Console.WriteLine(currency);
                            string rate = n3.Attributes[1].Value;
                            double value = Convert.ToDouble(rate);
                            Console.WriteLine(rate);
                            //Currency input = new Currency(currency, value, date);
                            dataListFromXML.Add(new Currency(currency, value, date));
                        }
                    }
                }
            }
        }

    }
}
