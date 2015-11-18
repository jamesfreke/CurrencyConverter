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
        Mock<XML> xml;

        [TestInitialize]
        public void Setup()
        {
            xml = new Mock<XML>();
            xml.Object.dataListFromXML = new List<Currency>();
            converter = new Converter(xml.Object);
        }

        [TestMethod]
        public void Test_CovertToMethod_ReturnsAString()
        {
            //Arrange
            double value = 0.0;

            //Act
            string result = converter.convertTo(value, "GBP", "Euro");

            //Assert
            Assert.IsInstanceOfType(result, typeof(string));
        }
    }
}
