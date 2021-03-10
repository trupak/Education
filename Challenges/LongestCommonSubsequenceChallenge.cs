using System;
using Xunit;

namespace ChallengesTests
{
    public class LongestCommonSubsequenceChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3311/";
        
        [Theory]
        [InlineData("abcde", "ace", 3)]
        public void LongestCommonSubsequenceTests(string text1, string text2, int expected) {
            Assert.Equal(expected, LongestCommonSubsequence(text1, text2));
        }

        public int LongestCommonSubsequence(String text1, String text2) {    
    
            // Make a grid of 0's with text2.length() + 1 columns 
            // and text1.length() + 1 rows.
            var dpGrid = new int[text1.Length + 1,text2.Length + 1];
        
            // Iterate up each column, starting from the last one.
            for (int col = text2.Length - 1; col >= 0; col--) {
                for (int row = text1.Length - 1; row >= 0; row--) {
                    // If the corresponding characters for this cell are the same...
                    if (text1[row] == text2[col]) {
                        dpGrid[row,col] = 1 + dpGrid[row + 1,col + 1];
                        // Otherwise they must be different...
                    } else {
                        dpGrid[row,col] = Math.Max(dpGrid[row + 1,col], dpGrid[row,col + 1]);
                    }
                }
            }
        
            // The original problem's answer is in dp_grid[0][0]. Return it.
            return dpGrid[0,0];
        }
        
        // public int LongestCommonSubsequence(string text1, string text2)
        // {
        //     memo = new int[text1.Length + 1, text2.Length + 1];
        //     for (int i = 0; i < text1.Length; i++) {
        //         for (int j = 0; j < text2.Length; j++) {
        //             memo[i,j] = -1;
        //         }
        //     }
        //
        //     this.text1 = text1;
        //     this.text2 = text2;
        //
        //     return memoSolve(0,0);
        // }
        //
        // private int memoSolve(int p1, int p2)
        // {
        //     if (memo[p1,p2] != -1) {
        //         return memo[p1,p2];
        //     }
        //
        //     int answer = 0;
        //
        //     if (text1[p1] == text2[p2])
        //         answer = 1 + memoSolve(p1 + 1, p2 + 1);
        //     else
        //         answer = Math.Max(memoSolve(p1 + 1, p2), memoSolve(p1, p2 + 1));
        //     memo[p1,p2] = answer;
        //     return memo[p1,p2];
        // }
        
        // public int LongestCommonSubsequence(string text1, string text2)
        // {
        //     var memo = new int[text1.Length + 1, text2.Length + 1];
        //     for (int i = 0; i < text1.Length; i++) {
        //         for (int j = 0; j < text2.Length; j++) {
        //             memo[i,j] = -1;
        //         }
        //     }
        //
        //     this.text1 = text1;
        //     this.text2 = text2;
        //
        //     return memoSolve(0,0);
        // }
        //
        // private int memoSolve(int p1, int p2)
        // {
        //     if (memo[p1,p2] != -1) {
        //         return memo[p1,p2];
        //     }
        //
        //     // Option 1: we don't include text1[p1] in the solution.
        //     int option1 = memoSolve(p1 + 1, p2);
        //
        //     // Option 2: We include text1[p1] in the solution, as long as
        //     // a match for it in text2 at or after p2 exists.
        //     int firstOccurence = text2.IndexOf(text1[p1], p2);
        //     int option2 = 0;
        //     if (firstOccurence != -1) {
        //         option2 = 1 + memoSolve(p1 + 1, firstOccurence + 1);
        //     }
        //
        //     // Add the best answer to the memo before returning it.
        //     memo[p1,p2] = Math.Max(option1, option2);
        //     return memo[p1,p2];
        // }
    }
}