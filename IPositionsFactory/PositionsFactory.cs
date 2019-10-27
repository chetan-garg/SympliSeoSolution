using Microsoft.Extensions.Logging;
using SympliSEOSolution.InterfaceLibrary;
using SympliSEOSolution.Workers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.PositionsFactory
{
    public class PositionsFactory : IPositionsFactory
    {
        ILogger _logger;

        public PositionsFactory(ILogger logger)
        {
            _logger = logger;
        }

        public IPositions GetUrlPositionsImplementation(EnumSeoEngineType seoEngineType)
        {
            switch (seoEngineType)
            {
                case EnumSeoEngineType.Google:
                    return new UrlPositions(_logger);
                case EnumSeoEngineType.Bing:
                    return new BingUrlPositions(_logger);
            }
            return null;
        }
    }
}
