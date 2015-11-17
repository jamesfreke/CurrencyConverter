using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Comparison : AvaliableFunctions
    {
        public Comparison(Dictionary<string, Dictionary<string, double>> ExchangeXML)
        {
            exchangeXML = ExchangeXML;
        }

        /// <summary>
        /// Assumption: Dictionary is sorted to latest date on top.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, double> strength()
        {
            if(exchangeXML.Count==0){
                return new Dictionary<string, double>();
            }
            
            Dictionary<string, double> answer = new Dictionary<string, double>();

            answer = exchangeXML.First().Value.OrderBy(c => c.Value, ) as Dictionary<string, double>;

            return answer;
        }
    }
}
