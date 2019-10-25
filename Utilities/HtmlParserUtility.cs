using Microsoft.Extensions.Logging;
using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserUtility
{
    public class HtmlParserUtility : IHtmlParserUtility
    {
        private ILogger _logger;

        public HtmlParserUtility(ILogger logger)
        {
            _logger = logger;
        }

        public string ParseAsXml(string html, Dictionary<string, string> tagPairsToRemove)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                if (_logger != null) _logger.LogError("The input html provided is empty.");
                return string.Empty;
            }

            if (tagPairsToRemove == null || tagPairsToRemove.Count <= 0)
            {
                if (_logger != null) _logger.LogError("The tag to be removed has not been provided.");
                return string.Empty;
            }
            foreach (string key in tagPairsToRemove.Keys)
            {
                string startTagName = key.StartsWith("<") ? key : string.Format("<{0}", key);
                string endTagName = tagPairsToRemove[key].EndsWith(">") ? tagPairsToRemove[key] : string.Format("{0}>", tagPairsToRemove[key]);
                while (html.IndexOf(startTagName) > 0)
                {
                    int startInputIndexOf = html.IndexOf(startTagName);
                    int endTagIndex = html.IndexOf(endTagName, startInputIndexOf);
                    html = html.Remove(startInputIndexOf, (endTagIndex - startInputIndexOf) + endTagName.Length);
                }
            }

            return html;
        }
    }
}
