using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SympliSEOSolution.Workers
{
    public class WebRequestProcessor : IRequestProcessor
    {
        public WebResponse ExecuteWebRequest(WebRequest request)
        {
            if (request != null)
            {
                return request.GetResponse();
            }
            return null;
        }
    }
}
