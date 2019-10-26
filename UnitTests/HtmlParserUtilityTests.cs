using Microsoft.Extensions.Logging;
using NUnit.Framework;
using SympliSEOSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.Utilities.Tests
{
    [TestFixture()]
    public class HtmlParserUtilityTests
    {

        [Test()]
        public void ParseAsXmlTest()
        {
            NSubstituteAutoMocker.NSubstituteAutoMocker<HtmlParserUtility> util = new NSubstituteAutoMocker.NSubstituteAutoMocker<HtmlParserUtility>(new Type[] { typeof(ILogger) });
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("script", "/script");
            var output = util.ClassUnderTest.ParseAsXml("<html><script></script></html>", dictionary);
            Assert.IsNotNull(output);
            Assert.IsFalse(output.Contains("script"));
        }

        [Test()]
        public void ParseAsXmlTest_Fail()
        {
            NSubstituteAutoMocker.NSubstituteAutoMocker<HtmlParserUtility> util = new NSubstituteAutoMocker.NSubstituteAutoMocker<HtmlParserUtility>(new Type[] { typeof(ILogger) });
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("script", "/script");
            var output = util.ClassUnderTest.ParseAsXml(string.Empty, dictionary);
            Assert.IsEmpty(output);

            output = util.ClassUnderTest.ParseAsXml("<html><script></script></html>", null);
            Assert.IsEmpty(output);
        }
    }
}