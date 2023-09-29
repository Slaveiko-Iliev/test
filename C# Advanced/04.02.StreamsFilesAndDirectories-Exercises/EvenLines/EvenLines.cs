namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            int countOfLine = 0;
            Regex pattern = new Regex("[-,.!?]");
            string outputPath = @"..\..\..\output.txt";

            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                using (StreamWriter sw = new StreamWriter(outputPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string evenLine = sr.ReadLine();

                        if (countOfLine % 2 == 0)
                        {
                            evenLine = pattern.Replace(evenLine, "@");

                            string[] evenLineAsArray = evenLine
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Reverse()
                                .ToArray();

                            sw.WriteLine(string.Join(" ", evenLineAsArray));
                        }

                        countOfLine++;

                    }
                }
            }

            return outputPath;
        }
    }
}
