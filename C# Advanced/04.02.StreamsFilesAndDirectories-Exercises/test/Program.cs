using System;
using System.IO;
using System.IO.Compression;

var fileName = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.Desktop), "report.txt");

Console.WriteLine(fileName);


//DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(
//    Environment.SpecialFolder.Desktop)));


string[] filesInDir = Directory.GetFiles(Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.Desktop)));

string path = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.Desktop));

for (int i = 0; i < filesInDir.Length; i++)
{
    filesInDir[i] = filesInDir[i].Replace(path, string.Empty).Replace("\\", string.Empty);
}

Console.WriteLine(string.Join(Environment.NewLine, filesInDir));

int aggregate(start, end, func) { … }
int sum = aggregate(1, 10, (a, b) => a + b); // 55

