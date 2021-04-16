using System;
using DataStructures;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Trees
{
    public class CountNodesChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/61/trees-and-graphs/3071/";

        [Theory]
        [InlineData(new[] {1,2,3,4,5,6,-1}, 6)]
        [InlineData(new int[] {}, 1)]
        [InlineData(new[] {1}, 1)]
        [InlineData(new[] {1,2,3,4,-1,-1,-1}, 4)]
        [InlineData(new[] {1,2,3,4,5,6,7,8}, 8)]
        [InlineData(new[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255,256,257,258,259,260,261,262,263,264,265,266,267,268,269,270,271,272,273,274,275,276,277,278,279,280,281,282,283,284,285,286,287,288,289,290,291,292,293,294,295,296,297,298,299,300,301,302,303,304,305,306,307,308,309,310,311,312,313,314,315,316,317,318,319,320,321,322,323,324,325,326,327,328,329,330,331,332,333,334,335,336,337,338,339,340,341,342,343,344,345,346,347,348,349,350,351,352,353,354,355,356,357,358,359,360,361,362,363,364,365,366,367,368,369,370,371,372,373,374,375,376,377,378,379,380,381,382,383,384,385,386,387,388,389,390,391,392,393,394,395,396,397,398,399,400,401,402,403,404,405,406,407,408,409,410,411,412,413,414,415,416,417,418,419,420,421,422,423,424,425,426,427,428,429,430,431,432,433,434,435,436,437,438,439,440,441,442,443,444,445,446,447,448,449,450,451,452,453,454,455,456,457,458,459,460,461,462,463,464,465,466,467,468,469,470,471,472,473,474,475,476,477,478,479,480,481,482,483,484,485,486,487,488,489,490,491,492,493,494,495,496,497,498,499,500}, 500)]
        [InlineData(new[] {6,2,5,2,0,6,0,9,4,9,8,6,2,3,6,6,4,7,3,0,9,2,2,5,0,6,8,4,1,3,9,4,3,9,0,1,6,2,7,0,1,7,3,9,8,9,6,1,9,9,3,7,2,2,9,5,2,2,3,9,9,0,8,7,5,7,2,4,1,4,4,5,8,6,8,0,4,4,7,9,2,1,8,9,0,0,3,0,0,3,5,6,4,5,2,8,6,5,7,8,8,8,7,3,2,6,5,7,8,3,5,8,6,8,8,8,8,6,0,9,5,6,9,3,0,0,9,6,8,0,0,9,1,9,6,1,9,9,1,9,1,4,6,3,1,5,7,7,0,4,3,5,7,3,0,4,1,3,1,2,2,8,7,6,1,7,5,9,7,3,2,6,1,2,9,0,7,1,4,1,9,9,2,5,9,0,3,3,7,1,0,2,4,0,5,5,5,1,2,2,3,2,0,2,1,1,3,8,9,9,7,5,3,2,4,2,3,9,8,4,7,5,4,6,6,9,6,4,8,2,1,5,0,0,6,9,7,3,2,0,3,5,7,8,5,8,3,6,3,7,2,9,9,7,8,4,4,1,0,0,5,0,8,8,7,7,6,8,5,9,7,6,7,2,2,7,0,6,4,2,6,4,9,5,5,3,1,4,6,7,6,6,3,8,2,0,1,4,0,3,2,5,0,4,8,0,8,9,4,4,7,4,2,4,7,6,8,1,9,3,4,1,2,0,7,9,7,1,5,3,1,7,6,3,4,0,5,7,7,1,2,4,0,3,1,8,3,9,8,7,5,6,3,5,2,2,9,4,3,3,9,2,2,7,3,9,8,9,5,5,5,1,5,6,6,9,0,4,9,5,5,6,7,5,3,0,1,6,7,3,3,8,9,4,2,7,0,9,6,4,5,4,9,4,0,9,5,5,9,4,3,4,5,9,2,7,9,6,1,7,0,5,8,4,8,6,3,0,1,6,7,1,1,7,7,0,0,1,8,9,0,9,0,6,3,2,9,6,4,4,7,3,8,8,4,7,5,5,9,7,1,7,9,8,0,5,9,9,5,8,2,0,2,4,0,0,8,5,5,9,4,4,6,1,4,9,5,6,7,6,0,9,3,5,1,0,0,5,3,9,7,0,9,1,7,0,7,2,6,6,8,2,8,4,1,9,2,8,0,5,0,8,6,4,1,4,9,6,6,9,0,3,3,5,9,5,4,5,4,5,4,8,1,6,0,6,9,6,0,7,6,8,3,6,3,0,2,5,6,9,1,2,9,8,6,0,1,9,2,4,7,3,2,8,8,1,8,3,5,9,9,7,2,3,7,4,2,1,9,4,5,9,3,5,3,5,1,7,4,2,1,6,6,8,3,8,2,7,1,8,1,0,1,8,3,2,2,7,1,9,4,0,4,8,8,5,6,7,1,3,4,2,6,4,7,1,3,8,7,5,5,6,8,1,0,4,7,5,9,1,4,5,8,7,6,3,5,3,3,2,7,3,3,6,9,3,9,9,2,0,1,9,5,5,9,6,7,7,9,6,2,0,2,6,5,6,7,7,0,8,3,9,6,5,8,1,6,1,7,4,0,3,3,2,3,8,9,1,7,4,5,5,5,9,4,8,0,5,1,8,3,8,8,8,0,2,2,8,1,9,5,4,5,4,3,8,4,8,5,7,0,9,3,6,9,0,0,7,8,8,0,6,2,1,4,2,2,1,2,9,7,1,3,5,3,3,2,3,8,4,6,6,3,4,1,2,6,6,4,7,2,4,7,5,4,8,0,4,5,1,2,6,6,9,9,9,2,2,2,7,3,8,6,9,6,6,7,3,3,8,9,3,2,5,4,4,5,0,8,0,7,1,6,1,4,7,7,2,5,6,5,4,5,1,6,1,2,6,7,2,7,3,2,5,9,0,5,8,0,2,7,6,9,9,5,7,1,9,6,1,8,7,1,9,3,1,4,4,1,2,2,8,3,8,6,8,6,9,3,5,9,9,1,3,3,1,7,0,1,8,8,2,8,5,3,0,8,4,2,2,7,7,9,2,0,6,4,0,6,3,0,4,2,6,8,0,0,2,6,4,1,6,4,7,0,5,7,0,1,8,2,5,2,1,6,8,8,4,6,2,9,7,5,0,3,4,7,5,2,9,4,2,6,0,3,4,6,3,9,0,4,3,4,0,1,8,6,5,8,2,4,5,6,1,8,9,4,8,0,7,6,9,1,1,9,3,0,6,4,4,7,6,9,6,6,5,6,9,8,8,3,4,9,2,6,9,9,0,5,3,5,2,2,4,4,5,5,0,7,1,2,9,8,0,5,4,5,2,5,5,8,8,0,9,4,4,7,0,7,4,0,5,4,9,8,5,7,4,2,1,7,0,3,7,3,2,6,6,2,5,6,0,9,9,6,2,2,3,8,6,7,0,6,7,2,8,4,0,9,4,3,3,5,3,5,8,5,9,5,0,6,1,8,7,0,0,3,2,0,0,4,6,4,7,5,9,0,5,6,5,2,5,6,6,5,4,6,6,4,7,3,5,7,2,5,4,1,5,8,7,3,2,0,2,6,4,4,8,4,5,3,9,9,3,7,7,8,4,5,7,0,9,0,5,4,3,7,3,8,4,7,2,3,3,3,7,6,1,6,0,7,5,1,5,6,9,0,6,8,7,4,4,7,6,6,9,6,6,1,9,7,3,0,4,0,1,0,7,6,0,2,7,5,7,1,1,6,0,9,4,7,1,2,3,0,8,0,1,9,7,1,8,5,0,0,5,1,4,4,7,5,1,3,3,4,3,9,6,7,5,9,7,0,0,3,5,9,1,7,5,4,1,8,3,0,6,4,6,9,7,6,0,9,9,8,9,9,6,0,6,4,3,8,1,0,3,1,3,8,3,4,4,8,4,7,9,2,6,5,4,5,1,2,1,6,8,0,0,4,9,2,3,6,8,8,0,4,1,4,7,4,8,4,2,3,3,4,6,8,8,4,7,6,0,6,0,5,9,0,4,6,8,7,1,8,6,4,2,5,5,9,9,3,3,6,0,3,4,8,7,1,7,6,9,9,8,6,8,1,7,6,3,3,3,3,1,2,7,9,0,2,0,7,2,9,9,6,1,4,5,0,4,1,8,9,0,4,4,1,0,3,7,7,4,2,9,7,1,9,2,1,6,3,2,2,8,4,5,5,5,8,6,0,6,6,4,3,3,2,6,4,0,2,9,4,4,8,6,2,5,8,7,7,2,0,4,0,6,9,3,3,0,1,4,5,7,9,1,7,0,1,7,9,1,9,6,1,7,3,4,7,7,1,1,0,6,5,5,0,5,7,8,4,4,5,9,2,3,9,0,1,3,6,3,7,0,1,9,7,9,0,9,9,1,5,0,8,9,7,0,1,9,0,4,6,6,5,3,7,9,4,2,1,4,4,9,0,4,2,9,8,3,5,7,5,5,0,0,7,9,8,8,8,0,2,8,0,8,3,1,3,0,3,8,4,3,1,7,6,1,8,9,9,9,4,3,9,0,4,1,5,9,8,7,3,6,8,0,9,3,1,0,0,7,7,4,7,6,8,0,7,7,2,0,8,6,1,6,4,9,7,2,7,2,3,3,0,6,2,1,2,2,3,3,5,1,6,5,4,8,1,3,6,1,9,7,1,9,3,6,8,1,2,7,4,5,9,1,5,1,4,7,1,2,3,7,8,6,3,0,5,2,3,1,5,8,2,1,5,6,4,6,6,2,8,7,7,4,6,0,8,1,3,0,6,3,8,8,2,5,5,9,4,6,7,5,4,1,8,4,4,3,5,6,8,4,4,0,8,7,0,2,2,2,3,5,9,4,5,3,5,3,4,8,0,9,9,4,4,7,9,9,0,2,2,3,2,2,1,8,9,8,2,8,3,5,3,6,4,4,8,4,4,6,4,8,8,3,7,1,5,2,6,6,3,8,8,1,5,2,4,6,1,3,5,1,4,6,0,9,2,1,0,6,2,5,2,7,1,2,8,2,5,3,9,0,7,7,8,5,1,6,3,8,2,7,0,9,8,5,9,4,5,7,5,1,5,3,6,2,5,5,8,8,5,2,9,7,9,3,2,8,4,8,9,9,0,4,3,3,4,5,5,6,6,1,4,0,8,7,3,0,7,1,6,9,3,8,6,1,3,2,4,5,2,4,2,9,8,2,2,9,0,7,8,7,0,5,1,9,8,8,0,6,0,9,1,1,4,2,6,1,8,1,2,4,1,6,1,5,8,3,6,8,5,5,3,6,9,8,9,4,0,1,5,4,0,7,5,9,6,8,3,9,6,3,3,9,8,3,6,1,3,3,0,8,4,9,2,6,7,1,7,4,4,4,7,9,3,4,7,1,8,7,7,0,1,9,2,1,5,3,3,8,1,3,4,0,3,1,7,9,6,2,0,0,1,4,5,9,9,0,1,3,0,3,3,3,7,0,3,0,9,4,2,8,2,5,0,4,5,3,7,4,0,9,6,7,7,6,1,2,0,4,4,0,6,1,8,2,3,4,6,3,6,0,3,8,5,8,2,8,9,9,9,1,4,4,6,5,0,2,9,7,5,7,0,1,7,6,7,3,8,0,5,6,9,3,4,2,9,6,8,3,2,5,8,6,1,3,1,3,3,6,7,5,7,9,2,3,5,2,0,3,2,9,1,7,4,6,3,6,7,1,1,9,9,3,4,4,8,5,8,8,6,6,7,7,1,2,4,5,6,3,7,6,8,6,0,9,6,4,6,5,9,7,1,9,0,9,8,8,1,1,0,9,8,9,9,2,2,2,5,9,8,3,7,5,8,0,2,0,2,5,9,4,6,6,0,4,3,8,3,2,3,9,9,6,3,6,8,7,6,6,3,3,2,1,5,0,2,0,1,8,1,7,5,4,2,5,6,8,5,6,2,1,6,4,2,3,3,5,9,5,9,3,2,4,1,6,5,9,2,2,2,9,1,6,6,6,7,2,8,3,8,5,4,3,3,4,6,5,5,5,8,7,0,0,0,2,9,8,7,5,4,6,6,4,1,1,7,9,1,8,5,8,0,1,8,2,0,1,1,6,3,4,9,8,9,5,0,7,0,6,5,3,7,7,1,3,0,4,2,8,3,1,6,6,1,7,5,9,7,9,6,2,1,7,2,3,3,5,6,2,0,0,6,0,3,4,6,6,3,7,4,6,8,7,9,0,6,2,4,6,1,8,7,0,5,9,8,4,4,9,8,8,4,3,1,2,3,0,3,7,1,3,3,4,6,4,8,0,4,7,5,0,9,2,9,5,7,8,7,2,2,6,6,6,0,6,0,4,5,4,8,6,7,0,4,0,5,1,3,1,9,2,3,0,4,0,9,6,3,9,5,1,6,9,7,5,3,8,0,4,9,8,4,6,5,7,1,3,2,1,7,9,4,3,1,1,4,2,4,0,4,2,2,7,0,6,4,7,6,1,6,1,4,3,6,9,7,2,2,1,1,2,6,8,1,6,5,1,9,4,5,4,2,1,9,6,4,8,4,8,2,0,6,7,4,0,6,5,7,8,9,0,5,4,8,9,0,7,4,9,4,9,6,7,5,3,1,4,6,7,3,3,9,9,8,3,8,8,4,3,6,5,9,2,3,6,6,5,8,0,8,2,1,5,3,1,3,8,5,5,8,2,8,6,1,3,5,4,1,0,6,5,3,6,4,6,0,1,2,9,0,9,8,0,5,8,7,4,4,1,5,1,0,9,3,3,9,8,7,2,3,5,0,9,4,2,6,3,8,4,6,9,6,8,6,0,8,3,9,1,5,8,9,4,0,1,6,5,0,7,6,1,8,6,0,3,7,7,1,5,1,6,5,5,1,1,5,2,4,3,2,2,5,2,7,0,0,3,8,1,7,6,3,5,3,5,3,4,7,3,9,1,4,0,0,6,7,0,6,1,7,1,4,6,4,6,8,3,4,9,4,6,9,4,1,0,2,3,6,9,0,2,2,3,9,9,9,8,4,9,4,5,5,2,6,6,4,4,1,8,8,0,3,0,1,3,6,6,2,2,6,6,0,4,1,5,3,4,1,3,9,6,7,1,4,9,0,4,5,6,5,2,1,4,2,4,5,1,0,0,6,3,0,1,2,0,9,5,9,6,9,3,5,4,9,0,5,0,4,5,7,9,5,5,4,3,1,1,5,0,4,8,2,7,8,0,9,9,5,7,0,9,4,1,1,4,5,4,5,2,0,7,9,2,5,1,1,1,2,4,2,5,0,7,0,2,5,6,4,0,8,5,4,4,6,7,5,2,1,0,9,0,7,1,5,7,8,6,2,5,2,6,9,3,6,9,4,4,7,6,7,9,4,9,7,0,9,7,5,2,4,3,8,1,5,6,5,2,7,4,1,2,4,7,8,4,6,5,7,2,2,6,0,4,7,1,6,0,3,8,7,7,4,4,8,7,8,7,6,6,3,0,2,7,2,6,8,1,2,4,1,4,3,5,1,0,8,5,8,8,3,3,8,0,6,2,8,9,6,3,2,9,6,0,9,6,9,8,4,1,1,6,3,0,3,0,0,7,5,1,5,6,8,5,5,8,9,5,0,6,0,3,9,3,6,5,5,5,9,0,6,7,1,0,5,9,1,0,1,8,8,5,8,5,8,8,1,4,4,9,3,5,7,4,7,3,5,6,2,2,8,9,1,6,5,5,0,1,8,2,5,1,8,1,8,7,4,1,5,4,3,3,3,3,1,4,6,5,1,7,9,2,0,0,7,9,2,4,3,1,9,3,7,1,6,7,9,8,3,6,7,6,0,7,3,8,6,0,2,5,6,4,4,2,8,4,4,0,5,2,5,5,6,9,3,1,7,9,2,1,4,7,9,4,7,1,9,8,0,9,8,6,4,2,9,4,5,6,9,4,9,3,1,7,6,7,8,5,4,1,6,7,2,9,4,5,7,1,0,1,7,2,0,6,5,8,7,2,7,6,7,8,3,9,0,2,7,9,8,7,3,8,8,7,0,1,1,4,1,3,8,6,6,2,6,3,8,0,9,7,8,0,2,8,4,6,3,8,2,3,9,4,3,9,9,0,2,5,2,8,0,2,0,0,0,1,8,1,3,1,0,0,2,9,5,9,5,6,7,9,1,2,5,7,1,8,8,3,9,8,1,5,2,0,5,3,1,3,3,2,2,6,7,0,9,0,9,4,5,8,1,1,9,5,9,7,9,9,3,1,2,9,4,2,5,5,6,2,9,9,8,0,2,5,1,3,9,2,1,9,4,6,7,0,4,4,5,0,2,2,8,7,7,0,0,8,5,4,0,1,2,5,6,6,0,2,2,5,8,6,8,8,9,4,7,8,2,4,2,5,8,2,0,5,0,1,0,7,6,5,7,3,8,1,7,8,0,0,5,5,2,8,4,0,2,2,3,5,2,4,4,5,9,3,4,9,8,1,6,7,3,1,3,0,0,6,8,4,8,7,1,2,6,4,2,2,4,9,8,4,1,4,6,8,8,1,4,4,0,5,3,3,1,9,9,4,0,9,9,4,7,7,0,5,4,9,5,9,5,6,1,2,5,4,1,2,8,3,3,0,5,9,2,3,0,6,4,0,5,8,4,0,6,3,6,9,9,8,9,5,2,4,0,2,4,9,8,6,0,4,3,8,1,8,5,4,6,8,1,4,7,4,2,3,0,6,9,2,3,4,7,1,3,6,2,0,5,7,9,9,6,6,6,1,3,6,3,9,8,8,2,3,6,7,4,1,3,6,0,1,1,5,9,6,0,0,8,7,6,9,9,4,8,7,4,4,7,8,9,4,9,8,1,9,7,9,5,5,6,7,3,6,9,1,2,2,5,8,0,5,4,1,5,5,5,1,2,0,8,1,0,2,6,8,0,6,0,1,3,7,2,0,7,9,9,3,1,8,9,9,1,1,9,3,4,1,5,9,3,4,7,0,2,7,7,5,4,6,6,3,3,4,0,1,5,8,3,3,1,1,5,5,1,6,4,3,8,0,3,3,0,7,0,7,9,4,2,3,3,4,3,7,0,9,7,2,8,9,6,3,3,3,7,9,7,7,3,0,2,5,7,6,9,4,0,2,3,3,4,1,1,5,9,1,0,9,5,4,7,6,5,7,1,9,3,3,5,8,8,1,7,2,0,6,7,3,3,5,1,8,3,1,9,2,8,0,5,5,1,6,0,4,7,5,7,0,6,5,1,8,1,4,3,1,0,1,1,7,5,3,7,1,1,1,2,9,2,0,9,9,1,3,5,3,0,6,4,2,1,8,2,4,6,3,3,6,0,8,8,4,2,3,4,7,6,6,8,4,7,0,9,2,9,1,7,9,8,0,7,4,5,6,7,5,2,6,5,4,9,3,9,0,6,8,4,6,8,3,5,9,4,6,2,3,7,4,2,0,6,5,1,4,3,7,4,4,5,7,0,5,8,0,9,3,0,5,3,5,4,8,1,8,6,7,4,6,7,6,4,8,8,2,1,4,6,0,1,7,2,4,0,0,1,0,7,1,8,2,0,2,6,6,9,3,2,9,3,4,1,6,1,9,2,1,4,3,8,7,8,6,2,4,5,3,3,7,6,0,5,0,7,7,1,1,4,5,4,3,5,5,2,6,8,1,9,3,1,8,5,5,4,8,6,8,2,4,4,3,5,4,1,4,9,4,8,9,2,0,1,0,7,4,4,4,8,5,7,9,2,6,7,9,3,7,5,3,4,7,2,2,3,0,0,3,0,1,3,4,3,8,6,4,3,2,2,8,0,0,5,2,7,3,9,7,5,6,5,1,5,9,5,3,8,5,1,2,0,9,9,0,6,7,6,2,3,6,9,1,2,7,2,7,2,8,5,9,9,3,8,1,8,1,9,4,4,9,5,2,8,5,3,9,4,2,9,4,5,3,3,5,6,6,3,2,1,8,2,5,5,3,0,0,5,7,2,2,6,8,1,5,8,6,1,8,4,2,1,4,6,0,5,2,3,9,2,5,5,9,2,4,5,3,1,5,5,5,9,3,3,1,5,5,7,9,9,9,0,9,7,1,3,6,6,4,5,1,3,8,7,9,3,0,9,8,4,1,8,1,9,2,3,3,6,0,5,6,6,6,6,6,8,7,3,0,9,5,0,1,9,9,8,8,3,3,2,4,5,5,6,8,3,1,5,6,8,5,6,0,4,3,4,5,6,2,6,0,3,1,8,0,8,0,7,4,3,9,7,0,5,4,4,4,2,5,5,8,9,9,0,5,3,5,2,8,0,4,3,9,9,6,6,7,9,1,8,7,4,2,4,7,1,5,2,9,3,6,4,9,2,2,0,3,2,9,4,9,2,5,1,4,9,8,1,8,4,1,2,1,7,0,6,2,6,1,0,5,2,0,2,1,5,3,5,6,1,5,9,3,7,7,1,4,3,2,2,8,2,1,4,6,8,1,8,2,5,1,5,9,6,3,7,2,0,0,1,4,3,3,2,1,1,8,8,8,6,3,9,1,9,5,8,8,6,3,8,5,8,9,8,9,0,0,1,5,5,3,1,6,6,8,0,4,1,3,0,3,0,9,2,9,1,7,6,2,1,4,2,2,1,7,5,9,2,8,8,2,7,2,1,9,5,8,1,4,7,2,0,6,5,0,3,3,2,3,9,5,7,6,3,0,4,7,1,0,3,7,4,5,5,8,7,4,7,7,3,5,9,0,5,2,3,2,8,1,8,5,9,7,1,0,2,5,7,1,3,8,2,9,9,5,0,1,2,4,6,3,3,5,7,7,4,4,8,1,8,6,8,1,0,3,4,9,0,0,7,1,1,1,5,4,2,9,3,1,6,0,3,5,0,9,9,7,4,7,9,6,7,6,2,5,2,8,3,3,0,6,0,4,4,3,2,2,5,8,0,0,3,6,6,5,8,0,1,8,2,0,8,3,4,4,2,6,5,4,6,1,4,5,1,6,5,3,9,5,0,7,1,8,4,0,2,5,0,1,9,0,2,3,4,7,9,8,7,5,7,6,6,6,1,5,6,1,2,2,1,0,3,6,6,5,0,9,6,8,7,0,1,5,6,0,7,8,3,0,3,3,8,1,3,7,8,0,4,5,5,0,6,8,2,3,6,9,7,9,0,6,6,3,9,9,0,4,9,6,7,5,1,8,4,9,3,5,3,4,1,5,0,4,6,9,6,1,3,5,6,4,5,2,2,3,5,9,7,1,0,4,0,6,3,9,7,8,0,4,2,3,6,2,2,4,8,9,7,6,2,8,4,7,9,4,8,6,4,0,1,8,3,5,1,2,7,0,4,0,1,6,1,3,0,9,2,1,1,8,9,8,6,7,2,7,9,7,6,9,7,7,5,0,7,7,4,0,4,1,3,1,1,5,0,8,1,7,2,4,7,2,4,0,5,7,6,7,8,6,6,0,6,5,5,2,5,1,4,0,6,4,4,6,0,0,1,9,8,0,0,5,8,2,6,7,8,0,5,0,4,7,3,3,9,0,7,2,6,9,3,0,0,9,3,7,7,1,0,3,1,0,2,1,3,8,0,0,8,2,8,1,5,6,5,0,4,5,5,7,9,9,4,7,1,5,9,6,2,6,5,8,3,5,5,2,5,6,8,5,6,2,0,6,3,0,3,1,5,7,7,3,8,0,5,3,7,6,9,4,3,9,5,2,8,9,5,2,0,6,5,2,6,7,9,8,3,4,4,0,9,9,8,2,9,9,6,9,0,5,6,9,0,2,7,1,7,5,8,5,6,5,3,5,6,7,6,5,1,3,6,8,3,2,8,4,6,1,9,4,9,1,3,5,8,2,8,9,7,3,7,0,9,7,0,6,2,4,3,6,8,4,1,0,7,7,7,8,2,1,7,4,1,7,5,5,4,1,9,1,5,3,3,8,5,6,0,6,1,1,1,3,6,2,3,0,0,6,0,8,2,6,5,6,2,7,9,0,5,0,7,1,0,6,2,9,7,4,1,9,7,7,7,3,5,5,7,8,8,4,8,6,8,8,3,4,2,9,6,0,6,8,7,5,6,4,7,5,9,6,2,4,7,8,4,1,5,4,3,2,7,6,8,0,4,6,2,4,3,5,8,8,8,3,7,7,6,4,3,7,7,8,6,6,1,8,8,5,0,9,4,5,9,3,6,9,2,7,5,2,0,0,7,0,8,6,1,1,6,5,5,5,0,3,4,6,8,4,3,9,5,7,8,2,1,9,9,7,1,6,1,5,0,6,8,0,4,4,7,8,9,2,3,6,1,6,1,6,6,1,0,9,6,2,4,7,1,6,4,5,0,9,0,2,3,3,1,3,1,4,3,0,2,6,0,7,2,0,6,7,4,3,2,1,0,8,6,9,5,6,8,0,3,1,1,0,2,0,4,9,3,6,8,0,9,6,3,9,4,6,3,9,1,7,0,3,9,0,6,0,1,2,9,8,8,2,4,3,4,0,9,0,3,5,0,7,0,9,4,7,5,6,8,8,2,2,2,8,8,8,6,2,0,2,5,6,8,8,8,2,5,1,7,6,1,7,8,3,1,2,3,4,6,3,1,0,9,5,1,2,0,0,9,5,2,2,1,7,1,5,8,1,1,5,5,2,5,4,5,1,2,6,0,6,8,0,5,7,0,8,6,2,7,4,4,0,4,0,6,8,4,9,8,2,3,4,3,2,4,3,2,8,8,6,0,9,3,2,9,2,9,1,8,9,8,8,3,7,2,9,5,5,0,1,1,6,0,2,5,3,7,9,9,7,2,9,5,0,0,0,8,9,8,7,1,0,8,8,9,6,4,9,2,5,0,9,8,2,6,0,5,9,8,4,9,7,6,5,2,1,3,2,2,9,5,3,2,2,7,8,7,8,3,4,3,6,2,7,1,4,2,4,4,4,6,5,4,6,8,5,0,3,2,6,6,1,7,4,0,6,9,7,4,2,0,4,3,9,5,7,8,4,8,3,4,1,2,4,4,7,4,2,1,6,6,8,9,0,2,2,2,3,5,2,7,5,8,5,8,0,5,3,0,8,3,7,5,7,9,0,7,2,3,3,1,5,1,4,4,3,4,2,4,0,3,7,5,8,6,4,9,7,8,6,6,0,2,4,6,8,8,6,8,3,8,0,7,5,4,0,5,7,8,6,6,2,6,5,2,5,3,6,5,8,4,8,7,3,7,1,5,5,4,6,0,2,8,3,2,7,4,0,8,5,8,9,0,3,9,1,2,4,4,4,5,1,3,7,6,0,3,9,2,7,0,4,0,5,6,2,7,9,0,5,2,3,9,8,2,6,6,3,8,2,9,6,3,2,3,4,6,4,3,3,4,5,3,3,1,8,7,3,5,7,7,9,0,1,2,0,5,8,8,0,9,2,4,5,1,0,7,1,4,6,9,1,8,7,6,6,9,9,1,8,8,5,3,3,9,8,9,1,9,1,0,1,3,7,9,1,9,7,8,6,9,0,4,5,0,4,5,6,7,9,0,6,3,0,8,2,5,3,0,1,9,3,7,6,0,8,4,9,5,9,4,8,3,4,0,9,2,2,0,6,8,1,6,1,4,0,9,0,4,6,7,4,8,0,3,4,1,7,0,0,1,5,1,8,9,4,4,2,6,8,4,4,2,1,0,4,3,8,5,9,8,3,6,7,1,5,8,8,4,5,9,7,7,0,8,3,0,9,7,1,8,7,6,0,6,3,5,6,6,1,7,2,9,5,9,1,3,6,0,7,0,1,9,8,2,7,8,3,2,1,9,5,9,8,7,1,4,3,0,1,0,4,7,6,7,0,9,3,9,1,7,9,0,3,8,0,5,2,2,2,3,9,2,3,3,6,2,8,4,8,5,5,7,4,2,6,2,3,5,1,4,6,8,2,0,0,2,9,8,3,5,9,8,1,2,2,1,5,1,7,1,8,9,9,3,8,7,0,8,9,9,6,7,6,9,5,8,6,5,4,6,1,8,0,1,0,4,7,0,9,7,9,3,5,8,8,1,4,6,9,2,9,4,6,0,3,1,5,0,1,2,4,1,2,6,6,6,8,6,4,9,9,3,2,4,2,1,1,6,0,3,0,2,8,1,0,4,7,1,3,3,0,4,4,9,1,4,0,6,3,4,9,8,7,0,2,5,9,1,0,2,7,5,2,2,0,5,9,5,4,4,3,6,6,4,5,7,3,3,6,3,5,5,6,3,0,9,1,3,2,3,9,7,4,7,4,6,5,5,4,1,4,7,2,8,0,8,2,7,6,8,2,9,2,6,0,0,6,0,0,8,5,8,6,0,9,2,3,1,0,9,6,9,0,0,4,5,4,7,9,3,8,8,5,9,9,0,9,9,6,0,6,5,6,4,1,1,6,3,8,3,6,6,5,9,3,2,5,1,4,1,5,9,3,3,2,8,7,4,1,2,9,4,1,0,4,7,5,2,7,5,9,5,4,4,7,7,7,7,0,3,1,4,1,7,5,1,8,9,8,0,5,8,2,1,9,4,4,7,9,9,8,4,2,8,2,0,0,7,7,2,0,4,0,5,5,7,7,9,5,9,3,0,5,7,3,1,9,5,3,1,8,4,8,3,1,0,7,3,6,7,6,2,3,5,1,1,7,0,6,8,6,1,6,9,7,7,5,5,5,5,1,8,9,9,9,2,0,4,9,1,2,2,5,8,9,7,6,9,9,5,1,1,8,6,7,9,0,2,7,6,9,9,9,0,0,3,8,2,3,6,8,4,8,5,7,0,7,0,6,1,2,1,9,6,0,7,7,9,9,8,7,9,1,7,4,4,5,9,6,5,8,1,7,3,0,9,0,7,9,9,9,6,4,2,8,3,1,4,5,6,2,7,1,1,5,4,4,3,1,5,7,8,2,4,0,8,0,8,6,6,4,2,5,5,3,4,7,7,2,6,8,4,5,0,3,9,3,9,6,0,4,5,8,5,3,0,0,5,4,6,8,6,0,8,1,9,2,5,5,7,4,7,6,4,6,5,0,1,1,7,3,3,5,6,7,4,3,4,3,8,0,6,9,0,7,0,3,2,4,9,7,0,1,0,8,4,8,8,5,5,4,3,9,8,0,3,9,0,9,1,5,2,6,1,0,6,5,6,9,2,5,7,6,2,4,6,6,0,9,1,3,7,9,0,4,1,5,8,7,9,6,3,3,7,0,5,7,0,5,5,4,7,4,2,0,4,3,2,2,4,4,7,4,5,1,2,5,8,1,6,7,7,7,3,8,5,8,6,5,2,0,6,1,0,1,0,6,6,8,2,8,2,1,1,4,0,9,8,5,5,7,3,3,9,7,3,3,0,4,9,7,0,3,7,7,1,9,8,3,7,6,1,2,3,3,9,7,6,6,5,0,4,2,2,7,9,3,2,4,8,6,5,3,7,4,2,7,6,8,0,9,3,5,2,3,4,5,8,6,4,7,7,7,9,1,9,5,3,7,1,0,8,3,8,2,5,9,4,9,8,4,7,6,8,9,3,7,4,6,8,9,1,5,4,0,4,2,4,2,1,6,6,2,9,0,2,0,8,8,3,4,1,1,3,8,6,0,9,6,8,8,8,4,9,9,9,9,5,8,5,6,7,3,2,3,7,0,3,3,0,3,7,8,2,0,4,7,0,1,5,1,5,4,0,3,0,2,1,4,7,4,0,3,2,6,3,8,4,3,4,8,1,5,3,3,2,8,8,6,5,3,4,5,3,0,3,7,1,5,3,6,0,9,9,6,9,6,9,9,5,0,7,7,4,1,8,9,3,0,2,8,2,9,4,6,1,0,4,4,7,0,4,0,4,6,6,7,2,0,3,4,5,9,6,5,5,5,4,9,0,1,0,2,7,4,0,4,3,1,7,4,3,9,6,8,8,2,7,4,2,1,3,6,7,0,4,6,1,9,0,5,0,9,8,7,5,3,3,2,7,1,7,7,5,7,4,7,6,2,9,9,0,4,0,9,4,2,5,5,3,0,6,2,1,9,9,9,6,4,1,4,5,2,8,8,7,7,9,4,5,4,0,5,5,9,4,8,6,2,8,9,6,1,7,4,5,2,4,5,0,2,5,6,5,0,8,5,2,8,0,4,7,7,8,1,9,0,4,8,8,5,1,3,5,6,3,8,6,6,5,7,3,1,0,0,2,0,6,9,0,6,2,3,8,6,3,8,1,4,5,1,1,3,6,0,9,1,2,0,4,9,2,1,2,5,9,0,7,5,1,9,5,8,9,9,0,9,6,4,2,2,4,0,4,9,5,7,5,2,4,1,5,0,8,9,1,7,8,6,0,7,3,9,1,2,4,1,3,3,5,1,9,1,5,4,6,8,0,3,1,8,2,2,2,1,2,4,6,0,8,2,5,2,4,0,3,2,0,8,4,7,3,6,1,3,3,8,0,3,5,9,9,9,7,3,9,1,2,7,0,4,7,2,2,1,5,2,5,4,6,2,9,6,5,4,3,1,3,0,5,1,1,8,0,6,3,4,3,8,5,6,6,6,9,1,7,4,3,2,4,6,4,3,8,9,6,4,2,7,7,0,5,5,2,7,6,1,6,8,0,1,7,6,4,6,5,4,1,9,5,7,6,3,9,6,3,8,6,2,9,7,5,9,9,1,7,8,7,0,5,8,2,0,4,8,9,3,2,8,8,7,5,5,1,1,2,0,1,7,5,3,5,8,2,6,8,8,3,8,4,3,3,1,8,3,8,9,4,3,2,9,4,3,9,3,0,6,5,5,2,7,1,6,7,7,7,6,0,4,6,7,1,0,7,7,5,6,3,0,1,4,2,4,0,7,0,3,3,2,7,6,7,2,7,8,8,1,1,9,1,3,5,7,8,6,9,7,1,0,8,6,7,2,4,5,2,2,4,3,7,4,9,3,5,9,1,6,8,6,7,2,4,3,4,3,4,9,5,0,0,5,4,7,6,3,5,5,8,0,8,4,0,2,8,2,2,0,8,5,1,9,3,5,8,8,6,5,1,8,6,6,6,7,5,2,3,4,2,3,1,9,9,5,8,0,6,5,1,6,8,6,7,7,1,2,3,1,6,4,4,5,1,0,7,8,4,4,6,5,9,6,1,9,0,3,4,4,7,7,5,0,7,7,7,4,4,8,7,8,0,8,7,5,1,5,2,4,9,9,6,3,9,7,6,4,2,3,2,3,2,4,6,2,3,4,7,7,8,4,7,9,3,6,9,8,0,9,9,3,6,8,5,2,1,3,5,5,4,8,3,0,5,2,3,0,7,3,9,8,1,4,0,5,5,3,4,8,1,6,0,2,0,4,7,8,8,5,9,8,3,8,4,5,4,1,6,6,5,1,3,4,4,5,9,4,9,8,2,7,6,4,0,0,7,9,1,9,1,6,2,6,0,4,0,4,4,9,7,0,2,5,4,3,2,3,1,8,7,8,5,8,8,2,1,5,5,2,3,8,6,2,4,3,5,4,0,2,3,1,7,6,9,2,2,9,1,1,3,7,7,4,8,4,3,4,0,2,9,6,8,6,7,8,2,2,9,6,6,2,9,5,4,4,1,7,4,7,3,3,3,1,9,5,7,8,6,7,4,4,3,0,6,2,7,4,0,4,9,1,9,6,8,8,3,2,4,5,6,3,4,0,8,1,0,8,7,8,7,4,1,9,5,1,0,3,5,4,5,7,5,1,2,7,9,0,8,4,1,1,5,4,9,8,2,8,7,2,3,1,0,1,7,6,3,9,2,0,6,2,2,3,8,3,4,8,2,8,6,0,0,2,0,2,4,2,7,1,5,5,7,5,3,5,8,1,8,7,2,8,5,3,4,7,5,9,5,3,1,9,3,8,5,4,0,5,8,2,6,1,3,0,6,3,4,1,9,6,7,5,0,8,5,1,4,5,9,6,1,8,1,5,3,0,8,7,1,3,9,4,7,8,9,0,2,8,8,9,4,6,5,5,3,0,5,7,3,0,7,8,9,6,0,1,1,9,1,4,8,5,2,2,9,1,2,2,1,3,3,6,7,3,7,7,9,8,1,1,1,0,7,0,8,6,2,7,1,4,2,8,7,7,3,1,7,8,8,2,7,8,4,7,4,5,8,0,1,6,4,0,4,2,2,0,3,0,9,7,4,0,6,8,3,7,1,4,4,8,4,0,3,0,9,4,0,1,2,7,7,8,8,7,0,2,4,0,2,2,3,5,5,1,4,5,9,7,1,7,5,3,1,2,9,6,3,3,2,0,5,4,5,1,0,7,0,6,4,3,2,6,7,2,5,4,4,2,7,5,3,3,3,7,4,8,3,3,7,9,1,3,0,3,3,9,4,2,5,8,9,4,6,1,5,4,8,9,1,1,0,9,0,1,5,4,1,5,2,6,9,5,1,6,4,2,7,8,6,2,7,9,8,9,1,1,2,7,8,1,8,7,1,8,7,3,4,4,8,9,0,6,6,5,2,9,8,8,4,0,3,2,9,7,4,5,0,9,4,2,0,9,2,7,6,8,4,8,9,3,0,9,5,0,4,3,6,9,0,2,8,5,8,3,1,6,2,1,8,4,1,7,5,6,0,6,6,9,7,3,0,5,3,3,8,4,6,9,4,3,5,6,2,2,7,2,5,2,4,9,5,4,2,0,1,4,5,0,9,7,1,0,6,0,6,8,3,4,6,2,1,3,8,9,9,6,6,8,8,7,7,1,5,3,9,5,9,0,9,6,8,2,7,1,1,9,9,9,9,9,1,0,3,0,5,5,1,1,8,3,4,0,4,1,0,1,8,2,4,8,9,9,2,3,8,2,0,7,5,3,6,1,1,6,8,2,6,1,1,3,9,3,6,5,8,3,7,4,9,9,8,8,2,7,6,1,0,5,4,8,9,2,0,3,8,7,7,3,2,6,1,6,4,6,4,4,0,1,1,8,9,1,0,4,3,1,1,3,2,1,2,3,3,0,7,5,9,2,5,3,6,9,1,2,1,1,9,2,9,6,9,8,3,2,9,4,0,8,8,5,7,1,7,8,1,5,3,1,5,0,5,7,1,0,5,1,0,3,5,8,8,7,8,7,5,1,9,6,3,1,5,6,2,3,8,1,1,7,9,5,6,6,2,2,1,9,2,8,2,3,0,2,9,6,8,7,0,2,3,1,7,9,5,3,7,1,3,2,6,4,4,7,0,5,9,1,5,8,2,0,8,7,2,1,7,5,7,0,7,2,6,6,5,2,2,8,9,1,5,2,7,9,0,6,7,5,9,2,4,2,8,2,8,2,1,2,3,6,1,8,4,7,9,4,1,4,3,8,3,9,0,4,3,3,8,5,6,3,2,3,7,8,8,6,9,3,7,3,2,2,2,7,8,2,3,6,3,0,3,7,0,9,8,9,1,2,4,9,3,8,5,1,8,1,6,4,2,4,3,5,7,3,5,8,7,9,8,2,1,5,7,0,9,0,7,3,7,8,9,6,9,9,7,9,6,8,6,4,5,6,1,8,8,4,1,7,9,4,0,8,8,5,3,8,4,6,5,8,3,4,1,6,0,4,5,4,6,0,2,2,1,7,1,3,6,1,0,3,5,0,7,8,7,4,1,1,9,4,3,8,5,0,0,8,9,8,9,5,1,8,2,0,2,4,8,0,2,5,5,1,3,9,4,8,9,2,8,6,9,7,2,4,5,2,7,2,5,3,3,3,9,1,1,0,5,2,9,5,4,7,9,4,8,6,7,1,4,0,3,4,4,7,7,5,2,7,1,9,0,8,1,3,4,9,6,7,9,2,2,3,8,9,5,7,3,4,7,7,4,0,5,0,3,5,0,7,1,1,0,9,0,1,8,1,1,0,4,8,8,7,4,8,8,5,5,8,1,2,8,3,3,5,4,8,5,0,7,6,9,4,9,0,8,1,1,0,0,1,8,7,6,6,2,1,3,0,4,2,6,1,5,8,4,9,8,1,0,8,1,9,9,5,6,6,7,4,1,6,5,9,8,3,4,1,6,8,4,7,0,6,2,7,9,0,1,7,5,7,0,5,5,8,0,4,4,3,9,7,4,7,4,3,3,0,3,2,3,5,5,6,5,0,5,2,0,9,0,2,2,1,1,5,8,6,5,1,0,7,6,3,2,4,0,3,9,1,8,6,9,5,7,1,1,0,7,2,7,6,9,0,1,7,6,3,0,5,3,2,6,0,9,2,2,8,4,6,0,3,7,0,4,8,0,6,3,0,8,9,9,4,5,5,7,9,9,8,5,6,9,1,5,6,6,1,7,4,1,3,2,9,0,9,4,2,3,8,3,9,7,4,2,8,1,4,6,5,3,7,1,1,6,1,1,9,5,6,6,7,9,6,5,6,4,2,8,2,3,4,0,7,1,1,2,9,6,4,5,6,4,8,4,1,2,6,1,8,6,5,4,7,4,9,7,8,5,9,4,9,2,5,2,7,2,0,6,4,7,0,5,3,4,3,8,6,0,7,1,2,4,0,9,8,5,4,2,0,9,3,7,7,1,2,3,2,7,3,9,6,1,8,9,2,4,2,1,6,3,3,6,4,0,4,5,6,2,7,1,2,1,3,6,5,2,6,0,9,0,4,3,7,0,1,4,3,9,0,4,9,0,7,3,4,3,7,1,0,3,3,8,2,5,4,2,4,1,0,6,5,7,7,5,3,0,7,1,7,5,6,0,0,2,7,4,0,4,7,1,4,6,7,2,1,6,6,0,2,0,4,3,5,8,2,2,8,6,9,8,9,0,3,4,9,0,7,4,3,4,0,9,8,8,3,3,6,6,7,7,9,5,3,2,1,9,7,3,9,3,9,9,4,2,8,6,1,7,3,1,0,4,7,6,3,2,6,4,6,8,6,8,2,9,2,2,1,0,2,9,2,6,9,2,0,5,9,5,7,5,4,8,4,7,2,5,0,3,9,8,2,7,5,6,7,6,5,6,1,7,8,8,0,8,3,5,4,8,6,2,1,6,6,1,5,7,2,2,1,6,5,6,2,0,9,1,1,6,4,1,8,9,0,0,7,3,3,8,4,8,3,2,9,4,4,0,2,2,6,2,6,2,7,5,4,9,4,7,4,8,2,0,0,7,0,8,6,3,3,0,9,7,2,5,6,7,0,4,2,4,6,3,4,4,2,2,6,7,3,1,7,9,4,5,6,7,5,3,7,3,7,9,8,4,5,8}, 8923)]
        public void CountNodesTests(int[] tree, int expected)
        {
            Assert.Equal(expected, CountNodes(new TreeNode(tree)));
        }
        
        // Return tree depth in O(d) time.
        public int ComputeDepth(TreeNode node) {
            int d = 0;
            while (node.left != null) {
                node = node.left;
                ++d;
            }
            return d;
        }

        // Last level nodes are enumerated from 0 to 2**d - 1 (left -> right).
        // Return True if last level node idx exists. 
        // Binary search with O(d) complexity.
        public bool Exists(int idx, int d, TreeNode node) {
            int left = 0, right = (int)Math.Pow(2, d) - 1;
            int pivot;
            for(int i = 0; i < d; ++i) {
                pivot = left + (right - left) / 2;
                if (idx <= pivot) {
                    node = node.left;
                    right = pivot;
                }
                else {
                    node = node.right;
                    left = pivot + 1;
                }
            }
            return node != null;
        }

        public int CountNodes(TreeNode root) {
            int d = ComputeDepth(root);
            // if the tree contains 1 node
            if (d == 0) return 1;

            // Last level nodes are enumerated from 0 to 2**d - 1 (left -> right).
            // Perform binary search to check how many nodes exist.
            int left = 1, right = (int)Math.Pow(2, d) - 1;
            int pivot;
            while (left <= right) {
                pivot = left + (right - left) / 2;
                if (Exists(pivot, d, root)) left = pivot + 1;
                else right = pivot - 1;
            }

            // The tree contains 2**d - 1 nodes on the first (d - 1) levels
            // and left nodes on the last level.
            return (int)Math.Pow(2, d) - 1 + left;
        }
        
        // public int CountNodes(TreeNode root)
        // {
        //     if (root == null)
        //         return 0;
        //     
        //     var stack = new Stack<TreeNode>();
        //     stack.Push(root);
        //     var result = 0;
        //     while (stack.Count > 0)
        //     {
        //         var list = new List<TreeNode>();
        //
        //         result += stack.Count;
        //         while (stack.Count > 0)
        //             list.Add(stack.Pop());
        //         
        //         for (int i = list.Count - 1; i >= 0; i--)
        //         {
        //             var node = list[i];
        //             if (node.left != null)
        //                 stack.Push(node.left);
        //             if (node.right != null)
        //                 stack.Push(node.right);
        //         }
        //     }
        //     
        //     return result;
        // }
    }
}