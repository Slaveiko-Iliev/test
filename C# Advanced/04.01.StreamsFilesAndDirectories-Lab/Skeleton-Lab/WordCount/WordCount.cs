namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> words = new();
            
            using (StreamReader srWords = new StreamReader(wordsFilePath))
            {
                string[] wordsArray = srWords.ReadToEnd()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in wordsArray)
                {
                    words[word] = 0;
                }
            }

            using (StreamReader srText = new StreamReader(textFilePath))
            {
                string textAsString = srText.ReadToEnd().ToLower();
                    //.Where(c => !char.IsPunctuation(c))
                
                //.ToString();

                for (int i = 0; i < textAsString.Length; i++)
                {
                    if (char.IsPunctuation(textAsString[i]))
                    {
                        textAsString = textAsString.Remove(i, 1);
                    }
                }

                while (textAsString.Contains("\r\n"))
                {
                    textAsString = textAsString.Replace("\r\n", " ");
                }

                string[] text = textAsString
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var (word, count) in words)
                {
                    foreach (var item in text)
                    {
                        if (word == item)
                        {
                            words[word] ++;
                        }
                    }
                }
            }
            
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                foreach (var (word, count) in words.OrderByDescending(x => x.Value))
                {
                    sw.WriteLine($"{word} - {count}");
                }
            }
        }
    }
}
