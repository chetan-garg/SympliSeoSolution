using IL = SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using SympliSEOSolution.Constants;
using System.Net;
using SympliSEOSolution.InterfaceLibrary;

namespace GoogleSeoEngine
{
    public class GoogleSeoEngine : IL.ISeoEngine
    {
        IL.IExecuteSearch _requestProcessor = null;
        IL.IUrlConstructorUtility _urlConstructor = null;
        IL.IPositionsFactory _positions = null;
        IL.IHtmlParserUtility _parserUtility = null;

        public GoogleSeoEngine(IL.IExecuteSearch requestProcessor, IL.IUrlConstructorUtility urlConstructor, IL.IPositionsFactory positions, IL.IHtmlParserUtility parserUtility)
        {
            _requestProcessor = requestProcessor;
            _urlConstructor = urlConstructor;
            _positions = positions;
            _parserUtility = parserUtility;
        }

        public IL.ISeoResponse GetSearchResponsePositions(IL.ISeoRequest request)
        {
            if (request != null)
            {
                var urlToExecute = _urlConstructor.ConstructUrl(StringLiteralConstants.GOOGLE_BASE_URL, request.NumberOfRecords, request.SearchText);
                if (!string.IsNullOrWhiteSpace(urlToExecute))
                {
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlToExecute);
                    WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                    var htmlString = _requestProcessor.ExecuteSearchRequest(webRequest);
                    if (!string.IsNullOrWhiteSpace(htmlString))
                    {
                        var filteredHtml = _parserUtility.ParseAsXml(htmlString, StringLiteralConstants.TagsToRemove);
                        if (!string.IsNullOrWhiteSpace(filteredHtml))
                        {
                            object seoType;
                            if (Enum.TryParse(typeof(EnumSeoEngineType), request.SeoEngineType, out seoType))
                            {
                                var position = _positions.GetUrlPositionsImplementation((EnumSeoEngineType)seoType);
                                List<int> positions = position.GetPositionOfOccurence(filteredHtml, request.UrlFilter);
                                return ResponseConverter.ConvertIntToResponses(positions, request);
                            }
                        }

                    }

                }
            }

            return ResponseConverter.ConvertIntToResponses(null, request);
        }
    }
}
