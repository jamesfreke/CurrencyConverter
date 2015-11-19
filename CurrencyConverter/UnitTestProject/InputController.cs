using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyConverter;

namespace UnitTestProject
{
    public class InputController : AvaliableFunctions
    {
        public InputController()
        {
            LongNames longNames = new LongNames();
            Dictionary<string, string> dOfLongNames = longNames.GetDictionary();
        }

        internal bool longerThanThree(string input)
        {
            //checks to see if the string is longer than three
            bool stringIsLongerThanThree = false;
            if (input.Length > 4)
            {
                stringIsLongerThanThree = true;
            }
            return stringIsLongerThanThree;
        }

        internal bool ChecksExistence(string input)
        {
            bool exists = exchangeXML.Exists(symbol => symbol.symbol == input);
            return exists;
        }

        //internal string LongToShortConverter(string input)
        //{
        //    string symbol = exchangeXML.Exists(
        //}
    }
}
