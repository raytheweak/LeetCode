using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LongestSubstringWithoutRepeatingCharactersSolution
    {
        public int LengthOfLongestSubstring(String s)
        {
            int n = s.Length, ans = 0;
            var map = new Dictionary<char, int>();
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]], i);
                }
                ans = Math.Max(ans, j - i + 1);
                map[s[j]] = j + 1;
            }
            return ans;
        }
    }
}
