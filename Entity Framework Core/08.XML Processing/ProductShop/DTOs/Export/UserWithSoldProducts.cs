using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class UserWithSoldProducts
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("firstName")]
        public string LastName { get; set; }
        [XmlArray("soldProducts")]
        public SoldProduct[] SoldProducts { get; set; }
    }

    [XmlType("Product")]
    public class SoldProduct
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
