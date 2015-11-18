using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Comparison : AvaliableFunctions
    {
        public Comparison(List<Currency> exchangeXML)
        {
            this.exchangeXML = exchangeXML;
        }

        /// <summary>
        /// Assumption: List is sorted to latest date on top.
        /// </summary>
        /// <returns>A list with the largest value on top.</returns>
        public List<Currency> strength()
        {
            if(exchangeXML.Count==0){
                return new List<Currency>();
            }

            List<Currency> answer = new List<Currency>();

            answer = exchangeXML.FindAll(d => d.date == exchangeXML[0].date).ToList();
            answer = answer.OrderByDescending(r => r.value).ToList();

            return answer;
        }

        /// <summary>
        /// Assumption: List is sorted to latest date on top.
        /// </summary>
        /// <param name="currencyCompareTo"></param>
        /// <returns>A list of values that are strong than the currency given in the argument</returns>
        public List<Currency> StrongerThan(string currencyCompareTo)
        {
            List<Currency> answer = new List<Currency>();
            if (exchangeXML.Count == 0)
            {
                return answer;
            }

            string currencyToCompare = "";
            if (currencyCompareTo == "")
            {
                currencyToCompare = "EU";
            }
            else
            {
                currencyToCompare = currencyCompareTo;
            }

            answer = exchangeXML.FindAll(d => d.date == exchangeXML[0].date).ToList();
            Currency euro = answer.Find(c => c.symbol == "EU");
            answer = answer.FindAll(r => r.value >= euro.value);

            return answer;
        }

        //public Currency HighestAgainist(string CurrencyCompareTo)
        //{

        //}

        //public Currency LowestAgainist(string CurrencyCompareTo)
        //{

        //}
        //public Currency GreatestChangeNintyDays(string CurrencyCompareTo)
        //{

        //}

        //public Currency SmallestChangeNintyDays(string CurrencyCompareTo)
        //{

        //}
    }
}
