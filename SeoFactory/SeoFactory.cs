using GoogleSeoEngine;
using SympliSEOSolution.InterfaceLibrary;
using System;

namespace SeoFactory
{
    public class SeoFactory : ISEOFactory
    {
        IExecuteSearch _requestProcessor = null;
        IUrlConstructorUtility _urlConstructor = null;
        IPositions _positions = null;
        IHtmlParserUtility _parserUtility = null;

        public SeoFactory(IExecuteSearch requestProcessor, IUrlConstructorUtility urlConstructor, IPositions positions, IHtmlParserUtility parserUtility)
        {
            _requestProcessor = requestProcessor;
            _urlConstructor = urlConstructor;
            _positions = positions;
            _parserUtility = parserUtility;
        }
        public ISeoEngine GetSeoEngine(EnumSeoEngineType seoEngineType)
        {
            switch (seoEngineType)
            {
                case EnumSeoEngineType.Google:
                    return new GoogleSeoEngine.GoogleSeoEngine(_requestProcessor, _urlConstructor, _positions, _parserUtility);
               case EnumSeoEngineType.Bing:
                    break;
                default:
                    break;
            }

            return null;
        }
    }
}
