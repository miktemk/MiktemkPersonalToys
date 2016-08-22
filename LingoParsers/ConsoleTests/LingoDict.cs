using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    public class LingoDict
    {
        public List<LingoDictWord> Entries { get; set; }

        public LingoDict()
        {
            Entries = new List<LingoDictWord>();
        }
    }

    public class LingoDictWord
    {
        public string Word { get; set; }
        public string Translation { get; set; }
    }
}
