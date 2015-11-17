using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_XMLRetriever_TestThatXMLRetrieverCallsTheGetXMLMethod_ReturnsAString()
        {
            //Arrange
            XMLRetriever retriever = new XMLRetriever();
            string expected = string.Empty;

            //Act
            string xml = retriever.GetXML();

            //Assert
            Assert.AreSame(expected, xml);
        }
    }
}
