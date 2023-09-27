namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            int shortLength = int.MinValue;
            int remainingLength = int.MinValue;
            bool isSecond = false;


            if (firstInputFilePath.Length < secondInputFilePath.Length)
            {
                shortLength = firstInputFilePath.Length;
                remainingLength = secondInputFilePath.Length - firstInputFilePath.Length;
                isSecond = true;
            }
            else
            {
                shortLength = secondInputFilePath.Length;
                remainingLength = firstInputFilePath.Length - secondInputFilePath.Length;
            }

            using (StreamReader firstReader = new StreamReader(firstInputFilePath))
            {
                using (StreamReader secondReader = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        for (int i = 0; i < shortLength; i++)
                        {
                            string lineFromFirst = firstReader.ReadLine();
                            string lineFromSecond = secondReader.ReadLine();
                            writer.WriteLine(lineFromFirst);
                            writer.WriteLine(lineFromSecond);
                        }

                        if (isSecond)
                        {
                            for (int i = 0; i < remainingLength; i++)
                            {
                                string lineFromSecond = secondReader.ReadLine();
                                writer.WriteLine(lineFromSecond);
                            }
                        }
                        else
                        {
                            string lineFromFirst = firstReader.ReadLine();
                            writer.WriteLine(lineFromFirst);
                        }
                    }
                }
            }
        }
    }
}
