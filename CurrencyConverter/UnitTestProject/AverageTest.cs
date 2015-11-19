using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class AverageTest
    {
        Average average;
        Mock<List<Currency>> xml;

        [TestInitialize]
        public void SetUp()
        {
            xml = new Mock<List<Currency>> ();
        }

        [TestMethod]
        public void Test_GetCurrencyNames_TestsTheGetListMethodReturnsAListOfCurrencies_ReturnTypeIsList()
        {
            average = new Average(xml.Object);

            //Act
            List<string> currencyList = average.GetCurrencyNames();

            //Assert
            Assert.IsInstanceOfType(currencyList, typeof(List<string>));
        }

        [TestMethod]
        public void Test_GetCurrencyNames_ReturnAListOfOneElement_WhenGivenAListOfTwoElementsOfTheSameSymbol()
        {
            //Arrange
            xml = new Mock<List<Currency>>();
            Mock<Currency> a = new Mock<Currency>("EUR",0,"12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EUR",0,"13-12-2012");
            xml.Object.Add(a.Object);
            xml.Object.Add(b.Object);
            average = new Average(xml.Object);

            //Act
            List<string> actual = average.GetCurrencyNames();

            //Assert
            Assert.AreEqual("EUR",actual[0]);
        }

        [TestMethod]
        public void Test_FindAverage_ReturnAListOfOneElementWithAverageFive_WhenGivenAListOfTwoElementsOfTheSameSymbol()
        {
            //Arrange
            xml = new Mock<List<Currency>>();
            Mock<Currency> a = new Mock<Currency>("EUR", 10, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EUR", 10, "13-12-2012");
            xml.Object.Add(a.Object);
            xml.Object.Add(b.Object);
            average = new Average(xml.Object);

            List<Currency> expected = new List<Currency>(){
                new Mock<Currency> ("EUR",10).Object
            };

            //Act
            List<Currency> actual = average.FindAverage();

            //Assert
            Assert.IsTrue(actual.SequenceEqual(expected, new CurrencyComparerSymbolAndValue()));
        }

        [TestMethod]
        public void Test_FindAverage_ReturnAListOfTwoElementsWithAverages_WhenGivenAListOfFourElements()
        {
            //Arrange
            xml = new Mock<List<Currency>>();
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EUR", 10, "13-12-2012");
            Mock<Currency> c = new Mock<Currency>("EUR", 70, "14-12-2012");
            Mock<Currency> d = new Mock<Currency>("GBP", 10, "12-12-2012");
            xml.Object.Add(d.Object);
            xml.Object.Add(a.Object);
            xml.Object.Add(b.Object);
            xml.Object.Add(c.Object);
            average = new Average(xml.Object);

            List<Currency> expected = new List<Currency>(){
                new Mock<Currency> ("GBP",10).Object,
                new Mock<Currency> ("EUR",27).Object
            };

            //Act
            List<Currency> actual = average.FindAverage();

            //Assert
            Assert.IsTrue(actual.SequenceEqual(expected, new CurrencyComparerSymbolAndValue()));
        }

    }
}
