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
        public ISeoResponse GetUrlPositionsFrom(ISeoRequest request)
        {
            if (request != null)
            {
                object seoType;
                if (Enum.TryParse(typeof(EnumSeoEngineType), request.SeoEngineType, out seoType))
                {
                    var seoEngine = _factory.GetSeoEngine((EnumSeoEngineType) seoType);
                    if (seoEngine != null)
                    {
                        return seoEngine.GetSearchResponsePositions(request);
                    }
                }
            }


            return null;
        }
    }
}