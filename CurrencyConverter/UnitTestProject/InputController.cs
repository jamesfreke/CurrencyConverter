using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyConverter;

namespace UnitTestProject
{
    public class InputController : AvaliableFunctions
    {
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

        //First need to search the directionairies to check for different inputs

        internal bool ChecksExistence(string input)
        {
            bool exists = exchangeXML.Exists(symbol => symbol.symbol == input);
            return exists;
        }

        internal bool LongToShortConverter(string input)
        {
            //Code
        }
    }
}
