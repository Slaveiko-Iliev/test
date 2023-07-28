using System.Text;

StringBuilder sb = new StringBuilder(Console.ReadLine());

for (int i = sb.Length - 1; i > 0; i--)
{
    if (sb[i] == sb[i - 1])
    {
        sb.Remove(i-1, 1);
    }
}

Console.WriteLine(sb);