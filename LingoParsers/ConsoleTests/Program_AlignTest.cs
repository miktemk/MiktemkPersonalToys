using System;
using System.IO;

namespace ConsoleTests
{
    public class Program_AlignTest
    {
        private string fileFr;
        private string fileRu;

        public Program_AlignTest(string fileFr, string fileRu)
        {
            this.fileFr = fileFr;
            this.fileRu = fileRu;
            Run();
        }

        private void Run()
        {
            var textFr = File.ReadAllText(fileFr);
            var textRu = File.ReadAllText(fileRu);

        }
    }
}