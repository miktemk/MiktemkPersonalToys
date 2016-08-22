using System;
using System.IO;
using Miktemk;
using System.Collections.Generic;

namespace ConsoleTests
{
    public class Program_MergeDictionaries
    {
        public Program_MergeDictionaries()
        {
            var wordsFr = File.ReadAllLines(MyDictionaries.SwannFr);
            var wordsFr_gtru = File.ReadAllLines(MyDictionaries.SwannFr_gtru);
            if (wordsFr.Length != wordsFr_gtru.Length)
                throw new Exception("words and translations do not match in length!");
            var dict = new LingoDict();
            wordsFr.EnumerateWith(wordsFr_gtru, (fr, frru, index) =>
            {
                dict.Entries.Add(new LingoDictWord
                {
                    Word = fr,
                    Translation = frru,
                });
            });

            XmlFactory.WriteToFile(dict, MyDictionaries.SwannDict);
        }
    }
}