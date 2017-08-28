using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class LongestPalindromicSubstring
    {
        // Transform S into T.
        // For example, S = "abba", T = "^#a#b#b#a#$".
        // ^ and $ signs are sentinels appended to each end to avoid bounds checking
        private string PreProcess(string s)
        {
            int n = s.Length;
            if (n == 0) return "^$";
            var sb = new StringBuilder("^");
            for (int i = 0; i < n; i++)
            {
                sb.Append('#');
                sb.Append(s[i]);
            }
            sb.Append("#$");
            return sb.ToString();
        }

        //Manacher’s Algorithm
        public string LongestPalindrome(string s)
        {
            string T = PreProcess(s);
            int n = T.Length;
            int[] P = new int[n];
            int C = 0, R = 0;
            for (int i = 1; i < n - 1; i++)
            {
                int i_mirror = 2 * C - i;

                P[i] = (R > i) ? Math.Min(R - i, P[i_mirror]) : 0;

                // Attempt to expand palindrome centered at i
                while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
                    P[i]++;

                // If palindrome centered at i expand past R,
                // adjust center based on expanded palindrome.
                if (i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }

            // Find the maximum element in P.
            int maxLen = 0;
            int centerIndex = 0;
            for (int i = 1; i < n - 1; i++)
            {
                if (P[i] > maxLen)
                {
                    maxLen = P[i];
                    centerIndex = i;
                }
            }

            return s.Substring((centerIndex - 1 - maxLen) / 2, maxLen);
        }

        public static void Test()
        {
            var solution = new LongestPalindromicSubstring();
            string result = solution.LongestPalindrome("aaba");
            Debug.Assert(result == "aba");
        }
    }
}
