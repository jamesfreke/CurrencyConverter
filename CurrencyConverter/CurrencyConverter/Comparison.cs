using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Comparison : AvaliableFunctions
    {
        public Comparison(List<Currency> ExchangeXML)
        {
            this.exchangeXML = exchangeXML;
        }

        /// <summary>
        /// Assumption: Dictionary is sorted to latest date on top.
        /// </summary>
        /// <returns></returns>
        public List<Currency> strength()
        {
            if(exchangeXML.Count==0){
                return new List<Currency>();
            }

            List<Currency> answer = new List<Currency>();

            answer = exchangeXML.FindAll(c => c.date == exchangeXML.First().date).ToList();

            return answer;
        }
    }
}
