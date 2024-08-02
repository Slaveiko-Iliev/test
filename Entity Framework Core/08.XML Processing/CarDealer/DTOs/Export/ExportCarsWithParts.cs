using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("car")]
    public class ExportCarsWithParts
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; } = null!;
        [XmlAttribute("traveled-distance")]
        public long TraveledDistance { get; set; }
        [XmlArray("parts")]
        public PartDto[] Parts { get; set; } = null!;
    }

    [XmlType("part")]
    public class PartDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
