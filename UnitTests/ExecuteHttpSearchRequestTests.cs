using NUnit.Framework;
using SympliSEOSolution.Workers;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using SympliSEOSolution.InterfaceLibrary;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;

namespace SympliSEOSolution.Workers.Tests
{
    [TestFixture()]
    public class ExecuteHttpSearchRequestTests
    {
        ILogger logger = null;
        IRequestProcessor requestProcessor = null;

        [SetUp]
        public void Setup()
        {
            logger = Substitute.For<ILogger>();
            requestProcessor = Substitute.For<IRequestProcessor>();

        }

        [Test()]
        public void ExecuteSearchUrlTest()
        {
            var searchProcessor = new ExecuteHttpSearchRequest(logger, requestProcessor);

            var response = new MockResponse();

            requestProcessor.ExecuteWebRequest(Arg.Any<WebRequest>()).Returns(response);
            var output = searchProcessor.ExecuteSearchRequest(Substitute.For<HttpWebRequest>());

            Assert.IsNotNull(output);
        }

        [Test()]
        public void ExecuteSearchUrlNullRequest_ShouldThrowException()
        {
            var searchProcessor = new ExecuteHttpSearchRequest(logger, requestProcessor);

            var ex = Assert.Throws(typeof(ArgumentNullException), () => searchProcessor.ExecuteSearchRequest(null));
            Assert.IsTrue(ex.Message.StartsWith("Value cannot be null."));
        }
    }

    public class MockResponse : HttpWebResponse
    {
        public override Stream GetResponseStream()
        {
            MemoryStream stream = new MemoryStream();
            
            Encoding encoding = Encoding.ASCII;
            stream.Write(encoding.GetBytes("<html></html>"), 0, encoding.GetBytes("<html></html>").Length);
            stream.Flush();
            return stream;
        }
    }
}