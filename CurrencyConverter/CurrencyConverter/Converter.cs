using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Converter : AvaliableFunctions
    {
        private XML _exchangeXML;
        public XML exchangeXML
        {
            get { return _exchangeXML; }
            set { _exchangeXML = value; }
        }
        
        public Converter(XML ExchangeXML)
        {
            exchangeXML = ExchangeXML;
        }

        public string convertTo(double value, string symbol1, string symbol2)
        {            
            double rate = exchangeXML.dataListFromXML.Find(symbol => symbol.symbol == symbol2).value;

            string returnValue1 = value + symbol1;

            string returnValue2 = (value * rate) + symbol2;

            return  returnValue1 + " is " + returnValue2;
        }
    }
}
