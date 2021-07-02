using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using WordChallenge.SixLetters.Models;

namespace WordChallenge.SixLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchList = ReadFile();

            // get all six letter words
            var sixLetterWords = searchList.Where(l => l.Length == 6).ToList();

            // create object to build possible combinations
            var wordCombinationBuilders = sixLetterWords.Select(word => new WordCombinationBuilder
            {
                WordToBuild = word,
                CombinationBuilders = new List<CombinationBuilder>()
            }).ToList();

            var output = new StringBuilder();

            foreach (var matchFinder in wordCombinationBuilders.Select(word => new MatchFinder(word, searchList)))
            {
                output.Append(matchFinder.GetResults());
            }

            output.AppendLine();
            output.AppendLine($"6-letter words found: {sixLetterWords.Count}");
            output.AppendLine(
                $"Total nr of combinations found: {wordCombinationBuilders.Sum(b => b.CombinationBuilders.Count)}");

            Console.Write(output.ToString());
        }

        private static List<string> ReadFile()
        {
            var filePath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
            var file = File.ReadAllLines($"{filePath}\\input.txt");
            var lines = new List<string>(file);

            return lines;
        }
    }
}
