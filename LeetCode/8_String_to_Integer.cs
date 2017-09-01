namespace LeetCode
{
    public class StringToInteger
    {
        public int MyAtoi(string str)
        {
            if (str == null) return 0;
            str = str.TrimStart();
            if (str.Length == 0) return 0;
            int start = 0, end = 0;
            if (str[0] == '+' || str[0] == '-')
            {
                if (str.Length < 2) return 0;
                start = 1;
            }
            else
            {
                start = 0;
            }
            end = start;
            for (int i = start; ; i++)
            {
                if (i >= str.Length || str[i] < '0' || str[i] > '9')
                {
                    end = i - 1;
                    break;
                }
            }
            int exponent = end - start;
            int ret = 0;
            try
            {
                checked
                {
                    while (exponent >= 0)
                    {
                        ret += (str[start] - '0') * Pow(10, exponent);
                        exponent--;
                        start++;
                    }
                }
                if (str[0] == '-') ret = -ret;
                return ret;
            }
            catch (System.OverflowException)
            {
                if (str[0] == '-')
                {
                    return int.MinValue;
                }
                return int.MaxValue;
            }
        }

        private int Pow(int baseNum, int exponent)
        {
            int power = 1;
            checked
            {
                for (int i = 0; i < exponent; i++)
                {
                    power *= baseNum;
                }
            }
            return power;
        }

        public static void Test()
        {
            var solution = new StringToInteger();
            var result = solution.MyAtoi("432");
            System.Diagnostics.Debug.Assert(result == 432);

            result = solution.MyAtoi("-432");
            System.Diagnostics.Debug.Assert(result == -432);

            result = solution.MyAtoi("+-2");
            System.Diagnostics.Debug.Assert(result == 0);

            result = solution.MyAtoi("-2147483648");
            System.Diagnostics.Debug.Assert(result == -2147483648);

            result = solution.MyAtoi("    10522545459");
            System.Diagnostics.Debug.Assert(result == 2147483647);
        }
    }
}
