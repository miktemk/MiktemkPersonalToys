using IlyaFrankParser;
using Miktemk;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace ConsoleTests
{
    public class Program_CreateWordHistogram
    {
        public Program_CreateWordHistogram()
        {
            CreateWordHistogram(MyDatafiles.MmeBovaryFr);
            CreateWordHistogram(MyDatafiles.MmeBovaryRu);
            CreateWordHistogram(MyDatafiles.VoyageFr);
            CreateWordHistogram(MyDatafiles.VoyageRu);
            CreateWordHistogram(MyDatafiles.SwannFr);
            CreateWordHistogram(MyDatafiles.SwannRu);
        }

        private void CreateWordHistogram(string filenameTxt)
        {
            var outPrefix = Path.Combine(Path.GetDirectoryName(filenameTxt), "dict", Path.GetFileNameWithoutExtension(filenameTxt));

            Encoding encoding;
            var textFr = UtilsPath.ReadTextFileAndGetEncoding(filenameTxt, out encoding);
            var hist = WordHistogram.BuildHistogramFromText(textFr);

            File.WriteAllText($"{outPrefix}.histogram-counts.txt",
                String.Join("\n", hist.Words.Select(x => $"{x.Word}\t{x.Count}")),
                encoding);
            File.WriteAllText($"{outPrefix}.histogram.txt",
                String.Join("\n", hist.Words.Select(x => x.Word)),
                encoding);
            // smaller chunks for stupid GT
            int index = 0;
            foreach (var chunk2000 in hist.Words.Chunk(2000))
            {
                index++;
                Debug.WriteLine($"{index}: {chunk2000.Count()} lines");
                File.WriteAllText($"{outPrefix}.histogram-gt{index}.txt", String.Join("\n", chunk2000.Select(x => x.Word)), encoding);
            }
        }

        private void FixLineEndingsBovary(string fileIn, string fileOut = null)
        {
            if (fileOut == null)
                fileOut = fileIn;
            Encoding encoding;
            var textFr = UtilsPath.ReadTextFileAndGetEncoding(fileIn, out encoding);
            textFr = textFr.Replace("\r\n\r\n", "zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");
            textFr = textFr.Replace("\r\n", "");
            textFr = textFr.Replace("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz", "\r\n");
            File.WriteAllText(fileOut, textFr, encoding);
        }
    }
}