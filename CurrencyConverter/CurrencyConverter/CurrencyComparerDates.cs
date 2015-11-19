using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class CurrencyComparerDates : IEqualityComparer<Currency>
    {
        public bool Equals(Currency x, Currency y)
        {
            return x.date.Equals(y.date) ;
        }

        public int GetHashCode(Currency obj)
        {
            return obj.date.GetHashCode();
        }
    }
}
