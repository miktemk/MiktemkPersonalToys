using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyaFrankParser
{
    public class WordHistogram
    {
        private List<WordAndCount> _words;
        public IEnumerable<WordAndCount> Words { get { return _words.OrderByDescending(x => x.Count); } }

        public WordHistogram()
        {
            _words = new List<WordAndCount>();
        }

        public void AddWord(string word)
        {
            var existing = _words.FirstOrDefault(x => x.Word == word);
            if (existing != null)
                existing.Count++;
            else
                _words.Add(new WordAndCount(word));
        }

        #region ------------------------------- parsing shit ---------------------------------

        public static WordHistogram BuildHistogramFromText(string textFr)
        {
            var splitWords = textFr.Split(new[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            var hist = new WordHistogram();
            foreach (var wordDirty in splitWords)
            {
                var wordClean = StripSymbols(wordDirty);
                if (string.IsNullOrEmpty(wordClean))
                    continue;
                hist.AddWord(wordClean.ToLower());
            }

            return hist;
        }

        public static string StripSymbols(string word)
        {
            word = word.Trim();
            var indexFirstLetter = -1;
            var indexLastLetter = -1;
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsLetter(word[i]))
                {
                    if (indexFirstLetter == -1)
                        indexFirstLetter = i;
                    indexLastLetter = i;
                }
            }
            if (indexFirstLetter == -1 || indexLastLetter == -1)
                return string.Empty;
            return word.Substring(indexFirstLetter, indexLastLetter - indexFirstLetter + 1);
        }

        #endregion
    }

    public class WordAndCount
    {
        public WordAndCount(string word)
        {
            Word = word;
            Count = 1;
        }

        public string Word { get; set; }
        public int Count { get; set; }
    }
}
