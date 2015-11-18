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
        public List<Currency> GreatestOrSmallestChangeNintyDays(string currencyCompareTo, Boolean greatest)
        {
            List<Currency> answer = new List<Currency>();

            if (exchangeXML.Count == 0)
            {
                return answer;
            }

            string currencyCompare;
            if (currencyCompareTo == "")
            {
                currencyCompare = "EU";
            }
            else
            {
                currencyCompare = currencyCompareTo;
            }

            List<Currency> distinctSymbol = new List<Currency>();
            distinctSymbol = exchangeXML.Distinct(new CurrencyComparerSymbol()).ToList();
            List<Currency> tempStore = new List<Currency>();

            foreach (Currency c in distinctSymbol)
            {
                List<Currency> temporary = new List<Currency>();
                temporary.Add(HighestOrLowestRate(c.symbol, true));
                temporary.Add(HighestOrLowestRate(c.symbol, false));
                temporary = temporary.OrderByDescending(x => x.date).ToList();
                double answerStore = temporary[1].value - temporary[0].value;
                tempStore.Add(new Currency(c.symbol, answerStore));
            }

            if (greatest)
            {
                tempStore = tempStore.OrderByDescending(x => Math.Abs(x.value)).ToList();
                return tempStore.FindAll(x => x.value == tempStore[0].value).ToList();
            }

            tempStore = tempStore.OrderBy(x => Math.Abs(x.value)).Take(10).OrderBy(x => x.value).ToList();
            return tempStore;
            
        }

    }
}
