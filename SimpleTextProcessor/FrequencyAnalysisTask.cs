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
            var result = new Dictionary<string, int>();

            foreach (var sentence in text)
            {
                foreach (var word in sentence)
                {
                    if(word.Length < 3 && word.Length > 15)
                    {
                        continue;
                    }
                    else
                    {
                        if (!result.ContainsKey(word))
                            result[word] = 1;
                        else
                            result[word] = result[word] + 1;
                    }
                }
            }

            //-------------------------------------------
            var keyForRemove = new List<string>();

            foreach (var pair in result)
            {
                if (pair.Value < 3)
                    keyForRemove.Add(pair.Key);
            }

            foreach (var key in keyForRemove)
                result.Remove(key);



            //------------------------------------------------
            var connectStringDB = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            foreach (var pair in result)
            {
                char ch = '\'';
                int indexOfChar = pair.Key.IndexOf(ch);
                if (indexOfChar != -1)
                {
                    string[] words = pair.Key.Split(ch);
                    string outside = words[0] + "''" + words[1];

                    dataBaseInitial.dbInitialMethod(connectStringDB, outside, pair.Value);
                }
                else
                dataBaseInitial.dbInitialMethod(connectStringDB, pair.Key, pair.Value);
            }

            



            return result;  
        }
    }
}