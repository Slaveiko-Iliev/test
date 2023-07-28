string[] input = Console.ReadLine()
    .Split('.');

string fileExtension = input[input.Length - 1];

string[] fileNamePath = input[0]
    .Split("\\");

string fileName = fileNamePath[fileNamePath.Length-1];

Console.WriteLine($"File name: {fileName}");
Console.WriteLine($"File extension: {fileExtension}");

