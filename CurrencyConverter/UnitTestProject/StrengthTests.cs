﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter;
using System.Collections.Generic;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class ComparisonTests
    {
        Mock<Dictionary<string, Dictionary<string, double>>> mockXML;
        Mock<Dictionary<string, double>> mockXMLInner;

        [TestInitialize]
        public void Setup()
        {
            mockXML = new Mock<Dictionary<string, Dictionary<string, double>>>();
            mockXMLInner = new Mock<Dictionary<string, double>>();
        }

        [TestMethod]
        public void Test_Strength_ReturnsAnEmptyDictionary_WhenGivenAnEmptyDictionary()
        {
            Comparison comparison = new Comparison(mockXML.Object);

            Dictionary<string,double> actual = comparison.strength();

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Test_Strength_ReturnsAnDictionaryOfOneElement_WhenGiveAnDictionaryOfOneElement()
        {
            mockXMLInner.Object.Add("EUR", 1);
            mockXML.Object.Add("12-12-2012", mockXMLInner.Object);
            Comparison comparison = new Comparison(mockXML.Object);
            Dictionary<string, double> given = new Dictionary<string, double>();

            Dictionary<string, double> actual = comparison.strength();

            Assert.AreEqual(1, actual.Count);
        }

    }
}
