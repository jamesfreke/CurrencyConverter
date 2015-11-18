using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;
using System.Collections.Generic;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class AverageTest
    {
        XML xml;
        Average average;
        Mock<Average> mockCurrencyList;
        [TestInitialize]
        public void SetUp()
        {
            xml = new XML();
            average = new Average(xml);
            mockCurrencyList = new Mock<Average>(xml);
        }
        [TestMethod]
        public void Test_GetList_TestsTheGetListMethodCallsTheGetListFunction_VerifyGetListIsCalledOnce()
        {
            //Arrange
            Mock<Average> mockCurrencyList = new Mock<Average>(xml);

            //Act
            List<Currency> currencyList = mockCurrencyList.Object.GetList();

            //Assert
            mockCurrencyList.Verify(x => x.GetList(), Times.Once);
        }

        [TestMethod]
        public void Test_GetListTestsTheGetListMethodReturnsAListOfCurrencies_ReturnTypeIsList()
        {
            //Arrange
            List<Currency> mockCurrencyList = new List<Currency>();

            //Act
            List<Currency> currencyList = average.GetList();

            //Assert

        }
    }
}
