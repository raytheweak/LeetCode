namespace LeetCode
{
    public class ReverseInteger
    {
        public int Reverse(int x)
        {
            int result = 0;
            try
            {
                while (x != 0)
                {
                    int newResult = checked(result * 10 + x % 10);
                    result = newResult;
                    x = x / 10;
                }
            }
            catch (System.OverflowException)
            {
                return 0;
            }
            return result;
        }
    }
}
