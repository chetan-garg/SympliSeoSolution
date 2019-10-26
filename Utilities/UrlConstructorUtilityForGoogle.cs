using Microsoft.Extensions.Logging;
using SympliSEOSolution.Constants;
using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.Utilities
{
    public class UrlConstructorUtilityForGoogle : IUrlConstructorUtility
    {
        private ILogger _logger = null;

        public UrlConstructorUtilityForGoogle(ILogger logger)
        {
            _logger = logger;
        }

        public string ConstructUrl(string baseUrl, int numberOfRecords, string textToSearch)
        {
            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(textToSearch))
            {
                _logger.LogError("Base URL and the search text is required for performing the search.");
                return string.Empty;
            }

            try
            {
                StringBuilder builder = new StringBuilder(baseUrl);
                builder.AppendFormat("{0}{1}", StringLiteralConstants.GOOGLE_SEARCH_QUERY, textToSearch);
                if (numberOfRecords > 0)
                {
                    builder.AppendFormat("&num={0}", numberOfRecords);
                }
                
                return builder.ToString();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "There is a problem with the url construction.");
                
            }
            return string.Empty;
        }
    }
}
