using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChallenge.SixLetters.MatchFinderStrategy;
using WordChallenge.SixLetters.Models;

namespace WordChallenge.SixLetters.UnitTests
{
    [TestClass]
    public class MatchFinderTests
    {
        [TestMethod]
        public void MatchFinderResults()
        {
            var searchList = SixLetterWordsMock.GetBasicMatchFinderMock();

            var wordCombinationBuilder = new WordCombinationBuilder
            {
                WordToBuild = "abcdef",
                CombinationBuilders = new List<CombinationBuilder>()
            };

            // sut
            var matchFinder = new MatchFinder(wordCombinationBuilder, searchList);

            var result = matchFinder.GetResults();

            Debug.WriteLine(result);

            Assert.AreEqual("abc+def=abcdef\r\n", result);
        }
    }
}
