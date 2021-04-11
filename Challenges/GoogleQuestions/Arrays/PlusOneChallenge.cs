using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class PlusOneChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/339/";

        [Theory]
        [InlineData(new [] { 0 }, new [] { 1 })]
        [InlineData(new [] { 4,3,2,1 }, new [] { 4,3,2,2 })]
        [InlineData(new [] { 4,3,9,9 }, new [] { 4,4,0,0 })]
        [InlineData(new [] { 9,9,9,9 }, new [] { 1,0,0,0,0 })]
        public void PlusOneTests(int[] digits, int[] expected)
        {
            var result = PlusOne(digits);
            Assert.Equal(expected, result);
        }
        
        public int[] PlusOne(int[] digits)
        {
            var allNine = true;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != 9)
                {
                    allNine = false;
                    break;
                }
            }
            
            var result = new int[digits.Length + (allNine ? 1 : 0)];
            var add = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] + add == 10)
                {
                    result[i] = 0;
                    add = 1;
                }
                else
                {
                    result[i] = digits[i] + add;
                    add = 0;
                }
            }

            if (allNine)
                result[0] = 1;
            
            return result;
        }
    }
}