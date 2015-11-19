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
        public List<Currency> XMLSetUp()
        {
            //Creates new XML doc, named doc which takes in a filename eurocurrencies.
            XmlDocument doc = new XmlDocument();
            doc.Load("eurocurrencies.xml");

            //Gets the chiidnodes/subnodes of the first element
            XmlNodeList nodeList = doc.DocumentElement.ChildNodes;

            XMLController XmLController = new XMLController();
            exchangeXML = new List<Currency>();
            exchangeXML = XmLController.ReadXmlFile(nodeList);
            return exchangeXML;
        }
        
    }
}
