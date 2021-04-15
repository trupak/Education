using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Trees
{
    public class LadderLengthChallenge : IChallenge
    {
        

        public string Link
            => "https://leetcode.com/explore/featured/card/google/61/trees-and-graphs/3068/";

        [Theory]
        [InlineData("hit", "cog", new[] {"hot","dot","dog","lot","log","cog"}, 5)]
        [InlineData("hit", "cog", new[] {"hot","dot","dog","lot","log"}, 0)]
        [InlineData("hot", "dog", new[] {"hot","dog","dot"}, 3)]
        [InlineData("hot", "dog", new[] {"hot","cog","dog","tot","hog","hop","pot","dot"}, 3)]
        public void LadderLengthTests(string beginWord, string endWord, string[] wordList, int expected)
        {
            Assert.Equal(expected, LadderLength(beginWord, endWord, wordList.ToList()));
        }

        public int LadderLength(String beginWord, String endWord, IList<String> wordList) {

          // Since all words are of same length.
          int l = beginWord.Length;

          // Dictionary to hold combination of words that can be formed,
          // from any given word. By changing one letter at a time.
          var allComboDict = new Dictionary<String, List<String>>();

          wordList.ToList().ForEach(
              word => {
                for (int i = 0; i < l; i++) {
                  // Key is the generic word
                  // Value is a list of words which have the same intermediate generic word.
                  var newWord = word.Substring(0, i) + '*' + word.Substring(i + 1, l - 1 - i);
                  var transformations = allComboDict.ContainsKey(newWord) ? allComboDict[newWord] : new List<string>();
                  transformations.Add(word);
                  if (!allComboDict.ContainsKey(newWord))
                    allComboDict.Add(newWord, transformations);
                }
              });

          // Queue for BFS
          var q = new Queue<(string word, int level)>();
          q.Enqueue((beginWord, 1));

          // Visited to make sure we don't repeat processing same word.
          var visited = new Dictionary<string, bool> {{beginWord, true}};

          while (q.Any()) {
            var node = q.Dequeue();
            var word = node.word;
            var level = node.level;
            for (int i = 0; i < l; i++) {

              // Intermediate words for current word
              var newWord = word.Substring(0, i) + '*' + word.Substring(i + 1, l - 1 - i);

              // Next states are all the words which share the same intermediate state.
              foreach (var adjacentWord in allComboDict.ContainsKey(newWord) ? allComboDict[newWord] : new List<string>()) {
                // If at any point if we find what we are looking for
                // i.e. the end word - we can return with the answer.
                if (adjacentWord.Equals(endWord)) {
                  return level + 1;
                }
                // Otherwise, add it to the BFS Queue. Also mark it visited
                if (!visited.ContainsKey(adjacentWord)) {
                  visited.Add(adjacentWord, true);
                  q.Enqueue((adjacentWord, level + 1));
                }
              }
            }
          }

          return 0;
        }
    }
}