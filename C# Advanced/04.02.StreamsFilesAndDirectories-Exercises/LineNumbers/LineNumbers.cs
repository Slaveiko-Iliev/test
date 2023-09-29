namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            
            string[] text = File.ReadAllLines(inputFilePath);
            Queue<string> processedTextAsLines = new();


            for (int i = 0; i < text.Length; i++)
            {
                int countOfLetters = 0;
                int countOfPunctuations = 0;

                foreach (char ch in text[i])
                {
                    if (char.IsLetter(ch))
                    {
                        countOfLetters++;
                    }
                    if (char.IsPunctuation(ch))
                    {
                        countOfPunctuations++;
                    }
                }

                processedTextAsLines.Enqueue($"Line {i + 1}: {text[i]} ({countOfLetters})({countOfPunctuations})");


            }

            File.WriteAllLines(outputFilePath, processedTextAsLines);
        }
    }
}
