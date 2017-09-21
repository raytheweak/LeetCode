using System.Collections.Generic;

namespace LeetCode
{
    public class LetterCombinationsOfAPhoneNumber
    {
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length < 1) return new List<string>();

            var map = new Dictionary<char, string[]>();
            map['2'] = new string[3] { "a", "b", "c" };
            map['3'] = new string[3] { "d", "e", "f" };
            map['4'] = new string[3] { "g", "h", "i" };
            map['5'] = new string[3] { "j", "k", "l" };
            map['6'] = new string[3] { "m", "n", "o" };
            map['7'] = new string[4] { "p", "q", "r", "s" };
            map['8'] = new string[3] { "t", "u", "v" };
            map['9'] = new string[4] { "w", "x", "y", "z" };

            var result = new List<string>();
            string[] combinations = null;

            for (int i = 0; i < digits.Length; i++)
            {
                char digit = digits[i];
                if (i == 0)
                {
                    combinations = map[digit];
                    continue;
                }
                string[] currentCombinations = combinations;
                combinations = new string[currentCombinations.Length * map[digit].Length];
                int j = 0;
                foreach (string letter in map[digit])
                {
                    foreach (string combination in currentCombinations)
                    {
                        combinations[j] = combination + letter;
                        j++;
                    }
                }
            }
            return new List<string>(combinations);
        }

        public static void Test()
        {
            var solution = new LetterCombinationsOfAPhoneNumber();
            var result = solution.LetterCombinations("23");
        }
    }
}
