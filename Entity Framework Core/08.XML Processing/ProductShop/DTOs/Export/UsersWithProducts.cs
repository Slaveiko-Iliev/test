using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    public class UsersWithProducts
    {
        [XmlElement("")]
        public int Count { get; set; }
        public UserDto[] Users { get; set; }
    }

    [XmlType("User")]
    public class UserDto
    {

    }
}
