using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class CurrencyComparerSymbol : IEqualityComparer<Currency>
    {
        public bool Equals(Currency x, Currency y)
        {
            return x.symbol.Equals(y.symbol) ;
        }

        public int GetHashCode(Currency obj)
        {
            return obj.symbol.GetHashCode();
        }
    }
}
