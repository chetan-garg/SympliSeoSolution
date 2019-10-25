using SympliSEOSolution.SeoEntities;
using System;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface ISEOFactory
    {
        public ISeoEngine GetSeoEngine(EnumSeoEngineType seoEngineType);
    }
}
