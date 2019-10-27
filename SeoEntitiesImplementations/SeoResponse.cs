using Microsoft.AspNetCore.Mvc;
using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.SeoEntitiesImplementations
{
    [ResponseCache]
    public class SeoResponse : ISeoResponse
    {
        public string PositionNumbers { get; set; }
    }
}
