using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WordChallenge.SixLetters.MatchFinderStrategy;
using WordChallenge.SixLetters.MatchFinderStrategy.Interface;

namespace WordChallenge.SixLetters.Models
{
    public class WordCombinationBuilder
    {
        public string WordToBuild { get; set; }
        public List<CombinationBuilder> CombinationBuilders { get; set; }

        public void ExecuteMatchFinderStrategies(List<string> searchList)
        {
            {
                var tempCombiBuilders = new List<CombinationBuilder>(CombinationBuilders.Where(b => b.Active && !b.SuccessFullyMatched));

                foreach (var tempBuilder in tempCombiBuilders)
                {
                    if (tempBuilder.CurrentStateLength < 6)
                    {
                        switch (tempBuilder.WordParts.Count)
                        {
                            case 0:
                            case 1:
                                ProcessStrategy(new OneLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new TwoLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new ThreeLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new FourLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new FiveLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                break;
                            case 2:
                                ProcessStrategy(new OneLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new TwoLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new ThreeLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new FourLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                break;
                            case 3:
                                ProcessStrategy(new OneLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new TwoLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new ThreeLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                break;
                            case 4:
                                ProcessStrategy(new OneLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                ProcessStrategy(new TwoLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                break;
                            case 5:
                                ProcessStrategy(new OneLetterMatchFinderStrategy(), GetNewCandidate(tempBuilder), searchList);
                                break;
                        }
                    }

                    CombinationBuilders.RemoveAll(b => b.WordParts.SequenceEqual(tempBuilder.WordParts));
                }

                CombinationBuilders.RemoveAll(b => !b.Active);
            }
        }

        private CombinationBuilder GetNewCandidate(CombinationBuilder builder)
        {
            return new CombinationBuilder
            {
                Active = builder.Active,
                CurrentStateLength = builder.CurrentStateLength,
                SuccessFullyMatched = builder.SuccessFullyMatched,
                WordParts = new List<string> (builder.WordParts)
            };
        }

        private void ProcessStrategy(IMatchFinderStrategy strategy, CombinationBuilder builder, List<string> searchList)
        {
            if (!builder.SuccessFullyMatched && builder.Active)
            {
                var result = strategy.FindMatch(WordToBuild, builder, searchList);

                if (string.IsNullOrWhiteSpace(result))
                {
                    builder.Active = false;
                    builder.SuccessFullyMatched = false;
                }
                else
                {
                    builder.WordParts.Add(result);
                    if (builder.GetCurrentWordState().Length == 6)
                    {
                        builder.SuccessFullyMatched = true;
                    }

                    builder.CurrentStateLength = builder.WordParts.Sum(p => p.Length);

                    if (!CombinationBuilders.Any(b => b.WordParts.SequenceEqual(builder.WordParts)))
                    {
                        CombinationBuilders.Add(builder);
                    }
                }
            }
        }
    }
}