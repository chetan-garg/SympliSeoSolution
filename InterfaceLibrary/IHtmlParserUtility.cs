using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface IHtmlParserUtility
    {
        string ParseAsXml(string html, string tagToRemove);
    }
}
