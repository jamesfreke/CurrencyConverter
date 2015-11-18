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
            answer = answer.OrderBy(r => r.value).ToList();

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
            Currency euro = answer.Find(c => c.symbol == currencyToCompare);
            answer = answer.FindAll(r => r.value > euro.value);

            return answer;
        }

        public Currency HighestOrLowestRate(string currencyToGet, Boolean getHighest)
        {
            if (exchangeXML.Where(x => x.symbol == currencyToGet).ToList().Count >0)
            {
                List<Currency> selected = new List<Currency>();
                selected = exchangeXML.FindAll(x => x.symbol == currencyToGet).ToList();

                if(getHighest)
                {
                    return selected.OrderByDescending(x => x.value).ToList()[0];
                }
                return selected.OrderBy(x => x.value).ToList()[0];
            }
            return new Currency("", 0, "");
        }

        public List<Currency> HighestAndLowestPerCurrency(string currencyAgainist)
        {
            List<Currency> answer = new List<Currency>();

            if(exchangeXML.Count == 0)
            {
                return answer;
            }
            
            string currencyCompareTo;
            if(currencyAgainist == "")
            {
                currencyCompareTo = "EU";
            }
            else
            {
                currencyCompareTo = currencyAgainist;
            }

            List<Currency> distinctSymbol = new List<Currency>();
            distinctSymbol = exchangeXML.Distinct(new CurrencyComparerSymbol()).ToList();

            foreach(Currency c in distinctSymbol)
            {
               answer.Add(HighestOrLowestRate(c.symbol,true)); 
               answer.Add(HighestOrLowestRate(c.symbol,false));  
            }

            answer = answer.OrderBy(x => x.symbol).ThenBy(x => x.value).ToList();
            return answer;
        }

        /// <summary>
        /// List rather than a singular currency, incase there is more than one that
        /// has the exact greatest change.
        /// </summary>
        /// <param name="CurrencyCompareTo"></param>
        /// <returns></returns>
        public List<Currency> GreatestChangeNintyDays(string CurrencyCompareTo)
        {
            List<Currency> answer = new List<Currency>();
            Currency baseCurrency = new Currency("",0);

            if (exchangeXML.Count == 0)
            {
                return answer;
            }

            string currencyCompareTo;
            if (CurrencyCompareTo == "")
            {
                currencyCompareTo = "EU";
            }
            else
            {
                currencyCompareTo = CurrencyCompareTo;
            }

            List<Currency> distinctSymbol = new List<Currency>();
            distinctSymbol = exchangeXML.Distinct(new CurrencyComparerSymbol()).ToList();

            foreach (Currency c in distinctSymbol)
            {
                double answerStore = Math.Abs(HighestOrLowestRate(c.symbol, true).value - HighestOrLowestRate(c.symbol, false).value);

                if (answerStore >= baseCurrency.value)
                {
                    baseCurrency.value = answerStore;
                    answer.Add(new Currency(c.symbol, answerStore));
                }
            }
            return answer;
        }

        //public Currency SmallestChangeNintyDays(string CurrencyCompareTo)
        //{

        //}
    }
}
