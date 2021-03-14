using Xunit;

namespace ChallengesTests
{
    public class NumberToWordsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/48/others/188/";

        [Theory]
        [InlineData(123, "One Hundred Twenty Three")]
        [InlineData(12345, "Twelve Thousand Three Hundred Forty Five")]
        [InlineData(1234567, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")]
        [InlineData(1234567891,
            "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One")]
        public void NumberToWordsTests(int num, string expected)
        {
            Assert.Equal(expected, NumberToWords(num));
        }

        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            int billion = num / 1000000000;
            int million = (num - billion * 1000000000) / 1000000;
            int thousand = (num - billion * 1000000000 - million * 1000000) / 1000;
            int rest = num - billion * 1000000000 - million * 1000000 - thousand * 1000;

            string result = "";
            if (billion != 0)
                result = Three(billion) + " Billion";
            if (million != 0)
            {
                if (result != string.Empty)
                    result += " ";
                result += Three(million) + " Million";
            }

            if (thousand != 0)
            {
                if (result != string.Empty)
                    result += " ";
                result += Three(thousand) + " Thousand";
            }

            if (rest != 0)
            {
                if (result != string.Empty)
                    result += " ";
                result += Three(rest);
            }

            return result;
        }

        public static string One(int num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
            }

            return "";
        }

        public static string TwoLessThan20(int num)
        {
            switch (num)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
            }

            return "";
        }

        public static string Ten(int num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
            }

            return "";
        }

        public static string Two(int num)
        {
            if (num == 0)
                return "";
            else if (num < 10)
                return One(num);
            else if (num < 20)
                return TwoLessThan20(num);
            else
            {
                int tenner = num / 10;
                int rest = num - tenner * 10;
                if (rest != 0)
                    return Ten(tenner) + " " + One(rest);
                else
                    return Ten(tenner);
            }
        }

        public string Three(int num)
        {
            int hundred = num / 100;
            int rest = num - hundred * 100;
            string res = "";
            if (hundred * rest != 0)
                res = One(hundred) + " Hundred " + Two(rest);
            else if ((hundred == 0) && (rest != 0))
                res = Two(rest);
            else if ((hundred != 0) && (rest == 0))
                res = One(hundred) + " Hundred";
            return res;
        }
    }
}