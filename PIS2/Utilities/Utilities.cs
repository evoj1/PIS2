using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PIS2.Utilities
{
    public class Utilities
    {
        public static class StringUtils
        {
            public static string[] SplitWordsKeepQuotes(string input)
            {
                var matches = Regex.Matches(input, @"""([^""]*)""|(\S+)");
                var parts = new List<string>();

                foreach (Match match in matches)
                {
                    if (!string.IsNullOrEmpty(match.Groups[1].Value))
                        parts.Add(match.Groups[1].Value);
                    else if (!string.IsNullOrEmpty(match.Groups[2].Value))
                        parts.Add(match.Groups[2].Value);
                }

                return parts.ToArray();
            }
        }
    }
}
