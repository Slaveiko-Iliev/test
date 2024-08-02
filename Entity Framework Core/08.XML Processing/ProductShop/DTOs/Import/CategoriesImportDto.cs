using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType(nameof(Category))]
    public class CategoriesImportDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;
    }
}
