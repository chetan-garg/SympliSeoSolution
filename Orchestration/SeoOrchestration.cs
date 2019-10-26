using SympliSEOSolution.InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.Orchestration
{
    public class SeoOrchestration : ISeoOrchestration
    {
        ISEOFactory _factory;
        public SeoOrchestration(ISEOFactory factory)
        {
            _factory = factory;
        }
        public ISeoResponse GetUrlPositionsFromGoogle(ISeoRequest request)
        {
            if (request != null)
            {
                var seoEngine = _factory.GetSeoEngine(EnumSeoEngineType.Google);
                if (seoEngine != null)
                {
                    return seoEngine.GetSearchResponsePositions(request);
                }
            }


            return null;
        }
    }
}