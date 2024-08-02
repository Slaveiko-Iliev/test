using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.Data.Models
{
    [XmlType("district2")]
    public class District
    {
        public District()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        [MaxLength(ValidationConstants.DistrictNameMaxLength)]
        public string Name { get; set; } = null!;
        [MaxLength(ValidationConstants.DistrictPostalCodeMaxLength)]
        public string PostalCode { get; set; } = null!;
        public Region Region { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
