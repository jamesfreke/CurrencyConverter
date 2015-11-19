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
        public List<Currency> strength(string currencyCompareTo)
        {
            List<Currency> answer = new List<Currency>();

            if(exchangeXML.Count==0){
                return answer;
            }

            answer = exchangeXML.FindAll(d => d.date == exchangeXML[0].date).ToList();

            string currencyToCompare = "";

            if (currencyCompareTo == "")
            {
                currencyToCompare = "EUR";
            }
            else
            {
                currencyToCompare = currencyCompareTo;
                double toValue = answer.Find(x => x.symbol == currencyToCompare).value;
                List<Currency> store = new List<Currency>();
                Converter converter = new Converter(answer);

                foreach (Currency c in answer)
                {
                    store.Add(new Currency(c.symbol, Math.Round((c.value / toValue),2), c.date));
                }

                answer = new List<Currency>();
                answer.AddRange(store);
            }

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

            answer = exchangeXML.FindAll(d => d.date == exchangeXML[0].date).ToList();

            string currencyToCompare = "";
            if (currencyCompareTo == "")
            {
                currencyToCompare = "EUR";
            }
            else
            {
                currencyToCompare = currencyCompareTo;
                double toValue = answer.Find(x => x.symbol == currencyToCompare).value;
                List<Currency> store = new List<Currency>();
                foreach (Currency c in answer)
                {
                    store.Add(new Currency(c.symbol, Math.Round((c.value / toValue), 2), c.date));
                }
                answer = new List<Currency>();
                answer.AddRange(store);
            }
            
            Currency euro = answer.Find(c => c.symbol == currencyToCompare);
            answer = answer.FindAll(r => r.value > euro.value);

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

        public List<Currency> HighestAndLowestPerCurrency(string currencyAgainist)
        {
            List<Currency> answer = new List<Currency>();
            List<Currency> store = new List<Currency>();
            List<Currency> xmlList = new List<Currency>();
            
            if(exchangeXML.Count == 0)
            {
                return answer;
            }

            xmlList = exchangeXML.ToList();

            string currencyCompareTo;
            if(currencyAgainist == "")
            {
                currencyCompareTo = "EUR";
            }
            else
            {
                currencyCompareTo = currencyAgainist;
                List<Currency> distinctDates = new List<Currency>();
                distinctDates = xmlList.Distinct(new CurrencyComparerDates()).ToList();

                foreach (Currency c in distinctDates)
                {
                    List<Currency> specificDate = new List<Currency>();
                    specificDate = xmlList.FindAll(x => x.date == c.date);
                    double toValue = specificDate.Find(x => x.symbol == currencyCompareTo).value;

                    foreach (Currency curr in specificDate)
                    {
                        store.Add(new Currency(curr.symbol, Math.Round((curr.value / toValue), 2), curr.date));
                    }
                }
                xmlList = new List<Currency>();
                xmlList.AddRange(store);
            }

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

            List<Currency> store = new List<Currency>();
            List<Currency> xmlList = new List<Currency>();
            xmlList = exchangeXML.ToList();

            string currencyCompare;
            if (currencyCompareTo == "")
            {
                currencyCompare = "EUR";
            }
            else
            {
                currencyCompare = currencyCompareTo;
                List<Currency> distinctDates = new List<Currency>();
                distinctDates = xmlList.Distinct(new CurrencyComparerDates()).ToList();

                foreach (Currency c in distinctDates)
                {
                    List<Currency> specificDate = new List<Currency>();
                    specificDate = xmlList.FindAll(x => x.date == c.date);
                    double toValue = specificDate.Find(x => x.symbol == currencyCompare).value;

                    foreach (Currency curr in specificDate)
                    {
                        store.Add(new Currency(curr.symbol, Math.Round((curr.value / toValue), 2), curr.date));
                    }
                }
                xmlList = new List<Currency>();
                xmlList.AddRange(store);
            }

            List<Currency> distinctSymbol = new List<Currency>();
            distinctSymbol = exchangeXML.Distinct(new CurrencyComparerSymbol()).ToList();
            List<Currency> tempStore = new List<Currency>();

            foreach (Currency c in distinctSymbol)
            {
                List<Currency> temporary = new List<Currency>();
                temporary.Add(HighestOrLowestRate(c.symbol, true,xmlList));
                temporary.Add(HighestOrLowestRate(c.symbol, false,xmlList));
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
