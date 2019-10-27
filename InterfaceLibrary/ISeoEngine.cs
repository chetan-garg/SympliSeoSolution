using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface ISeoEngine
    {
        public ISeoResponse GetSearchResponsePositions(ISeoRequest request);
    }
}
