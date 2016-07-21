using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miktemk.TextToSpeech
{
    public class MultiLanguageText
    {
        public List<UniLangPhrase> Phrases { get; set; }

        public MultiLanguageText()
        {
            Phrases = new List<UniLangPhrase>();
        }
    }

    public class UniLangPhrase
    {
        public string Lang { get; set; }
        public string Text { get; set; }
    }
}
