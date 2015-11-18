using CurrencyConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject
{
    public class Average : AvaliableFunctions
    {
        private List<Currency> _listOfCurrencies;

        public List<Currency> listOfCurrencies
        {
            get { return _listOfCurrencies; }
            set { _listOfCurrencies = value; }
        }
        
        public virtual List<Currency> GetList()
        {
            return listOfCurrencies;
        }
    }
}
