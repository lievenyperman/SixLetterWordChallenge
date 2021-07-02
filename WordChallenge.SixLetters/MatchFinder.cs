using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WordChallenge.SixLetters.Models;

namespace WordChallenge.SixLetters
{
    public class MatchFinder
    {
        private readonly WordCombinationBuilder _wordCombinationBuilder;
        private readonly List<string> _searchList;

        public MatchFinder(WordCombinationBuilder wordCombinationBuilder, List<string> searchList)
        {
            _wordCombinationBuilder = wordCombinationBuilder;

            for (int i = 0; i < 5; i++)
            {
                _wordCombinationBuilder.CombinationBuilders.Add(new CombinationBuilder
                {
                    Active = true,
                    WordParts = new List<string>(),
                    SuccessFullyMatched = false,
                    CurrentStateLength = 0
                });
            }

            _searchList = searchList;
        }

        public string GetResults()
        {
            do
            {
                _wordCombinationBuilder.ExecuteMatchFinderStrategies(_searchList);
            } 
            while (_wordCombinationBuilder.CombinationBuilders.Any(
                b => b.Active && b.CurrentStateLength < 6 && !b.SuccessFullyMatched));

            return GenerateTextOutput(_wordCombinationBuilder);
        }

        private string GenerateTextOutput(WordCombinationBuilder wordCombinationBuilder)
        {
            var successfulMatches = wordCombinationBuilder.CombinationBuilders.Where(b => b.SuccessFullyMatched).ToList();

            var results = new StringBuilder();

            if (successfulMatches.Any())
            {
                foreach (var combinationBuilder in successfulMatches)
                {
                    results.AppendLine($"{string.Join('+', combinationBuilder.WordParts)}={wordCombinationBuilder.WordToBuild}");
                }

            }
            return results.ToString();
        }
    }
}