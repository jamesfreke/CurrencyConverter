using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Currency
    {
        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        private double _value;
        public double value
        {
            get { return _value; }
            set { _value = value; }
        }
        
    }
}
