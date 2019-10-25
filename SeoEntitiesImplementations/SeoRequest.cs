using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.SeoEntitiesImplementations
{
    public class SeoRequest : ISeoRequest
    {
        public string SearchText { get; set; }
        public string UrlFilter { get; set; }
    }
}
