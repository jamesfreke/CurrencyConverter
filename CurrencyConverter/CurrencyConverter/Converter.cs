using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Converter : AvaliableFunctions
    {
        List<Currency> exchangeXML;


        public Converter(List<Currency> exchangeXML)
        {
            this.exchangeXML = exchangeXML;
        }

        public double convertTo(string symbol1, string symbol2, double value)
        {
            return value;
        }

        
    }
}
