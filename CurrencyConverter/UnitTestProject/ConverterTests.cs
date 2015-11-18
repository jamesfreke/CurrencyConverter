using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;
using Moq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class ConverterTests
    {
        Converter converter;
        Mock<List<Currency>> currencyList;

        [TestInitialize]
        public void Setup()
        {
            Mock<List<Currency>> currencyList = new Mock<List<Currency>>();

            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("GBP", 0.7009, "12-12-2012");
            Mock<Currency> c = new Mock<Currency>("USD", 1.0666, "12-12-2012");
            Mock<Currency> d = new Mock<Currency>("JPY", 131.65, "12-12-2012");

            currencyList.Object.Add(a.Object);
            currencyList.Object.Add(b.Object);
            currencyList.Object.Add(c.Object);
            currencyList.Object.Add(d.Object);

            converter = new Converter(currencyList.Object);
        }

        [TestMethod]
        public void Test_ConvertToMethod_ReturnsAString()
        {
            //Arrange
            double value = 0.0;

            //Act
            string result = converter.convertTo(value, "GBP", "Euro");

            //Assert
            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void Test_ConvertToMethod_Returns0WhenGivenNoValue()
        {
            //Arrange
            double value = 0.0;

            //Act
            string result = converter.convertTo(value, "GBP", "USD");

            //Assert
            Assert.AreEqual("0 GBP is 0 USD", result);
        }

        [TestMethod]
        public void Test_Converter_ReturnsAConversionWhenGivenCorrectValues()
        {
            //Arrange
            double value = 100;

            //Act
            string result = converter.convertTo(value, "EUR", "USD");

            //Assert
            Assert.AreEqual("100 EUR is 106.66 USD", result);
        }

        [TestMethod]
        public void Test_Converter_ReturnsAConversionWhenGivenCorrectValuesFromJPYToUSD()
        {
            //Arrange
            double value = 1;

            //Act
            string result = converter.convertTo(value, "JPY", "USD");

            //Assert
            Assert.AreEqual("1 JPY is 0.01 USD", result);
        }
         
    }
}
