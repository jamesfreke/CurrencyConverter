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

        List<Currency> listOfAverages = new List<Currency>();
        
        public List<Currency> GetList()
        {
            return exchangeXML;
        }

        public List<string> GetCurrencyNames()
        {
             List<string> listOfCurrencyNames = new List<string>();

            int numberOfCurrencies = exchangeXML.FindIndex(x => x.symbol == "EUR");

            for (int i = 0; i <= numberOfCurrencies; i++)
            {
                listOfCurrencyNames.Add(exchangeXML[i].symbol);
            }
            return listOfCurrencyNames;
        }

       

        public double FindAverage(List<Currency> Currency)
        {
            

            double sum = 0;
            //exchangeXML.FindAll();
            return sum;
        }
    }
}
