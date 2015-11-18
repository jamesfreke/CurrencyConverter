using CurrencyConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void Test_Strength_ReturnsAnEmptyList_WhenGivenAnEmptyList()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.strength();

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_Strength_ReturnsAnListOfOneElement_WhenGiveAListOfOneElement()
        {
            mockXML.Object.Add(new Mock<Currency>("EU",1,"12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.strength();

            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void Test_Strength_ReturnsASortedListOfStrength_WhenGivenAListOfThreeElements()
        {
            Mock<Currency> a = new Mock<Currency>("EU", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("GBP", 0.5, "12-12-2012");
            Mock<Currency> c = new Mock<Currency>("USD", 3, "12-12-2012");

            mockXML.Object.Add(a.Object);
            mockXML.Object.Add(b.Object);
            mockXML.Object.Add(c.Object);
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> expected = new List<Currency>();
            expected.Add(c.Object);
            expected.Add(a.Object);
            expected.Add(b.Object);

            List<Currency> actual = comparison.strength();

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [TestMethod]
        public void Test_StrongThan_ReturnsAnEmptyList_WhenGivenAnEmptyList()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.strength();

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_StrongThan_ReturnsAnListOfOneElementOfEURate_WhenGivenAListOfOneElementWithAnEmptyString()
        {
            mockXML.Object.Add(new Mock<Currency>("EU", 1, "12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.strength();

            Assert.AreEqual(1, actual.Count);
        }

    }
}
