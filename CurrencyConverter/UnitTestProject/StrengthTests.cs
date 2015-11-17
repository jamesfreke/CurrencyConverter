using CurrencyConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class ComparisonTests
    {
        Mock<List<Currency>> mockXML;

        [TestInitialize]
        public void Setup()
        {
            mockXML = new Mock<List<Currency>>();
        }

        [TestMethod]
        public void Test_Strength_ReturnsAnEmptyDictionary_WhenGivenAnEmptyDictionary()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.strength();

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_Strength_ReturnsAnDictionaryOfOneElement_WhenGiveAnDictionaryOfOneElement()
        {
            mockXML.Object.Add(new Currency("EU",1,"12-12-2012"));
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.strength();

            Assert.AreEqual(1, actual.Count);
        }

    }
}
