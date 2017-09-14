namespace LeetCode
{
    public class LongestCommonPrefixSolution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null) return "";
            if (strs.Length == 0) return "";
            int i = 0;
            for (; i < strs[0].Length; i++)
            {
                for (int j = 0; j < strs.Length - 1; j++)
                {
                    if (i >= strs[j + 1].Length || strs[j][i] != strs[j + 1][i])
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }
            return strs[0].Substring(0, i); ;
        }

        public static void Test()
        {
            var solution = new LongestCommonPrefixSolution();
            var result = solution.LongestCommonPrefix(new string[1] { "aab" });
            System.Diagnostics.Debug.Assert(result == "aab");

            result = solution.LongestCommonPrefix(new string[2] { "aab", "abb" });
            System.Diagnostics.Debug.Assert(result == "a");

            result = solution.LongestCommonPrefix(new string[2] { "aa", "aaaa" });
            System.Diagnostics.Debug.Assert(result == "aa");
        }
    }
}
