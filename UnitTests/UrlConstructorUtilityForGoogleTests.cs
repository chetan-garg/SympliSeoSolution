using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using SympliSEOSolution.Workers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.Workers.Tests
{
    [TestFixture()]
    public class UrlConstructorUtilityForGoogleTests
    {
        [Test()]
        public void ConstructUrlTest()
        {
            UrlConstructorUtilityForGoogle urlConst = new UrlConstructorUtilityForGoogle(Substitute.For<ILogger>());
            string url = urlConst.ConstructUrl("www.abc.com", 0, "test");
            Assert.IsNotNull(url);
            Assert.IsNotEmpty(url);
            Assert.AreEqual("www.abc.com/search?q=test", url);
        }

        [Test()]
        public void ConstructUrlTest_EmptyString()
        {
            UrlConstructorUtilityForGoogle urlConst = new UrlConstructorUtilityForGoogle(Substitute.For<ILogger>());
            string url = urlConst.ConstructUrl(string.Empty, 0, "test");
            Assert.IsNotNull(url);
            Assert.IsEmpty(url);

        }
    }
}