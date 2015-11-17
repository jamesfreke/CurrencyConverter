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
        public void ReadXmlFile(string filename)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            XmlNodeList nodeList = doc.DocumentElement.ChildNodes;

            foreach (XmlNode n in nodeList)
            {
                if (n.Name == "Cube")
                {
                    foreach (XmlNode n2 in n.ChildNodes)
                    {
                        string time = n2.Attributes[0].Value;
                        Console.WriteLine(time);
                        foreach (XmlNode n3 in n2.ChildNodes)
                        {
                            string currency = n3.Attributes[0].Value;
                            //Console.WriteLine(currency);
                            string rate = n3.Attributes[1].Value;
                            //Console.WriteLine(rate);
                        }
                    }
                }
            }
        }

    }
}
