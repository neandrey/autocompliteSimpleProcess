using System;
using System.Configuration;
using System.IO;

namespace SimpleTextProcessor
{
    internal class ClassData
    {

        internal static void InitialData()
        {
            var connectStringDB = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var text = File.ReadAllText("HarryPotterText.txt");
            var sentences = SentencesParserTask.ParseSentences(text);
            var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
            //dataBaseInitial.dbInitialMethod(connectStringDB, frequency);
            dataBaseInitial.dbSelectMethod(connectStringDB, frequency);
        }

    }
}