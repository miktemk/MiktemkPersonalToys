using Miktemk.TextToSpeech.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterByCyrillicPhrases
{
    public static class Utils
    {
        public static IEnumerable<UniLangPhrase> SplitAwayCyrillics(string s, string langCodeLatin, string langCodeCyril)
        {
            if (String.IsNullOrWhiteSpace(s))
                yield break;

            s = s.Trim();

            // .... find first letter
            var firstLetterIndex = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].IsCyrillic() || s[i].IsLatina())
                {
                    firstLetterIndex = i;
                    break;
                }
            }

            if (firstLetterIndex == -1)
                yield break;

            bool isInCyrillics = s[firstLetterIndex].IsCyrillic();
            bool changeHappened = false;
            int lastChangeIndex = 0;
            for (int i = 1; i < s.Length; i++)
            {
                // yield return s.Substring(i, 1);
                changeHappened = false;
                if (s[i].IsCyrillic())
                    changeHappened = WillYouChange(isInCyrillics, true, out isInCyrillics);
                if (s[i].IsLatina())
                    changeHappened = WillYouChange(isInCyrillics, false, out isInCyrillics);
                if (changeHappened && i > lastChangeIndex)
                {
                    yield return new UniLangPhrase
                    {
                        Text = s.Substring(lastChangeIndex, i - lastChangeIndex),
                        Lang = isInCyrillics ? langCodeLatin : langCodeCyril,
                    };
                    lastChangeIndex = i;
                }
            }
            if (lastChangeIndex < s.Length)
                yield return new UniLangPhrase
                {
                    Text = s.Substring(lastChangeIndex),
                    Lang = isInCyrillics ? langCodeCyril : langCodeLatin,
                };
        }

        public static bool WillYouChange(bool oldVal, bool newVal, out bool stateOut)
        {
            var result = newVal != oldVal;
            stateOut = newVal;
            return result;

        }

        public static bool IsCyrillic(this char c)
        {
            //[1040..1103], 1025, 1105
            // TODO: accented cyrillic chars
            return (c >= 1040 && c <= 1103)
                || c == 1025
                || c == 1105;
        }
        public static bool IsLatina(this char c)
        {
            return Char.IsLetter(c) && !c.IsCyrillic();
        }
    }
}
