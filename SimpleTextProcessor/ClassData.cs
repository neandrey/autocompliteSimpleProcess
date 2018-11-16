using System;
using System.Configuration;
using System.IO;

namespace SimpleTextProcessor
{
    class ClassData
    {
        
        public void InitialData(string connectStringDB, string text)
        {
            var sentences = SentencesParserTask.ParseSentences(text);
            var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
            dataBaseInitial.dbInitialMethod(connectStringDB, frequency);
        }

        public void DeleteData(string connectStringDB)
        {
            dataBaseInitial.dbDeleteMethod(connectStringDB);
        }

        internal void AutoComplite(string connectStringDB, string autocomplitWord)
        {
            dataBaseInitial.dbAutoComplSearch(connectStringDB, autocomplitWord);
        }

        internal void UpdateData(string connectStringDB, string text)
        {
            var sentences = SentencesParserTask.ParseSentences(text);
            var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
            dataBaseInitial.dbUpdateMethod(connectStringDB, frequency);
        }
    }
}