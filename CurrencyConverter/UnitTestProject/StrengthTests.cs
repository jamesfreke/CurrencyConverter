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
            expected.Add(b.Object);
            expected.Add(a.Object);
            expected.Add(c.Object);

            List<Currency> actual = comparison.strength();

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [TestMethod]
        public void Test_StrongThan_ReturnsAnEmptyList_WhenGivenAnEmptyList()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.StrongerThan("");

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_StrongThan_ReturnsAnListOfZeroElements_WhenGivenAListOfOneElementWithAnEmptyString()
        {
            mockXML.Object.Add(new Mock<Currency>("EU", 1, "12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.StrongerThan("");

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_StrongThan_ReturnsAListOfOneElements_WhenGivenAListOfThreeElementsAndEmptyString()
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

            List<Currency> actual = comparison.StrongerThan("");

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [TestMethod]
        public void Test_StrongThan_ReturnsAListOfTwoElements_WhenGivenAListOfThreeElementsAndComparingToGBPRate()
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

            List<Currency> actual = comparison.StrongerThan("GBP");

            Assert.IsTrue(actual.All(d => expected.Contains(d)));
        }

         [TestMethod]
        public void Test_HighestOrLowestRate_ReturnsAEmptyCurrency_WhenGivenAnEmptyListAnEmptyStringAndTrue()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            Currency actual = comparison.HighestOrLowestRate("",true);

            Assert.IsTrue(actual is Currency);
        }

        [TestMethod]
         public void Test_HighestOrLowestRate_ReturnsACurrencyWithTheValueOne_WhenGivenAListOfOneElementWithEURateOneAndTrue()
        {
            mockXML.Object.Add(new Mock<Currency>("EU", 1, "12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            Currency actual = comparison.HighestOrLowestRate("EU",true);

            Assert.AreEqual(1, actual.value);
        }

        [TestMethod]
        public void Test_HighestOrLowestRate_ReturnsACurrencyWithTheValueFive_WhenGivenAListOfThreeElementsAndTrue()
        {
            mockXML.Object.Add(new Mock<Currency>("EU", 1, "12-12-2012").Object);
            mockXML.Object.Add(new Mock<Currency>("EU", 0, "12-12-2012").Object);
            mockXML.Object.Add(new Mock<Currency>("EU", 5, "12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            Currency actual = comparison.HighestOrLowestRate("EU",true);

            Assert.AreEqual(5, actual.value);
        }

        [TestMethod]
        public void Test_HighestOrLowestRate_ReturnsACurrencyWithTheValue0_WhenGivenAListOfThreeElementsAndFalse()
        {
            mockXML.Object.Add(new Mock<Currency>("EU", 1, "12-12-2012").Object);
            mockXML.Object.Add(new Mock<Currency>("EU", 0, "12-12-2012").Object);
            mockXML.Object.Add(new Mock<Currency>("EU", 5, "12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            Currency actual = comparison.HighestOrLowestRate("EU", false);

            Assert.AreEqual(0, actual.value);
        }

        [TestMethod]
        public void Test_HighestAndLowestPerCurrency_ReturnsAnEmptyList_WhenGivenAnEmptyList()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.HighestAndLowestPerCurrency("");

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_HighestAndLowestPerCurrency_ReturnsAListOfTwoElements_WhenGivenAListOfTwoElements()
        {
            List<Currency> distinctDoesNotLikeMockLists = new List<Currency>();
            distinctDoesNotLikeMockLists.Add(new Mock<Currency>("EU", 1, "12-12-2012").Object);
            distinctDoesNotLikeMockLists.Add(new Mock<Currency>("EU", 0, "12-12-2012").Object);
            Comparison comparison = new Comparison(distinctDoesNotLikeMockLists);

            List<Currency> actual = comparison.HighestAndLowestPerCurrency("");

            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public void Test_HighestAndLowestPerCurrency_ReturnsAListOfTwoElements_WhenGivenAListOfFiveElementsFromTheSameSymbol()
        {
            Mock<Currency> a = new Mock<Currency>("EU", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EU", 0, "12-12-2012");
            Mock<Currency> c = new Mock<Currency>("EU", 2, "12-12-2012");
            Mock<Currency> d = new Mock<Currency>("EU", 3, "12-12-2012");
            Mock<Currency> e = new Mock<Currency>("EU", 4, "12-12-2012");
            List<Currency> distinctDoesNotLikeMockLists = new List<Currency>();

            distinctDoesNotLikeMockLists.Add(a.Object);
            distinctDoesNotLikeMockLists.Add(b.Object);
            distinctDoesNotLikeMockLists.Add(c.Object);
            distinctDoesNotLikeMockLists.Add(d.Object);
            distinctDoesNotLikeMockLists.Add(e.Object);
            Comparison comparison = new Comparison(distinctDoesNotLikeMockLists);

            List<Currency> expected = new List<Currency>();
            expected.Add(b.Object);
            expected.Add(e.Object);

            List<Currency> actual = comparison.HighestAndLowestPerCurrency("");

            Assert.IsTrue(actual.All(x => expected.Contains(x)));
        }

        [TestMethod]
        public void Test_GreatestChangeNintyDays_ReturnsAnEmptyList_WhenGivenAnEmptyList()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.GreatestChangeNintyDays("");

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_HighestAndLowestPerCurrency_ReturnsAListOfTwoElements_WhenGivenAListOfFiveElementsFromTheSameSymbol()
        {
            Mock<Currency> a = new Mock<Currency>("EU", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EU", 0, "12-12-2012");
            Mock<Currency> c = new Mock<Currency>("EU", 4, "12-12-2012");
            Mock<Currency> d = new Mock<Currency>("GBP", 2, "12-12-2012");
            Mock<Currency> e = new Mock<Currency>("GBP", 3, "12-12-2012");
            Mock<Currency> f = new Mock<Currency>("GBP", 3, "12-12-2012");
            Mock<Currency> g = new Mock<Currency>("USD", 4, "12-12-2012");
            Mock<Currency> h = new Mock<Currency>("USD", 4, "12-12-2012");
            Mock<Currency> i = new Mock<Currency>("USD", 4, "12-12-2012");
            List<Currency> distinctDoesNotLikeMockLists = new List<Currency>();

            distinctDoesNotLikeMockLists.Add(a.Object);
            distinctDoesNotLikeMockLists.Add(b.Object);
            distinctDoesNotLikeMockLists.Add(c.Object);
            distinctDoesNotLikeMockLists.Add(d.Object);
            distinctDoesNotLikeMockLists.Add(e.Object);
            distinctDoesNotLikeMockLists.Add(f.Object);
            distinctDoesNotLikeMockLists.Add(g.Object);
            distinctDoesNotLikeMockLists.Add(h.Object);
            distinctDoesNotLikeMockLists.Add(i.Object);
            Comparison comparison = new Comparison(distinctDoesNotLikeMockLists);

            List<Currency> expected = new List<Currency>();
            expected.Add(new Currency("EU",4);

            List<Currency> actual = comparison.HighestAndLowestPerCurrency("");

            Assert.IsTrue(actual.Count==1 && );

            //divide yen by dollar ot get dollars to yens
        }

    }
}
