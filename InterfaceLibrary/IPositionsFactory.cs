using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface IPositionsFactory
    {
        IPositions GetUrlPositionsImplementation(EnumSeoEngineType seoEngineType);
    }
}
