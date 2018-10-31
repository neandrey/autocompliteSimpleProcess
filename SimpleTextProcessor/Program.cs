using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextProcessor
{
     
    internal static class Program
    {
        static void Main(string[] args)
        {

            var connectStringDB = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var text = File.ReadAllText("HarryPotterText.txt");
            var sentences = SentencesParserTask.ParseSentences(text);
            var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
            //dataBaseInitial.dbInitialMethod(connectStringDB, frequency);

            Console.ReadKey();
        }

        
    }
}
