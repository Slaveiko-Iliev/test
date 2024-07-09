namespace MusicHub
{
    using Data;
    using System;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    a.Price,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriter = s.Writer
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.SongWriter.Name)
                    .ToArray()
                })
                .ToArray();


            StringBuilder sb = new StringBuilder();

            foreach (var album in albums.OrderByDescending(a => a.Price))
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int songNumber = 1;
                var songs = context.Albums;

                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{songNumber}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriter.Name}");

                    songNumber++;
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(s => s.Duration > new TimeSpan(0, 0, duration))
                .Select(s => new
                {
                    s.Name,
                    s.Writer,
                    PerformersSong = s.SongPerformers.Select(sp => new
                    {
                        PerformerName = $"{sp.Performer.FirstName} {sp.Performer.LastName}"
                    }),
                    ProducerName = s.Album.Producer.Name,
                    s.Duration
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            int songNumber = 1;

            foreach (var song in songs.OrderBy(s => s.Name).ThenBy(s => s.Writer.Name))
            {
                sb.AppendLine($"-Song #{songNumber}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.Writer.Name}");

                foreach (var p in song.PerformersSong.OrderBy(p => p.PerformerName))
                {
                    sb.AppendLine($"---Performer: {p.PerformerName}");
                }

                sb.AppendLine($"---AlbumProducer: {song.ProducerName}");
                sb.AppendLine($"---Duration: {song.Duration}");

                songNumber++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
