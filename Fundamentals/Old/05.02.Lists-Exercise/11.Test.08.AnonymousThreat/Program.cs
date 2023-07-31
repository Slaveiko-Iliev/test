List<string> list = Console.ReadLine()!.Split(' ').ToList();
string line = "";
while ((line = Console.ReadLine()!) != "3:1")
{
    string[] data = line.Split(' ');
    int start = int.Parse(data[1]);
    int end = int.Parse(data[2]);
    if (data[0] == "merge")
    {
        if (start < 0) start = 0;
        if (end >= list.Count) end = list.Count - 1;
        for (int diff = end - start; diff > 0; --diff)
        {
            list[start] += list[start + 1];
            list.RemoveAt(start + 1);
        }
    }
    if (data[0] == "divide")
    {
        int partSize = list[start].Length / end;
        int counter = end;
        int off = 1;
        while (counter > 1)
        {
            counter--;
            list.Insert(start + off, new string(list[start].Take(partSize).ToArray()));
            off++;
            list[start] = new string(list[start].Skip(partSize).ToArray());
        }
        list.Insert(start + off, list[start]);
        list.RemoveAt(start);
    }
}
Console.WriteLine(string.Join(' ', list));