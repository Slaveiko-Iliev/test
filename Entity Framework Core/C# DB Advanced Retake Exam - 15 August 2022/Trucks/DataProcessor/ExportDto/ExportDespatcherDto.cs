using System.Xml;
using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType(nameof(Despatcher))]
    public class ExportDespatcherDto
    {
        [XmlAttribute(nameof(TrucksCount))]
        public int TrucksCount { get; set; }
        [XmlElement(nameof(DespatcherName))]
        public string DespatcherName { get; set; }
        [XmlArray(nameof(Trucks))]
        public ExportDesTruckDto[] Trucks { get; set; }
    }

    [XmlType(nameof(Truck))]
    public class ExportDesTruckDto
    {
        [XmlElement(nameof(RegistrationNumber))]
        public string RegistrationNumber { get; set; }
        [XmlElement(nameof(Make))]
        public string Make { get; set; }
    }
}
