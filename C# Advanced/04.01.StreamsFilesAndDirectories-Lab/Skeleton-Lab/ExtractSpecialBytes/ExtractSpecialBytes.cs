namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] exampleAsBytes = File.ReadAllBytes(binaryFilePath);

            byte[] givenBytes = File.ReadAllText(bytesFilePath)
                .Replace("\n", " ")
                .Replace("\r", " ")
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(byte.Parse)
                .ToArray();

            //using (StreamWriter output = new StreamWriter(outputPath))
            //{
            //    foreach (var item in givenBytes)
            //    {
            //        if (exampleAsBytes.Contains(item))
            //        {
            //            output.Write(item);
            //        }
            //    }
            //}

            List<byte> bytes = new List<byte>();

            foreach (var item in givenBytes)
            {
                if (exampleAsBytes.Contains(item))
                {
                    bytes.Add(item);
                }
            }

            File.WriteAllBytes(outputPath, bytes.ToArray());
        }
    }
}
