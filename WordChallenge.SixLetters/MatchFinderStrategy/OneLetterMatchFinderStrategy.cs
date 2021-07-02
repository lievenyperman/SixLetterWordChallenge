using System.Collections.Generic;
using System.Linq;
using WordChallenge.SixLetters.MatchFinderStrategy.Interface;
using WordChallenge.SixLetters.Models;

namespace WordChallenge.SixLetters.MatchFinderStrategy
{
    public class OneLetterMatchFinderStrategy : IMatchFinderStrategy
    {
        public string FindMatch(string wordToBuild, CombinationBuilder builder, List<string> searchList)
        {
            var currentStatus = builder.GetCurrentWordState();

            var charToFind = wordToBuild.ElementAt(currentStatus.Length);

            var result = searchList.Find(l => l.Contains(charToFind) && l.Length == 1);

            return result;
        }
    }
}