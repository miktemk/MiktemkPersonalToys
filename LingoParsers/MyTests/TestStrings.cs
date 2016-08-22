using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IlyaFrankParser;

namespace MyTests
{
    [TestClass]
    public class TestStrings
    {
        [TestMethod]
        public void Test_StripSymbols()
        {
            Assert.AreEqual("test-moi", WordHistogram.StripSymbols(",test-moi!!!..."));
            Assert.AreEqual("test", WordHistogram.StripSymbols(",test!!!..."));
            Assert.AreEqual("fhdhfejfdshfiwfsjkjfdo", WordHistogram.StripSymbols("...,fhdhfejfdshfiwfsjkjfdo?"));
            Assert.AreEqual("fhdhfejfdshfiwfsjkjfdo", WordHistogram.StripSymbols("...,fhdhfejfdshfiwfsjkjfdo    ?"));
            Assert.AreEqual("aaaa", WordHistogram.StripSymbols("aaaa?"));
            Assert.AreEqual("aaaa", WordHistogram.StripSymbols("?aaaa"));
            Assert.AreEqual("aaaa", WordHistogram.StripSymbols("aaaa"));
            Assert.AreEqual("", WordHistogram.StripSymbols("#$%^&*"));
            Assert.AreEqual("", WordHistogram.StripSymbols(""));
        }
    }
}
