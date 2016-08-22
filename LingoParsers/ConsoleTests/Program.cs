using IlyaFrankParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miktemk;
using System.Diagnostics;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Program_CreateWordHistogram(); // this creates all _gt splits of 2000... we already ran this - July 15, 2016
            new Program_MergeDictionaries();
            //new Program_AlignTest(MyDatafiles.SwannFr, MyDatafiles.SwannRu);
        }
        
    }
}
