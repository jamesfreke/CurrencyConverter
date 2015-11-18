using CurrencyConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject
{
    public class Average : AvaliableFunctions
    {
        //Creates a space for the xml class object
        private XML _xml;
        public XML xml
        {
            get { return _xml; }
            set { _xml = value; }
        }

        //Constructor to populate the xml object space to access the xml in this class
        public Average(XML Xml)
        {
            xml = Xml;
        }

        
        public List<Currency> GetList()
        {
            return exchangeXML;
        }

        public double FindAverage(List<Currency> Currency)
        {
            double sum = 0;
            //for (int i = 0; i < Currency.Count; i++)
            //{
            //    sum += Currency[i].value;
            //}
            return sum;
        }
    }
}
