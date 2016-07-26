using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyaFrankParser
{
    public class IlyaFrankDocument
    {
        public List<IlyaFrankParagraph> Paragraphs { get; set; }
    }

    public class IlyaFrankParagraph
    {
        public string FullText { get; set; }
        public List<IlyaFrankPhrase> Phrases { get; set; }
    }

    public class IlyaFrankPhrase
    {
        public string Text { get; set; }
        public string Translation { get; set; }
        public List<IlyaFrankVocabPoint> Vocab { get; set; }
    }

    public class IlyaFrankVocabPoint
    {
        public string WordInText { get; set; }
        public string Translation { get; set; }
    }
}
