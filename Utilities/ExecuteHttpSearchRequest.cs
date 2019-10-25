using Microsoft.Extensions.Logging;
using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SympliSEOSolution.Utilities
{
    public class ExecuteHttpSearchRequest : IExecuteSearch
    {
        ILogger _logger;
        public ExecuteHttpSearchRequest(ILogger logger)
        {
            _logger = logger;
        }
        public string ExecuteSearchUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                _logger.LogError("The url is empty cannot perform the search! {0}", this.GetType());
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
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
