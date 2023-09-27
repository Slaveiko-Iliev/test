namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            long size = GetFolderSize(folderPath);
            WriteFolderSize(size, outputPath);
        }

        private static void WriteFolderSize(long size, string outputPath)
        {
            File.WriteAllText(outputPath, size.ToString());
        }

        public static long GetFolderSize(string folderPath)
        {
            long size = 0;

            string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    size += fileInfo.Length;
                }

            string[] directories = Directory.GetDirectories(folderPath);

            foreach (string directory in directories)
            {
                size += GetFolderSize(directory);
            }

                return size;

                //if (directories.Length == 0)
                //{
                //    break;
                //}

                //foreach (string directory in directories)
                //{
                //    string[] currentFiles = Directory.GetFiles(directory);

                //    foreach (string currentFile in currentFiles)
                //    {
                //        size += File.ReadAllBytes(currentFile).Length;
                //    }
                //}

            //string[] directories = Directory.GetDirectories(folderPath);

            //foreach (string directory in directories)
            //{

            //}
        }
    }
}
