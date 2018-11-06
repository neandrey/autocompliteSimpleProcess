using System;
using System.Collections.Generic;

namespace SimpleTextProcessor
{
    internal class SentencesParserTask
    {
        //-----------------------------------------------------
        public static List<List<string>> ParseSentences(string text)
            {
                var sentencesList = new List<List<string>>();
                //var wordsInSentence = new List<string>();
                string[] sentenceString;
                sentenceString = text.Split('.', '!', '?', ':', ';', '(', ')');
                foreach (var s in sentenceString)
                {
                    if (SymbolParsing(s).Count != 0)
                        sentencesList.Add(SymbolParsing(s));
                }
                return sentencesList;
            }

        //--------------------------------------------------------------
        private static List<string> SymbolParsing(string symbolArray)
            {
                List<string> wordsInSentence = new List<string>();
                string compStr = "";

                foreach (var word in symbolArray)
                {
                    if (char.IsLetter(word) || word == '\'')
                    {
                        compStr += Char.ToLower(word);
                    }
                    else
                    {
                        if (compStr == "")
                        {
                            compStr = "";
                            continue;
                        }
                        else
                        {
                            wordsInSentence.Add(compStr);
                            compStr = "";
                        }
                    }
                }
                if (compStr.Length != 0)
                    wordsInSentence.Add(compStr);

                return wordsInSentence;
            }
        }   
}