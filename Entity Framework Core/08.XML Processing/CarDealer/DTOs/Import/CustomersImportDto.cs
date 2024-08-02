using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType(nameof(Customer))]
    public class CustomersImportDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
