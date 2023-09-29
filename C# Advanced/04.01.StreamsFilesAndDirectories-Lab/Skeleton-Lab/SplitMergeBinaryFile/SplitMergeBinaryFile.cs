namespace SplitMergeBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] exampleAsByte = File.ReadAllBytes(sourceFilePath);

            List<byte> partOne = new();
            List<byte> partTwo = new();

            for (int i = 0; i < exampleAsByte.Length; i++)
            {
                if (i % 2 == 0)
                {
                    partOne.Add(exampleAsByte[i]);
                }
                else
                {
                    {
                        partTwo.Add(exampleAsByte[i]);
                    }
                }
            }

            File.WriteAllBytes(partOneFilePath, partOne.ToArray());
            File.WriteAllBytes(partTwoFilePath, partTwo.ToArray());
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] partOne = File.ReadAllBytes(partOneFilePath);
            byte[] partTwo = File.ReadAllBytes(partTwoFilePath);

            List<byte> joined = new();

            for(int i = 0;i < partOne.Length + partTwo.Length;i++)
            {
                if (i < partOne.Length)
                {
                    joined.Add(partOne[i]);
                }
                if (i < partTwo.Length)
                {
                    joined.Add(partTwo[i]);
                }
            }

            File.WriteAllBytes(joinedFilePath, joined.ToArray());
        }
    }
}