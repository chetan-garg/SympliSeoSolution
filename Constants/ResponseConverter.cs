using SympliSEOSolution.InterfaceLibrary;
using SympliSEOSolution.SeoEntitiesImplementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SympliSEOSolution.Constants
{
    public static class ResponseConverter
    {
        public static ISeoResponse ConvertIntToResponses(List<int> positions, ISeoRequest seoRequest)
        {
            if (seoRequest == null || positions == null || positions.Count <= 0)
            {
                return new SeoResponse() { PositionNumbers = "0" };
            }
            ISeoResponse response = new SeoResponse();

            StringBuilder builder = new StringBuilder();
            foreach (int position in positions)
            {
                builder.AppendFormat("{0}, ", position);
            }
            string pos = builder.ToString();
            if (pos.EndsWith(", "))
            {
                response.PositionNumbers = pos.Remove(pos.LastIndexOf(","));
            }
            return response;
        }
    }
}
