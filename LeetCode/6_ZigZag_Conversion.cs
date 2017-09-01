using System;
using System.Text;

namespace LeetCode
{
    public class ZigZagConversion
    {
        //It's like periodic function in mathematics.
        public string Convert(string s, int numRows)
        {
            if (s == null || numRows < 1) throw new ArgumentException();
            if (s == "" || numRows == 1) return s;
            int n = s.Length;
            if (n == 1) return s;
            var sb = new StringBuilder(n);
            for (int i = 0; i < numRows; i++)
            {
                //(2 * numRows - 2) is the period T
                for (int j = 0; j < n / (2 * numRows - 2) + 1; j++)
                {
                    int index = j * (2 * numRows - 2) + i;
                    if (index < n) sb.Append(s[index]);
                    if (i != 0 && i != numRows - 1)
                    {
                        index = j * (2 * numRows - 2) + 2 * numRows - 3 - i + 1;
                        if (index < n) sb.Append(s[index]);
                    }
                }
            }
            return sb.ToString();
        }

        public static void Test()
        {
            var solution = new ZigZagConversion();
            var result = solution.Convert("abcdefghij", 3);
            System.Diagnostics.Debug.Assert(result == "aeibdfhjcg");
        }
    }
}
