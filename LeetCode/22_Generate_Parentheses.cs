using System.Collections.Generic;

namespace LeetCode
{
    public class GenerateParentheses
    {
        public List<string> GenerateParenthesis(int n)
        {
            List<string> list = new List<string>();
            backtrack(list, "", 0, 0, n);
            return list;
        }

        //参考了discuss中的第一个解决方法，本来想用动态规划，但是没找到怎么从f(n)得到f(n+1)的方法
        private void backtrack(List<string> list, string str, int open, int close, int max)
        {
            if (str.Length == max * 2)
            {
                list.Add(str);
                return;
            }

            if (open < max)
                backtrack(list, str + "(", open + 1, close, max);
            if (close < open)
                backtrack(list, str + ")", open, close + 1, max);
        }

        public static void Test()
        {
            var solution = new GenerateParentheses();
            var result = solution.GenerateParenthesis(2);

            result = solution.GenerateParenthesis(3);
        }
    }
}
