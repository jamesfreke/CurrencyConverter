using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Converter : AvaliableFunctions
    {       
        public Converter(List<Currency> ExchangeXML)
        {
            exchangeXML = ExchangeXML;
        }

        public string convertTo(double value, string symbol1, string symbol2)
        {
            if (exchangeXML.Where(symbol => symbol.symbol == symbol2).Count() > 0)
            {
                double rate = exchangeXML.Find(symbol => symbol.symbol == symbol2).value;

                string returnValue1 = value +" " + symbol1;

                string returnValue2 = (value * rate) +" "+ symbol2;

                return returnValue1 +  " is " + returnValue2;
            }
            else
            {
                return "Currency not found";
            }          
        }
    }
}
