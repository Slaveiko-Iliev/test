using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    public class ExportUserCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public UserDto[] Users { get; set; }
    }


    [XmlType("User")]
    public class UserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int? Age { get; set; }
        [XmlElement("SoldProducts")]
        public ProductSold ProductSold { get; set; }
    }

    public class ProductSold
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public ProductsDto[] Products { get; set; }
    }

    [XmlType("Product")]
    public class ProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
