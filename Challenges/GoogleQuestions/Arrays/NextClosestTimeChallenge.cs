using System;
using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class NextClosestTimeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/59/array-and-strings/471/";
        
        [Theory]
        [InlineData("23:59", "22:22")]
        [InlineData("19:34", "19:39")]
        [InlineData("01:32", "01:33")]
        public void NextClosestTimeTest(string time, string expected) {
            Assert.Equal(expected, NextClosestTime(time));
        }
        
        public string NextClosestTime(string time)
        {
            var availableDigits = new HashSet<int>();
            for (int i = 0; i < time.Length; i++)
            {
                int digit;
                if (int.TryParse(time[i].ToString(), out digit))
                    availableDigits.Add(digit);
            }

            var availableHours = new HashSet<int>();
            var availableMinutes = new HashSet<int>();
            foreach (var i in availableDigits)
            {
                foreach (var j in availableDigits)
                {
                    var combination = i * 10 + j;
                    if (combination < 24)
                        availableHours.Add(combination);

                    if (combination < 60)
                        availableMinutes.Add(combination);
                }
            }

            var parts = time.Split(':');
            var minutes = Convert.ToInt32(parts[1]);
            var hours = Convert.ToInt32(parts[0]);
            var nextMinutes = NextValue(minutes, availableMinutes, 60);
            var nextHours = hours;
            if (nextMinutes < minutes)
            {
                nextHours = NextValue(hours, availableHours, 24);
            }
            return $"{nextHours:00}:{nextMinutes:00}";
        }

        private int NextValue(int minutes, HashSet<int> availableMinutes, int maxValue)
        {
            var found = maxValue;
            var minimal = maxValue;
            foreach (var availableMinute in availableMinutes)
            {
                if (availableMinute > minutes && availableMinute < found)
                    found = availableMinute;

                if (availableMinute < minimal)
                    minimal = availableMinute;
            }

            return found == maxValue ? minimal : found;
        }
    }
}