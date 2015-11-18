using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Currency
    {

        public Currency(string symbol, double value, string date)
        {
            this.symbol = symbol;
            this.value = value;
            this.date = date;
        }

        public Currency(string symbol, double value){
            this.symbol = symbol;
            this.value = value;
        }

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

        private string _date;
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
        
        
    }
}
