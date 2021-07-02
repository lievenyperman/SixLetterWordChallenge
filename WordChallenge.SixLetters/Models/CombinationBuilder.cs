using System.Collections.Generic;
using System.Linq;

namespace WordChallenge.SixLetters.Models
{
    public class CombinationBuilder
    {
        public List<string> WordParts { get; set; }
        public bool Active { get; set; }
        public bool SuccessFullyMatched { get; set; }
        public int CurrentStateLength { get; set; }

        public string GetCurrentWordState()
        {
            return string.Join<string>(string.Empty, WordParts);
        }
    }
}