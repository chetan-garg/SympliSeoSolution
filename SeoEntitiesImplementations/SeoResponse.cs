using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.SeoEntitiesImplementations
{
    public class SeoResponse : ISeoResponse
    {
        public string TextSearched { get; set; }
        public string FilterText { get; set; }
        public int PositionNumber { get; set; }
    }
}
