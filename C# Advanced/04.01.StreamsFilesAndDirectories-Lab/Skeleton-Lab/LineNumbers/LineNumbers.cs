namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            

            string line = string.Empty;
            int countOfLine = 1;

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();

                        writer.WriteLine($"{countOfLine}. {line}");
                        countOfLine++;
                    }
                }
            }


        }
    }
}
