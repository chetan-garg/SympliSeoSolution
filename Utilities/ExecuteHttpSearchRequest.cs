using Microsoft.Extensions.Logging;
using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SympliSEOSolution.Workers
{
    public class ExecuteHttpSearchRequest : IExecuteSearch
    {
        ILogger _logger;
        IRequestProcessor _requestProcessor;

        public ExecuteHttpSearchRequest(ILogger logger, IRequestProcessor requestProcessor)
        {
            _logger = logger;
            _requestProcessor = requestProcessor;
        }
        public string ExecuteSearchRequest(HttpWebRequest request)
        {
            if (request == null)
            {
                _logger.LogError("The request can't be null! {0}", this.GetType());
                throw new ArgumentNullException();
            }
            
            using (HttpWebResponse response = (HttpWebResponse)_requestProcessor.ExecuteWebRequest(request))
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {
                    string html = reader.ReadToEnd();
                    return html;
                }
            }
            
        }
    }
}
