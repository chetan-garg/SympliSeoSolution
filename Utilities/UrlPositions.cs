using Microsoft.Extensions.Logging;
using SympliSEOSolution.Constants;
using SympliSEOSolution.InterfaceLibrary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SympliSEOSolution.Workers
{
    public class UrlPositions : IPositions
    {
        ILogger _logger;
        public UrlPositions(ILogger logger)
        {
            _logger = logger;
        }
        public List<int> GetPositionOfOccurence(string html, string url)
        {
            XDocument doc = XDocument.Load(new StringReader(html));

            var nodes = doc.XPathSelectElements(StringLiteralConstants.DIV_NODES_WITH_HREF).ToList();
            List<int> xpathElements = new List<int>();
            foreach (var item in nodes)
            {
                var abc = item.Descendants(XName.Get("a")).Any(x => x.Attribute(XName.Get("href")).Value.Contains(url));
                if (abc)
                {
                    xpathElements.Add(nodes.IndexOf(item) + 1);
                }
            }

            return xpathElements;
        }
    }
}
