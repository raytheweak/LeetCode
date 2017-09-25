using System.Collections.Generic;

namespace LeetCode
{
    public class ValidParentheses
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(') return false;
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{') return false;
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[') return false;
                        break;
                }
            }
            if (stack.Count == 0) return true;
            return false;
        }

        public static void Test()
        {
            var solution = new ValidParentheses();
            var result = solution.IsValid("()[]{}");

            result = solution.IsValid("([)]");
            System.Diagnostics.Debug.Assert(result == false);

            result = solution.IsValid("]");
            System.Diagnostics.Debug.Assert(result == false);

            result = solution.IsValid("]");
            System.Diagnostics.Debug.Assert(result == false);
        }
    }
}
