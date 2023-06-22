namespace _03.Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] songInfo = Console.ReadLine()
                    .Split("_");

                Song song = new Song
                {
                    TypeList = songInfo[0],
                    Name = songInfo[1],
                    Time = songInfo[2]
                };

                songs.Add(song);
            }
            string input = Console.ReadLine();

            if (input == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach(Song song in songs)
                {
                    if(input == song.TypeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }

        public class Song
        {
            public string TypeList { get; set; }

            public string Name { get; set; }

            public string Time { get; set; }
        }
    }
}