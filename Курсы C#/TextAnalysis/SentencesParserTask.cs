using System.Collections.Generic;
using System;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var builder = new StringBuilder();
            var sentence = text.Split('.', '!', '?', ';', ':', '(', ')');
            var sentences = new List<string>();
            foreach (string str in sentence)
            {
                if (str.Length > 0)
                    sentences.Add(str);
            }
            var words = new List<string>();
            foreach (string str in sentences)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '\'' || char.IsLetter(str[i]))
                    {
                        builder.Append(str[i]);
                    }
                    else
                    {
                        if (builder.Length > 0)
                        {
                            words.Add((builder.ToString()).ToLower());
                            builder.Clear();
                        }
                    }
                }
                if (builder.Length > 0)
                {
                    words.Add((builder.ToString()).ToLower());
                    builder.Clear();
                }
                if (words.Count > 0)
                {
                    sentencesList.Add(words);
                    words.Clear();
                }
            }
            return sentencesList;
        }
    }
}