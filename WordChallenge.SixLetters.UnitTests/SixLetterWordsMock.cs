using System.Collections.Generic;

namespace WordChallenge.SixLetters.UnitTests
{
    public class SixLetterWordsMock
    {
        public static List<string> GetSixLetterWordsMock()
        {
            return new List<string>
            {
                "a", "b", "c", "d", "e", "f",
                "ab", "cd", "ef",
                "abc", "bcd", "cde", "def",
                "abcdef", "aabbcc",
                "ghijkl"
            };
        }

        public static List<string> GetBasicMatchFinderMock()
        {
            return new List<string>
            {
                "abc", "def"
            };
        }
    }
}