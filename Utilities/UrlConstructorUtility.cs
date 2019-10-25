using Microsoft.Extensions.Logging;
using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
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
            }

            try
            {
                StringBuilder builder = new StringBuilder(baseUrl);
                builder.AppendFormat("{0}/search/q?={1}", textToSearch);
                if (numberOfRecords > 0)
                {
                    builder.AppendFormat("{0}&num={1}", numberOfRecords);
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
