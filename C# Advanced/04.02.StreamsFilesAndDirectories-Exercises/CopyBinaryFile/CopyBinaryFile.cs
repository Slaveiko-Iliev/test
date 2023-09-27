namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream fs = new FileStream(inputFilePath, FileMode.OpenOrCreate))
            {
                
            }

            using (var fsRead = new FileStream(inputFilePath, FileMode.Open))
            using (var fsWrite = new FileStream(outputFilePath, FileMode.Create))
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = fsRead.Read(buffer);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    
                    fsWrite.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
