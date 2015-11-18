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
        Average average;
        Mock<XML> xml;

        [TestInitialize]
        public void SetUp()
        {
            xml = new Mock<XML>();
            List<Currency> xmlData= xml.Object.exchangeXML;
            //xml.Setup(x => x.SetUp()).
            average = new Average(xml.Object);
        }

        //[TestMethod]
        //public void Test_GetList_TestsTheGetListMethodCallsTheGetListFunction_VerifyGetListIsCalledOnce()
        //{
        //    //Arrange

        //    //Act
        //    List<Currency> currencyList = average.GetList();

        //    //Assert
        //    Assert
        //}

        [TestMethod]
        public void Test_GetListTestsTheGetListMethodReturnsAListOfCurrencies_ReturnTypeIsList()
        {
            //Arrange
            List<Currency> xmlData = xml.Object.exchangeXML;

            //Act
            List<Currency> currencyList = average.GetList();

            //Assert
            Assert.IsInstanceOfType(currencyList, typeof(List<Currency>));
        }

        [TestMethod]
        public void Test_FindAverage_TestsThatFindAverageReturnsADouble_ReturnsADouble()
        {
            //Arrange
            List<Currency> xmlData = xml.Object.exchangeXML;
            double expected = 0.0;

            //Act
            double returnedAverage = average.FindAverage(xmlData);

            //Assert
            Assert.AreEqual(expected, returnedAverage);
        }

        [TestMethod]
        public void Test_ListOfCurrencyNames_TestsThatItReturnsAList_ReturnsAList()
        {
            //Arrange
            List<string> expected = new List<string>();
            List<string> returnedList = new List<string>();

            //Act
            returnedList = average.GetCurrencyNames();

            //Assert
            Assert.IsInstanceOfType(returnedList, typeof(List<string>));
        }
    }
}
