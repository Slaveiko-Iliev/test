using Cadastre.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastre.Data.Models
{
    public class Property
    {
        public Property()
        {
            PropertiesCitizens = new HashSet<PropertyCitizen>();
        }
        public int Id { get; set; }
        [MaxLength(ValidationConstants.PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; }
        public int Area { get; set; }
        [MaxLength(ValidationConstants.PropertyDetailsMaxLength)]
        public string? Details { get; set; }
        [MaxLength(ValidationConstants.PropertyAddressMaxLength)]
        public string Address { get; set; } = null!;
        public DateTime DateOfAcquisition { get; set; }
        public int DistrictId { get; set; }
        [ForeignKey(nameof(DistrictId))]
        public District District { get; set; } = null!;
        public ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
    }


    //•	PropertiesCitizens - collection of type PropertyCitizen
}
