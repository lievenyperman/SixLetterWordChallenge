using System.Collections.Generic;
using WordChallenge.SixLetters.Models;

namespace WordChallenge.SixLetters.MatchFinderStrategy.Interface
{
    public interface IMatchFinderStrategy
    {
        string FindMatch(string wordToBuild, CombinationBuilder builder, List<string> searchList);
    }
}