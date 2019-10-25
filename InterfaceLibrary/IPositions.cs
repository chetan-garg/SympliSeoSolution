using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.InterfaceLibrary
{
    public interface IPositions
    {
        List<int> GetPositionOfOccurence(string html, string url);
    }
}
