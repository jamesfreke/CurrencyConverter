using CurrencyConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyConverter
{
    public class Average : AvaliableFunctions
    {
        public Average(List<Currency> Xml)
        {
            exchangeXML = Xml;
        }

        List<Currency> listOfAverages = new List<Currency>();

        /// <summary>
        /// Assumption: EUR is the last currency in the list, in line with our XML code
        /// </summary>
        /// <returns></returns>
        public List<string> GetCurrencyNames()
        {
            List<string> listOfCurrencyNames = new List<string>();

            int numberOfCurrencies = exchangeXML.FindIndex(x => x.symbol == "EUR");

            for (int i = 0; i <= numberOfCurrencies; i++)
            {
                listOfCurrencyNames.Add(exchangeXML[i].symbol);
            }
            return listOfCurrencyNames;
        }

        public List<Currency> FindAverage()
        {
            List<Currency> answer = new List<Currency>();

            foreach (string symbol in GetCurrencyNames())
            {
                List<Currency> tempStore = new List<Currency>();
                tempStore = exchangeXML.FindAll(x => x.symbol == symbol).ToList();

                double sum = 0;
                foreach(Currency curr in tempStore)
                {
                    sum += curr.value;
                }

                answer.Add(new Currency(symbol,(sum/tempStore.Count)));
            }
            return answer;
        }
    }
}