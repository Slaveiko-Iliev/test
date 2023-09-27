namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary < string, Dictionary<string, double>> files = new();
                        
            DirectoryInfo dir = new DirectoryInfo(inputFolderPath);
            FileInfo[] infos = dir.GetFiles("*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo fileInfo in infos)
            {
                double length = Convert.ToDouble(fileInfo.Length) / 1024;
                string name = fileInfo.Name;
                string extension = fileInfo.Extension;

                if (!files.ContainsKey(extension))
                {
                    files.Add(extension, new Dictionary<string, double>());
                }

                files[extension][name] = length;
            }

            Dictionary<string, Dictionary<string, double>> orderedFiles = files
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ThenBy(x => x.Value.Values)
                .ToDictionary(x => x.Key, x => x.Value);

            using (StreamWriter streamWriter = new StreamWriter("report.txt", false))
            {
                foreach (var (extension, nameWithLength) in orderedFiles)
                {
                    streamWriter.WriteLine(extension);

                    foreach (var (name, length) in nameWithLength)
                    {
                        streamWriter.WriteLine($"--{name} - {length:f3}kb");

                    }
                }
            }

            string temp = File.ReadAllText("report.txt");
                        
            return temp;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string text = File.ReadAllText("report.txt");

            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt"), text);
        }
    }
}
