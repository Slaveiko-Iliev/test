using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientDto
    {
        [XmlElement("Name")]
        [MinLength(10)]
        [MaxLength(25)]
        public string Name { get; set; } = null!;
        [XmlElement("NumberVat")]
        [MinLength(10)]
        [MaxLength(15)]
        public string NumberVat { get; set; } = null!;
        [XmlArray("Addresses")]
        public AddressDto[]? Addresses { get; set; }
    }

    [XmlType("Address")]
    public class AddressDto
    {
        [XmlElement("StreetName")]
        [MinLength(10)]
        [MaxLength(20)]
        public string StreetName { get; set; } = null!;
        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }
        [XmlElement("PostCode")]
        public string PostCode { get; set; } = null!;
        [XmlElement("City")]
        [MinLength(5)]
        [MaxLength(15)]
        public string City { get; set; } = null!;
        [XmlElement("Country")]
        [MinLength(5)]
        [MaxLength(15)]
        public string Country { get; set; } = null!;
    }
}
