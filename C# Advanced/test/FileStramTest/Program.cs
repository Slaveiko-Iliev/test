using System.IO;

using (FileStream stream = new FileStream(@"C:\Users\Botsi\Desktop\08.Text Processing.txt", FileMode.Open))
{
    while (stream.Position < stream.Length)
    {
        byte[] buffer = new byte[4];

        stream.Read(buffer, 0, 4);

        for (int i = 0; i < buffer.Length; i++)
        {
            Console.Write((char)buffer[i]); ;
        }
    }

}

