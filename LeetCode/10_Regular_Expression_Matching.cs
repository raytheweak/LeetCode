namespace LeetCode
{
    public class RegularExpressionMatching
    {
        //dynamic programming
        public bool IsMatch(string s, string p)
        {
            int m = s.Length, n = p.Length;
            //if s[0,..,i-1] matches j[0,...,j-1], then f[i,j] is true.
            bool[,] f = new bool[m + 1, n + 1];

            f[0, 0] = true;
            //first we settle f[0~m, 0] and f[0, 0~n].
            for (int i = 1; i <= m; i++)
                f[i, 0] = false;
            // p[0,..., j - 3, j - 2, j - 1] matches empty string if p[j - 1] is '*' and p[0,...,j - 3] matches empty
            for (int j = 1; j <= n; j++)
                f[0, j] = j > 1 && '*' == p[j - 1] && f[0, j - 2];

            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= n; j++)
                    if (p[j - 1] != '*')
                        f[i, j] = f[i - 1, j - 1] && (s[i - 1] == p[j - 1] || '.' == p[j - 1]);
                    else
                        //remove the last two char(that is x*) of pattern, still matches(so x* matches empty).
                        //or, string adds some more matching chars to the x*.
                        f[i, j] = f[i, j - 2] || ((s[i - 1] == p[j - 2] || '.' == p[j - 2]) && f[i - 1, j]);

            return f[m, n];
        }
        public static void Test()
        {
            var solution = new RegularExpressionMatching();
            var result = solution.IsMatch("aab", ".*b");
            System.Diagnostics.Debug.Assert(result == true);

            result = solution.IsMatch("abcd", "d*");
            System.Diagnostics.Debug.Assert(result == false);
        }
    }
}
