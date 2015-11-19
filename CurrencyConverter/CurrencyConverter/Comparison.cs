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

        public List<Currency> ConvertListData(string currencyCompareTo, bool nintyDays)
        {
            List<Currency> goThrough = new List<Currency>();
            List<Currency> answer = new List<Currency>();

            if(!nintyDays)
            {
                goThrough = exchangeXML.FindAll(d => d.date == exchangeXML[0].date).ToList();
            }
            else
            {
                goThrough = exchangeXML.ToList();
            }

            if (currencyCompareTo != "EUR")
            {
                double toValue = goThrough.Find(x => x.symbol == currencyCompareTo).value;

                foreach (Currency c in goThrough)
                {
                    answer.Add(new Currency(c.symbol, Math.Round((c.value / toValue), 2), c.date));
                }
                return answer;
            }

            return goThrough;
        }

        /// <summary>
        /// Assumption: List is sorted to latest date on top.
        /// </summary>
        /// <returns>A list with the largest value on top.</returns>
        public List<Currency> strength(string currencyCompareTo)
        {
            List<Currency> answer = new List<Currency>();

            if(exchangeXML.Count==0){
                return answer;
            }

            if(currencyCompareTo == "")
            {
                currencyCompareTo = "EUR";
            }
            answer = ConvertListData(currencyCompareTo, false);

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

            Currency currency;

            if(currencyCompareTo == "")
            {
                currencyCompareTo = "EUR";
            }

            answer = ConvertListData(currencyCompareTo,false);
            currency = answer.Find(c => c.symbol == currencyCompareTo);

            answer = answer.FindAll(r => r.value > currency.value);

            return answer;
        }

        public Currency HighestOrLowestRate(string currencyToGet, Boolean getHighest, List<Currency>listToSearchThrough)
        {
            if (listToSearchThrough.Where(x => x.symbol == currencyToGet).ToList().Count > 0)
            {
                List<Currency> selected = new List<Currency>();
                selected = listToSearchThrough.FindAll(x => x.symbol == currencyToGet).ToList();

                if(getHighest)
                {
                    return selected.OrderByDescending(x => x.value).ToList()[0];
                }
                return selected.OrderBy(x => x.value).ToList()[0];
            }
            return new Currency("", 0, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyAgainist"></param>
        /// <returns>A list that is ordered with symbol lowest, symbol highest, symbol1 lowest, symbol1 highest, etc.</returns>
        public List<Currency> HighestAndLowestPerCurrency(string currencyAgainist)
        {
            List<Currency> answer = new List<Currency>();
            
            if(exchangeXML.Count == 0)
            {
                return answer;
            }

            if(currencyAgainist == "")
            {
                currencyAgainist = "EUR";
            }

            List<Currency> xmlList = new List<Currency>();
            xmlList = ConvertListData(currencyAgainist, true);

            List<Currency> distinctSymbol = new List<Currency>();
            distinctSymbol = exchangeXML.Distinct(new CurrencyComparerSymbol()).ToList();

            foreach(Currency c in distinctSymbol)
            {
               answer.Add(HighestOrLowestRate(c.symbol,true,xmlList)); 
               answer.Add(HighestOrLowestRate(c.symbol,false,xmlList));  
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

            List<Currency> xmlList = new List<Currency>();

            if (currencyCompareTo == "")
            {
                currencyCompareTo = "EUR";
            }

            xmlList = HighestAndLowestPerCurrency(currencyCompareTo);
            xmlList = xmlList.OrderBy(x => x.symbol).ThenBy(x => x.date).ToList();
            List<Currency> store = new List<Currency>();

            for (int i = 0; i+1 < xmlList.Count; i+=2)
            {
                store.Add(new Currency(xmlList[i].symbol,(xmlList[i+1].value-xmlList[i].value)));
            }

                if (greatest)
                {
                    store = store.OrderByDescending(x => Math.Abs(x.value)).ToList();
                    return store.FindAll(x => x.value == store[0].value).ToList();
                }

                store = store.OrderBy(x => Math.Abs(x.value)).Take(10).OrderBy(x => x.value).ToList();
                return store;

        }

    }
}
