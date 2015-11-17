using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;
using System.Collections.Generic;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class StrengthTests
    {
        [TestMethod]
        public void Test_Strength_ReturnsAnEmptyDictionary_WhenGivenAnEmptyDictionary()
        {
            Comparison comparison = new Comparison();
            Dictionary <string,double> given = new Dictionary<string,double>();

            Dictionary<string,double> actual = comparison.strength(given);

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_Strength_ReturnsAnDictionaryOfOneElement_WhenGiveAnDictionaryOfOneElement()
        {
            Comparison comparison = new Comparison();
            Dictionary<string, double> given = new Dictionary<string, double>();

            Dictionary<string, double> actual = comparison.strength(given);

            Assert.AreEqual(1, actual.Count);
        }

    }
}
