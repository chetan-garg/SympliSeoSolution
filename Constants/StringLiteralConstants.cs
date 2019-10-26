using System;
using System.Collections.Generic;

namespace SympliSEOSolution.Constants
{
    public static class StringLiteralConstants
    {
        private static Dictionary<string, string> _tagsToRemove;

        public const string DIV_NODES_WITH_HREF = @"//div[@id= 'main']/div[.//a[contains(@href, '/url?q=')]]";
        public const string GOOGLE_BASE_URL = @"https://www.google.com";
        public const string GOOGLE_SEARCH_QUERY = @"/search?q=";
        public static Dictionary<string, string> TagsToRemove
        {
            get
            {
                if (_tagsToRemove == null)
                {
                    _tagsToRemove = new Dictionary<string, string>();
                    _tagsToRemove.Add("<input", ">");
                    _tagsToRemove.Add("<img", ">");
                    _tagsToRemove.Add("<meta", ">");
                    _tagsToRemove.Add("<script", "/script>");
                    _tagsToRemove.Add("<style", "/style>");
                }

                return _tagsToRemove;
            }
            set
            {
                _tagsToRemove = value;
            }
        }
    }
}
