using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class CurrencyComparerSymbolAndValue : IEqualityComparer<Currency>
    {
        public bool Equals(Currency x, Currency y)
        {
            return (x.symbol.Equals(y.symbol) && x.value.Equals(y.value));
        }

        public int GetHashCode(Currency obj)
        {
            return obj.symbol.GetHashCode() ^ obj.value.GetHashCode();
        }
    }
}
