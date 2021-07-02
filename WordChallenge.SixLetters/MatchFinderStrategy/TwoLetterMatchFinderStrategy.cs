using System.Collections.Generic;
using System.Linq;
using WordChallenge.SixLetters.MatchFinderStrategy.Interface;
using WordChallenge.SixLetters.Models;

namespace WordChallenge.SixLetters.MatchFinderStrategy
{
    public class TwoLetterMatchFinderStrategy : IMatchFinderStrategy
    {
        public string FindMatch(string wordToBuild, CombinationBuilder builder, List<string> searchList)
        {
            if (builder.CurrentStateLength <= 4)
            {
                var currentStatus = builder.GetCurrentWordState();

                var partToFind = wordToBuild.Substring(currentStatus.Length, 2);

                var result = searchList.Find(l => l.Contains(partToFind) && l.Length == 2);

                return result;

            }

            return string.Empty;
        }
    }
}