using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public abstract class AvaliableFunctions
    {
        private string _chosenCurrency;
        public string chosenCurrency
        {
            get { return _chosenCurrency; }
            set { _chosenCurrency = value; }
        }

        private Dictionary<string,Dictionary<string,double>> _exchangeXML;
        public Dictionary<string,Dictionary<string,double>> exchangeXML
        {
            get { return _exchangeXML; }
            set { _exchangeXML = value; }
        }
    }
}
