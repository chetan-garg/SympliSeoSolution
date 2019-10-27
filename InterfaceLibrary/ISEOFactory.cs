using SympliSEOSolution.InterfaceLibrary;
using System;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface ISEOFactory
    {
        public ISeoEngine GetSeoEngine(EnumSeoEngineType seoEngineType);
    }
}
