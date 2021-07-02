using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChallenge.SixLetters.MatchFinderStrategy;
using WordChallenge.SixLetters.Models;

namespace WordChallenge.SixLetters.UnitTests
{
    [TestClass]
    public class MatchFinderStrategyTests
    {
        [TestMethod]
        public void OneLetterMatchFinderStrategyWithNewBuilder()
        {
            var searchList = SixLetterWordsMock.GetSixLetterWordsMock();

            var wordCombinationBuilder = new WordCombinationBuilder
            {
                WordToBuild = "abcdef",
                CombinationBuilders = new List<CombinationBuilder>
                {
                    new CombinationBuilder
                    {
                        WordParts = new List<string>(),
                        Active = true,
                        CurrentStateLength = 0,
                        SuccessFullyMatched = false
                    }
                }
            };

            var strategy = new OneLetterMatchFinderStrategy();
            
            var result = strategy.FindMatch(wordCombinationBuilder.WordToBuild,
                wordCombinationBuilder.CombinationBuilders.FirstOrDefault(), searchList);

            Assert.AreEqual("a", result);
        }

        [TestMethod]
        public void TwoLetterMatchFinderStrategyWithNewBuilder()
        {
            var searchList = SixLetterWordsMock.GetSixLetterWordsMock();

            var wordCombinationBuilder = new WordCombinationBuilder
            {
                WordToBuild = "abcdef",
                CombinationBuilders = new List<CombinationBuilder>
                {
                    new CombinationBuilder
                    {
                        WordParts = new List<string>(),
                        Active = true,
                        CurrentStateLength = 0,
                        SuccessFullyMatched = false
                    }
                }
            };

            var strategy = new TwoLetterMatchFinderStrategy();

            var result = strategy.FindMatch(wordCombinationBuilder.WordToBuild,
                wordCombinationBuilder.CombinationBuilders.FirstOrDefault(), searchList);

            Assert.AreEqual("ab", result);
        }

    }


}
