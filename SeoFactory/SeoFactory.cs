using GoogleSeoEngine;
using SympliSEOSolution.MicrosoftSeo;
using SympliSEOSolution.InterfaceLibrary;
using System;
using SympliSEOSolution.Workers;
using Microsoft.Extensions.Logging;

namespace SympliSEOSolution.SeoFactory
{
    public class SeoFactory : ISEOFactory
    {
        IExecuteSearch _requestProcessor = null;
        IUrlConstructorUtility _urlConstructor = null;
        IPositionsFactory _positions = null;
        IHtmlParserUtility _parserUtility = null;
        ILogger _logger = null;
        public SeoFactory(IExecuteSearch requestProcessor, IUrlConstructorUtility urlConstructor, IPositionsFactory positions, IHtmlParserUtility parserUtility, ILogger logger)
        {
            _requestProcessor = requestProcessor;
            _urlConstructor = urlConstructor;
            _positions = positions;
            _parserUtility = parserUtility;
            _logger = logger;
        }
        public ISeoEngine GetSeoEngine(EnumSeoEngineType seoEngineType)
        {
            switch (seoEngineType)
            {
                case EnumSeoEngineType.Google:
                    return new GoogleSeoEngine.GoogleSeoEngine(_requestProcessor, _urlConstructor, _positions, _parserUtility);
               case EnumSeoEngineType.Bing:
                    return new MicrosoftSeoEngine(_requestProcessor, _urlConstructor, _positions, _parserUtility);
                default:
                    break;
            }

            return null;
        }
    }
}
