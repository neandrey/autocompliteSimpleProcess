using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace SimpleTextProcessor
{
    internal class FrequencyAnalysisTask
    {
        internal static Dictionary<string, int> GetMostFrequentNextWords(List<List<string>> text)
        {
            char ch = '\'';
            var result = new Dictionary<string, int>();

            foreach (var sentence in text)
            {
                foreach (var word in sentence)
                {
                    if (word.Length < 3 || word.Length > 15)
                    {
                        //integration++;
                        continue;
                    }
                    else
                    {
                        if (word.IndexOf(ch) != -1)
                        {
                            string[] words = word.Split(ch);
                            var output = words[0] + "''" + words[1];
                            addElementDictionary(output, result);
                        }
                        else
                        {
                            addElementDictionary(word, result);
                        }
                    }    
                }
            }
            result = RemoveWordMaxThreeSymbols(result);

            //foreach(var pair in result)
            //{
            //    Console.WriteLine("key={0} \t value = {1}", pair.Key, pair.Value);
            //}

            return result;
        }
        //-----------------------------------

        private static void addElementDictionary(string word, Dictionary<string, int> result)
        {
            if (!result.ContainsKey(word))
                result[word] = 1;
            else
                result[word] = result[word] + 1;
        }

        //-----------------------------------
        private static Dictionary<string, int> RemoveWordMaxThreeSymbols
            (Dictionary<string, int> result)
        {
            var keyForRemove = new List<string>();

            foreach (var pair in result)
            {
                if (pair.Value < 3)
                    keyForRemove.Add(pair.Key);
            }

            foreach (var key in keyForRemove)
                result.Remove(key);

            return result;
        }
        //-------------------------------------------
    }
}