using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.GoogleQuestions
{
    public class NumUniqueEmailsChallenge : IChallenge
    {
        public string Link 
            => "https://leetcode.com/explore/interview/card/google/67/sql-2/3044/";
        
        [Theory]
        [InlineData(new[] { "test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com" }, 2)]
        [InlineData(new[] { "a@leetcode.com","b@leetcode.com","c@leetcode.com" }, 3)]
        public void NumUniqueEmailsTests(string[] emails, int expected) {
            Assert.Equal(expected, NumUniqueEmails(emails));
        }
        
        public int NumUniqueEmails(string[] emails)
        {
            var uniqueEmails = new HashSet<string>();

            foreach (var email in emails)
            {
                var parts = email.Split('@');
                var localName = parts[0];
                var domainName = parts[1];

                var validLocalName = localName.Split('+')[0].Replace(".", string.Empty);
                var clearedEmails = validLocalName + "@" + domainName;
                if (!uniqueEmails.Contains(clearedEmails))
                    uniqueEmails.Add(clearedEmails);
            }
            
            return uniqueEmails.Count;
        }
    }
}