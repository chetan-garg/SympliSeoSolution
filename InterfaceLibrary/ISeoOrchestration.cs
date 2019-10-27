using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface ISeoOrchestration
    {
        public ISeoResponse GetUrlPositionsFrom(ISeoRequest request);
    }
}
