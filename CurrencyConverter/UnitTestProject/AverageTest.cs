using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class AverageTest
    {
        [TestMethod]
        public void Test_GetList_TestsTheGetListMethodGetsAList_ReturnTypeList()
        {
            //Arrange
            Average average = new Average();

            //Act
            List<Currency> currencyList = average.GetList();

            //Assert

        }
    }
}
