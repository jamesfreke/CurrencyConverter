using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public abstract class AvaliableFunctions
    {

        private List<Currency> _exchangeXML;
        public List<Currency> exchangeXML
        {
            get { return _exchangeXML; }
            set { _exchangeXML = value; }
        }
    }
}
