using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("Guide")]
    public class ExportGuidesWithSpanishDto
    {
        [XmlElement(nameof(FullName))]
        public string FullName { get; set; } = null!;
        [XmlArray("TourPackages")]
        public ExportTourPackageDto[] TourPackages { get; set; }
    }

    [XmlType(nameof(TourPackage))]
    public class ExportTourPackageDto
    {
        [XmlElement(nameof(Name))]
        public string Name { get; set; }
        [XmlElement(nameof(Description))]
        public string Description { get; set; }
        [XmlElement(nameof(Price))]
        public decimal Price { get; set; }
    }
}
