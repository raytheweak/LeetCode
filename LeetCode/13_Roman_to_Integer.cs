namespace LeetCode
{
    public class RomanToIntegerSolution
    {
        public int RomanToInt(string s)
        {
            int sum = 0;
            //Minus double value because in the next iteration, one value will be added back.
            if (s.IndexOf("IV") != -1) { sum -= 2; }
            if (s.IndexOf("IX") != -1) { sum -= 2; }
            if (s.IndexOf("XL") != -1) { sum -= 20; }
            if (s.IndexOf("XC") != -1) { sum -= 20; }
            if (s.IndexOf("CD") != -1) { sum -= 200; }
            if (s.IndexOf("CM") != -1) { sum -= 200; }

            foreach (char c in s)
            {
                if (c == 'M') sum += 1000;
                if (c == 'D') sum += 500;
                if (c == 'C') sum += 100;
                if (c == 'L') sum += 50;
                if (c == 'X') sum += 10;
                if (c == 'V') sum += 5;
                if (c == 'I') sum += 1;
            }
            return sum;
        }
    }
}
