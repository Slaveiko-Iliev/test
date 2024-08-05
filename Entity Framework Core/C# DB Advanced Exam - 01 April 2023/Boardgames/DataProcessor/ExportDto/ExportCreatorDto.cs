using Boardgames.Data.Models;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType(nameof(Creator))]
    public class ExportCreatorDto
    {
        [XmlAttribute]
        public int BoardgamesCount { get; set; }
        [XmlElement]
        public string CreatorName { get; set; }
        [XmlArray]
        public ExportBoardgameDto[] Boardgames { get; set; }
    }

    [XmlType(nameof(Boardgame))]
    public class ExportBoardgameDto
    {
        [XmlElement]
        public string BoardgameName { get; set; }
        [XmlElement]
        public int BoardgameYearPublished { get; set; }
    }
}
