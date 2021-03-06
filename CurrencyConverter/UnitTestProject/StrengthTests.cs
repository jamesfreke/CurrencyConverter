﻿using CurrencyConverter;
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

            List<Currency> actual = comparison.strength("");

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_Strength_ReturnsAnListOfOneElement_WhenGiveAListOfOneElement()
        {
            mockXML.Object.Add(new Mock<Currency>("EUR",1,"12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.strength("");

            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void Test_Strength_ReturnsASortedListOfStrength_WhenGivenAListOfThreeElements()
        {
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
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

            List<Currency> actual = comparison.strength("");

            Assert.IsTrue(actual.SequenceEqual(expected,new CurrencyComparerSymbolAndValue()));
        }

        [TestMethod]
        public void Test_Strength_ReturnsASortedListOfStrength_WhenGivenAListOfThreeElementsWithStringOfGBP()
        {
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("GBP", 0.5, "12-12-2012");
            Mock<Currency> c = new Mock<Currency>("USD", 3, "12-12-2012");

            mockXML.Object.Add(a.Object);
            mockXML.Object.Add(b.Object);
            mockXML.Object.Add(c.Object);
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> expected = new List<Currency>();
            expected.Add(new Currency("GBP",1,"12-12-2012"));
            expected.Add(new Currency("EUR",2,"12-12-2012"));
            expected.Add(new Currency("USD",6,"12-12-2012"));

            List<Currency> actual = comparison.strength("GBP");

            Assert.IsTrue(actual.SequenceEqual(expected,new CurrencyComparerSymbolAndValue()));
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
            mockXML.Object.Add(new Mock<Currency>("EUR", 1, "12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.StrongerThan("");

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_StrongThan_ReturnsAListOfOneElements_WhenGivenAListOfThreeElementsAndEmptyString()
        {
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
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
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("GBP", 0.5, "12-12-2012");
            Mock<Currency> c = new Mock<Currency>("USD", 3, "12-12-2012");

            mockXML.Object.Add(a.Object);
            mockXML.Object.Add(b.Object);
            mockXML.Object.Add(c.Object);
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> expected = new List<Currency>();
            expected.Add(new Currency("EUR",2,"12-12-2012"));
            expected.Add(new Currency("USD",6,"12-12-2012"));

            List<Currency> actual = comparison.StrongerThan("GBP");

            Assert.IsTrue(actual.SequenceEqual(expected,new CurrencyComparerSymbolAndValue()));
        }

         [TestMethod]
        public void Test_HighestOrLowestRate_ReturnsAEmptyCurrency_WhenGivenAnEmptyListAnEmptyStringAndTrue()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            Currency actual = comparison.HighestOrLowestRate("",true,mockXML.Object);

            Assert.IsTrue(actual is Currency);
        }

        [TestMethod]
         public void Test_HighestOrLowestRate_ReturnsACurrencyWithTheValueOne_WhenGivenAListOfOneElementWithEURRateOneAndTrue()
        {
            mockXML.Object.Add(new Mock<Currency>("EUR", 1, "12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            Currency actual = comparison.HighestOrLowestRate("EUR", true, mockXML.Object);

            Assert.AreEqual(1, actual.value);
        }

        [TestMethod]
        public void Test_HighestOrLowestRate_ReturnsACurrencyWithTheValueFive_WhenGivenAListOfThreeElementsAndTrue()
        {
            mockXML.Object.Add(new Mock<Currency>("EUR", 1, "12-12-2012").Object);
            mockXML.Object.Add(new Mock<Currency>("EUR", 0, "12-12-2012").Object);
            mockXML.Object.Add(new Mock<Currency>("EUR", 5, "12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            Currency actual = comparison.HighestOrLowestRate("EUR", true, mockXML.Object);

            Assert.AreEqual(5, actual.value);
        }

        [TestMethod]
        public void Test_HighestOrLowestRate_ReturnsACurrencyWithTheValue0_WhenGivenAListOfThreeElementsAndFalse()
        {
            mockXML.Object.Add(new Mock<Currency>("EUR", 1, "12-12-2012").Object);
            mockXML.Object.Add(new Mock<Currency>("EUR", 0, "12-12-2012").Object);
            mockXML.Object.Add(new Mock<Currency>("EUR", 5, "12-12-2012").Object);
            Comparison comparison = new Comparison(mockXML.Object);

            Currency actual = comparison.HighestOrLowestRate("EUR", false, mockXML.Object);

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
            distinctDoesNotLikeMockLists.Add(new Mock<Currency>("EUR", 1, "12-12-2012").Object);
            distinctDoesNotLikeMockLists.Add(new Mock<Currency>("EUR", 0, "12-12-2012").Object);
            Comparison comparison = new Comparison(distinctDoesNotLikeMockLists);

            List<Currency> actual = comparison.HighestAndLowestPerCurrency("");

            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public void Test_HighestAndLowestPerCurrency_ReturnsAListOfTwoElements_WhenGivenAListOfFiveElementsFromTheSameSymbol()
        {
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EUR", 0, "12-12-2012");
            Mock<Currency> c = new Mock<Currency>("EUR", 2, "12-12-2012");
            Mock<Currency> d = new Mock<Currency>("EUR", 3, "12-12-2012");
            Mock<Currency> e = new Mock<Currency>("EUR", 4, "12-12-2012");
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

            Assert.IsTrue(actual.SequenceEqual(expected,new CurrencyComparerSymbolAndValue()));
        }

        [TestMethod]
        public void Test_HighestAndLowestPerCurrency_ReturnsAListOfTwoElements_WhenGivenAListOfFiveElementsFromTheSameSymbolForGBP()
        {
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EUR", 1, "13-12-2012");
            Mock<Currency> c = new Mock<Currency>("EUR", 2, "14-12-2012");
            Mock<Currency> d = new Mock<Currency>("EUR", 3, "15-12-2012");
            Mock<Currency> e = new Mock<Currency>("EUR", 4, "16-12-2012");
            Mock<Currency> f = new Mock<Currency>("GBP", 0.5, "12-12-2012");
            Mock<Currency> g = new Mock<Currency>("GBP", 0.5, "13-12-2012");
            Mock<Currency> h = new Mock<Currency>("GBP", 0.5, "14-12-2012");
            Mock<Currency> i = new Mock<Currency>("GBP", 0.5, "15-12-2012");
            Mock<Currency> j = new Mock<Currency>("GBP", 0.5, "16-12-2012");
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
            distinctDoesNotLikeMockLists.Add(j.Object);
            Comparison comparison = new Comparison(distinctDoesNotLikeMockLists);

            List<Currency> expected = new List<Currency>();
            expected.Add(new Currency("EUR",2,"12-12-2012"));
            expected.Add(new Currency("EUR",8,"16-12-2012"));
            expected.Add(new Currency("GBP", 1, "12-12-2012"));
            expected.Add(new Currency("GBP", 1, "12-12-2012"));

            List<Currency> actual = comparison.HighestAndLowestPerCurrency("GBP");

            Assert.IsTrue(actual.SequenceEqual(expected,new CurrencyComparerSymbolAndValue()));
        }

        [TestMethod]
        public void Test_GreatestOrSmallestChangeNintyDays_ReturnsAnEmptyList_WhenGivenAnEmptyList()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            List<Currency> actual = comparison.GreatestOrSmallestChangeNintyDays("", true);

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_GreatestOrSmallestChangeNintyDays_ReturnsAListOfTwoElements_WhenGivenAListOfFiveElementsFromTheSameSymbol()
        {
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EUR", 1, "13-12-2012");
            Mock<Currency> c = new Mock<Currency>("EUR", 4, "14-12-2012");
            Mock<Currency> d = new Mock<Currency>("GBP", 3, "12-12-2012");
            Mock<Currency> e = new Mock<Currency>("GBP", 3, "13-12-2012");
            Mock<Currency> f = new Mock<Currency>("GBP", 3, "14-12-2012");
            Mock<Currency> g = new Mock<Currency>("USD", 4, "12-12-2012");
            Mock<Currency> h = new Mock<Currency>("USD", 4, "13-12-2012");
            Mock<Currency> i = new Mock<Currency>("USD", 4, "14-12-2012");
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
            expected.Add(new Currency("EUR", 3));

            List<Currency> actual = comparison.GreatestOrSmallestChangeNintyDays("", true);

            Assert.IsTrue(actual.SequenceEqual(expected,new CurrencyComparerSymbolAndValue()));      
        }

        [TestMethod]
        public void Test_GreatestOrSmallestChangeNintyDays_ReturnsAListOfTenElements_WhenGivenAListOfTenDifferentCurrencies()
        {
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EUR", 0, "13-12-2012");
            Mock<Currency> c = new Mock<Currency>("EUR", 4, "14-12-2012");
            Mock<Currency> d = new Mock<Currency>("GBP", 2, "12-12-2012");
            Mock<Currency> e = new Mock<Currency>("GBP", 3, "13-12-2012");
            Mock<Currency> f = new Mock<Currency>("GBP", 3, "14-12-2012");
            Mock<Currency> g = new Mock<Currency>("USD", 4, "12-12-2012");
            Mock<Currency> h = new Mock<Currency>("USD", 4, "13-12-2012");
            Mock<Currency> i = new Mock<Currency>("USD", 4, "14-12-2012");
            Mock<Currency> j = new Mock<Currency>("JPY", 4, "12-12-2012");
            Mock<Currency> k = new Mock<Currency>("JPY", 10, "13-12-2012");
            Mock<Currency> l = new Mock<Currency>("BGN", 5, "12-12-2012");
            Mock<Currency> m = new Mock<Currency>("BGN", 4, "13-12-2012");
            Mock<Currency> n = new Mock<Currency>("CZK", 7, "12-12-2012");
            Mock<Currency> o = new Mock<Currency>("CZK", 4, "13-12-2012");
            Mock<Currency> p = new Mock<Currency>("RON", 7, "12-12-2012");
            Mock<Currency> q = new Mock<Currency>("RON", 4, "13-12-2012");
            Mock<Currency> r = new Mock<Currency>("RUB", 24, "12-12-2012");
            Mock<Currency> s = new Mock<Currency>("RUB", 4, "13-12-2012");
            Mock<Currency> t = new Mock<Currency>("HRK", 44, "12-12-2012");
            Mock<Currency> u = new Mock<Currency>("HRK", 4, "13-12-2012");
            Mock<Currency> v = new Mock<Currency>("ZAR", 14, "12-12-2012");
            Mock<Currency> w = new Mock<Currency>("ZAR", 4, "13-12-2012");
            List<Currency> distinctDoesNotLikeMockLists = new List<Currency>() {
                a.Object, b.Object,c.Object,d.Object,e.Object,f.Object,g.Object,h.Object,
            i.Object,j.Object,k.Object,l.Object,m.Object,n.Object,o.Object,p.Object,q.Object,
            r.Object,s.Object,t.Object,u.Object,v.Object,w.Object};

            Comparison comparison = new Comparison(distinctDoesNotLikeMockLists);

            List<Currency> expected = new List<Currency>(){
            new Currency("HRK", -40),
            new Currency("RUB", -20),
            new Currency("ZAR", -10),
            new Currency("CZK", -3),
            new Currency("RON", -3),
            new Currency("BGN", -1),
            new Currency("USD", 0),
            new Currency("GBP", 1),
            new Currency("EUR", 4),
            new Currency("JPY", 6)
            };

            List<Currency> actual = comparison.GreatestOrSmallestChangeNintyDays("", false);

            Assert.IsTrue(actual.SequenceEqual(expected, new CurrencyComparerSymbolAndValue()));
        }

        [TestMethod]
        public void Test_GreatestOrSmallestChangeNintyDays_ReturnsAListOfTwoElements_WhenGivenAListOfFiveElementsFromTheSameSymbolForGBP()
        {
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EUR", 2, "13-12-2012");
            Mock<Currency> c = new Mock<Currency>("EUR", 3, "14-12-2012");
            Mock<Currency> d = new Mock<Currency>("GBP", 0.5, "12-12-2012");
            Mock<Currency> e = new Mock<Currency>("GBP", 0.5, "13-12-2012");
            Mock<Currency> f = new Mock<Currency>("GBP", 0.5, "14-12-2012");
            Mock<Currency> g = new Mock<Currency>("USD", 4, "12-12-2012");
            Mock<Currency> h = new Mock<Currency>("USD", 4, "13-12-2012");
            Mock<Currency> i = new Mock<Currency>("USD", 4, "14-12-2012");
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
            expected.Add(new Currency("EUR", 4));

            List<Currency> actual = comparison.GreatestOrSmallestChangeNintyDays("GBP", true);

            Assert.IsTrue(actual.SequenceEqual(expected,new CurrencyComparerSymbolAndValue()));
        }

        [TestMethod]
        public void Test_GreatestOrSmallestChangeNintyDays_ReturnsAListOfTenElements_WhenGivenAListOfTenDifferentCurrenciesWithGBP()
        {
            Mock<Currency> a = new Mock<Currency>("EUR", 1, "12-12-2012");
            Mock<Currency> b = new Mock<Currency>("EUR", 0, "13-12-2012");
            Mock<Currency> c = new Mock<Currency>("EUR", 4, "14-12-2012");
            Mock<Currency> d = new Mock<Currency>("GBP", 0.5, "12-12-2012");
            Mock<Currency> e = new Mock<Currency>("GBP", 0.5, "13-12-2012");
            Mock<Currency> f = new Mock<Currency>("GBP", 0.5, "14-12-2012");
            Mock<Currency> g = new Mock<Currency>("USD", 4, "12-12-2012");
            Mock<Currency> h = new Mock<Currency>("USD", 4, "13-12-2012");
            Mock<Currency> i = new Mock<Currency>("USD", 4, "14-12-2012");
            Mock<Currency> j = new Mock<Currency>("JPY", 4, "12-12-2012");
            Mock<Currency> k = new Mock<Currency>("JPY", 10, "13-12-2012");
            Mock<Currency> l = new Mock<Currency>("BGN", 5, "12-12-2012");
            Mock<Currency> m = new Mock<Currency>("BGN", 4, "13-12-2012");
            Mock<Currency> n = new Mock<Currency>("CZK", 7, "12-12-2012");
            Mock<Currency> o = new Mock<Currency>("CZK", 4, "13-12-2012");
            Mock<Currency> p = new Mock<Currency>("RON", 7, "12-12-2012");
            Mock<Currency> q = new Mock<Currency>("RON", 4, "13-12-2012");
            Mock<Currency> r = new Mock<Currency>("RUB", 24, "12-12-2012");
            Mock<Currency> s = new Mock<Currency>("RUB", 4, "13-12-2012");
            Mock<Currency> t = new Mock<Currency>("HRK", 44, "12-12-2012");
            Mock<Currency> u = new Mock<Currency>("HRK", 4, "13-12-2012");
            Mock<Currency> v = new Mock<Currency>("ZAR", 14, "12-12-2012");
            Mock<Currency> w = new Mock<Currency>("ZAR", 4, "13-12-2012");
            List<Currency> distinctDoesNotLikeMockLists = new List<Currency>() {
                a.Object, b.Object,c.Object,d.Object,e.Object,f.Object,g.Object,h.Object,
            i.Object,j.Object,k.Object,l.Object,m.Object,n.Object,o.Object,p.Object,q.Object,
            r.Object,s.Object,t.Object,u.Object,v.Object,w.Object};

            Comparison comparison = new Comparison(distinctDoesNotLikeMockLists);

            List<Currency> expected = new List<Currency>(){
            new Currency("HRK", -80),
            new Currency("RUB", -40),
            new Currency("ZAR", -20),
            new Currency("CZK", -6),
            new Currency("RON", -6),
            new Currency("BGN", -2),
            new Currency("GBP", 0),
            new Currency("USD", 0),
            new Currency("EUR", 8), 
            new Currency("JPY", 12)
            };

            List<Currency> actual = comparison.GreatestOrSmallestChangeNintyDays("GBP", false);

            Assert.IsTrue(actual.SequenceEqual(expected, new CurrencyComparerSymbolAndValue()));
        }

    }
}
