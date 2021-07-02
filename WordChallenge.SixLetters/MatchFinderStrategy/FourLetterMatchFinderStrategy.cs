using System.Collections.Generic;
using WordChallenge.SixLetters.MatchFinderStrategy.Interface;
using WordChallenge.SixLetters.Models;

namespace WordChallenge.SixLetters.MatchFinderStrategy
{
    public class FourLetterMatchFinderStrategy : IMatchFinderStrategy
    {
        public string FindMatch(string wordToBuild, CombinationBuilder builder, List<string> searchList)
        {
            if (builder.CurrentStateLength <= 2)
            {
                var currentStatus = builder.GetCurrentWordState();

                var partToFind = wordToBuild.Substring(currentStatus.Length, 4);

                var result = searchList.Find(l => l.Contains(partToFind) && l.Length == 4);

                return result;

            }

            return string.Empty;
        }
    }
}