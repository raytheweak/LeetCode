namespace LeetCode
{
    public class IntegerToRoman
    {
        public string IntToRoman(int num)
        {
            string[][] c = new string[4][]
            {
                new string[10]{"","I","II","III","IV","V","VI","VII","VIII","IX"},
                new string[10]{"","X","XX","XXX","XL","L","LX","LXX","LXXX","XC"},
                new string[10]{"","C","CC","CCC","CD","D","DC","DCC","DCCC","CM"},
                new string[4]{"","M","MM","MMM"}
            };
            var roman = new System.Text.StringBuilder();
            roman.Append(c[3][num / 1000 % 10]);
            roman.Append(c[2][num / 100 % 10]);
            roman.Append(c[1][num / 10 % 10]);
            roman.Append(c[0][num % 10]);

            return roman.ToString();
        }
    }
}
