using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface ISeoEngine
    {
        public List<ISeoResponse> GetSearchResponsePositions(ISeoRequest request);
    }
}
