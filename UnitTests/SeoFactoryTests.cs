using Microsoft.Extensions.Logging;
using NUnit.Framework;
using SympliSEOSolution.InterfaceLibrary;
using SympliSEOSolution.SeoFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.SeoFactory.Tests
{
    [TestFixture()]
    public class SeoFactoryTests
    {
        [Test()]
        public void GetSeoEngineTest()
        {
            var sub1 = NSubstitute.Substitute.For<IExecuteSearch>();
            var sub2 = NSubstitute.Substitute.For<IUrlConstructorUtility>();
            var sub3 = NSubstitute.Substitute.For<IPositionsFactory>();
            var sub4 = NSubstitute.Substitute.For<IHtmlParserUtility>();
            var sub5 = NSubstitute.Substitute.For<ILogger>();

            var fac = new SeoFactory(sub1, sub2, sub3, sub4, sub5);
            var googleSeo = fac.GetSeoEngine(EnumSeoEngineType.Google);
            Assert.IsInstanceOf<ISeoEngine>(googleSeo);
            Assert.IsInstanceOf<GoogleSeoEngine.GoogleSeoEngine>(googleSeo);

            var bingSeo = fac.GetSeoEngine(EnumSeoEngineType.Bing);
            Assert.IsInstanceOf<ISeoEngine>(bingSeo);
            Assert.IsInstanceOf<GoogleSeoEngine.GoogleSeoEngine>(bingSeo);
        }
    }
}