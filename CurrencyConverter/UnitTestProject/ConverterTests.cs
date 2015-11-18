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

        [TestMethod]
        public void Test_CovertToMethod_ReturnsAString()
        {
            //Arrange
            converter = new Converter(new XML());
            double value = 0.0;
            string expected = "lolz";

            //Act
            string result = converter.convertTo(value, "GBP", "Euro");

            //Assert
            Assert.AreEqual(expected,result,true);
        }

        [TestMethod]
        public void Test_ConvertToMethod_ReturnsAValueWhenAValueIsGiven()
        {
            //Arrange
            converter = new Converter(new XML());
            double value = 100;

            //Act
            string result = converter.convertTo(value, "GBP", "USD");

            //Assert
            Assert.AreEqual(result, 100);
        }
    }
}
