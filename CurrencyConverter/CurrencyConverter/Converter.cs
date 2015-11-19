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
            if (value == 0)
            {
                return value + " "+ symbol1 + " is 0 " + symbol2; 
            }

            if (exchangeXML.Where(symbol => symbol.symbol == symbol2).Count() > 0 && exchangeXML.Where(symbol => symbol.symbol == symbol1).Count() > 0)
            {
                double rate = exchangeXML.Find(symbol => symbol.symbol == symbol1).value;
                double rate2 = exchangeXML.Find(symbol => symbol.symbol == symbol2).value;

                if (symbol1 == "EUR")
                {
                    string returnValue1 = value + " " + symbol1;

                    string returnValue2 = Math.Round((value * rate2),2) + " " + symbol2;


                    return returnValue1 + " is " + returnValue2;
                }
                else
                {
                    string returnValue3 = Math.Round((rate2 / rate),2) + "";

                    return value + " " + symbol1 + " is " + returnValue3 + " " + symbol2;
                }
            }
            else
            {
                return "Currency not found";
            }
        }
    }
}
