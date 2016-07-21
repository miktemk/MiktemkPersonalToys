using Miktemk.TextToSpeech;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FilterByCyrillicPhrases
{
    class Program
    {
        public Program()
        {
            // TODO: use config file maybe
            var langCodeLatin = "de";
            var langCodeCyril = "ru";
            var inFile = @"C:\OtherMiktemk\datafiles\german-grammar\german-grammar.txt";
            var outFile = @"C:\OtherMiktemk\datafiles\german-grammar\german-grammar-split.xml";

            var textFile = File.ReadAllLines(inFile);
            var textSentenceSplit = textFile.SelectMany(para => para.Split(new [] { ".", "?", "!" }, StringSplitOptions.RemoveEmptyEntries));

            var allTextStruct = new MultiLanguageText();
            foreach (var sentence in textSentenceSplit)
            {
                var phraseSplits = Utils.SplitAwayCyrillics(sentence, langCodeLatin, langCodeCyril).ToList();
                foreach (var phrase in phraseSplits)
                {
                    allTextStruct.Phrases.Add(phrase);
                }
            }

            var serializer = new XmlSerializer(typeof(MultiLanguageText));
            using (StreamWriter textWriter = new StreamWriter(new FileStream(outFile, FileMode.Create)))
            {
                serializer.Serialize(textWriter, allTextStruct);
            }
        }

        //============================================================

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
