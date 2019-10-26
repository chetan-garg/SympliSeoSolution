using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface IExecuteSearch
    {
        string ExecuteSearchUrl(HttpWebRequest request);
    }
}
