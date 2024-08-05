namespace Boardgames.DataProcessor.ExportDto
{
    public class ExportSellerDto
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public BoardgameDto[] Boardgames { get; set; }
    }


    public class BoardgameDto
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Mechanics { get; set; }
        public string Category { get; set; }

    }
}
