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
        [TestMethod]
        public void Test_GetList_TestsTheGetListMethodCallsTheGetListFunction_VerifyGetListIsCalledOnce()
        {
            //Arrange
            Average average = new Average();
            Mock<Average> mockCurrencyList = new Mock<Average>();

            //Act
            List<Currency> currencyList = mockCurrencyList.Object.GetList();

            //Assert
            mockCurrencyList.Verify(x => x.GetList(), Times.Once);
        }

        [TestMethod]
        public void Test_GetListTestsTheGetListMethodReturnsAListOfCurrencies_ReturnTypeIsList()
        {
            //Arrange
            Average average = new Average();
            List<Currency> mockCurrencyList = new List<Currency>();

            //Act
            List<Currency> currencyList = average.GetList()

            //Assert

        }
    }
}
