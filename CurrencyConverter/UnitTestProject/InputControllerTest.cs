using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using CurrencyConverter;

namespace UnitTestProject
{
    [TestClass]
    public class InputControllerTest
    {
        InputController inputController;
        Mock<List<Currency>> mockList;

        [TestInitialize]
        public void SetUp()
        {
            mockList = new Mock<List<Currency>>();
            inputController = new InputController();
        }

        //Add check long form exists

        [TestMethod]
        public void Test_CheckInput_ChecksLongFormToShortFormConverter_ReturnsString()
        {
            //Arrange
            mockList.Object.Add(new Mock<Currency>("EUR", 1.0, "DATE").Object);
            string input = "Euros";
            inputController.exchangeXML = mockList.Object;

            //Act
            string convertedString = inputController.LongToShortConverter(input);

            //Assert
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void Test_ChecksInput_ChecksForLongFormOfCurrencyNameByReturningTrueIfMoreThanThreeCharactersAreTypedIn_ReturnsTrue()
        {
            //Arrange

            //Act
            bool longerThanThree = inputController.longerThanThree("longer");

            //Assert
            Assert.IsTrue(longerThanThree);
        }

        [TestMethod]
        public void Test_CheckInput_ChecksThatTheCurrencyExistsInTheList_ReturnsBool()
        {
            //Arrange
            mockList.Object.Add(new Mock<Currency>("EUR", 1.0, "DATE").Object);
            string input = "EUR";
            inputController.exchangeXML = mockList.Object; 

            //Act
            bool exists = inputController.ChecksExistence(input);

            //Assert
            Assert.IsTrue(exists);
        }
    }
}
