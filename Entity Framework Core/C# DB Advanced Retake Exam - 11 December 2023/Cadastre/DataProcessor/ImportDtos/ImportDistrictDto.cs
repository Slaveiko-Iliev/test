using Cadastre.Common;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictDto
    {
        [XmlAttribute("Region")]
        public int Region { get; set; }
        [XmlElement("Name")]
        [MinLength(ValidationConstants.DistrictNameMinLength)]
        [MaxLength(ValidationConstants.DistrictNameMaxLength)]
        public string Name { get; set; } = null!;
        [XmlElement("PostalCode")]
        [StringLength(ValidationConstants.DistrictPostalCodeMaxLength)]
        [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
        public string PostalCode { get; set; } = null!;
        [XmlArray("Properties")]
        [XmlArrayItem(nameof(Property))]
        public PropertyDto[] Properties { get; set; } = null!;
    }

    [XmlType("Property")]
    public class PropertyDto
    {
        [XmlElement("PropertyIdentifier")]
        [MaxLength(ValidationConstants.PropertyIdentifierMaxLength)]
        [MinLength(ValidationConstants.PropertyIdentifierMinLength)]
        public string PropertyIdentifier { get; set; } = null!;
        [XmlElement("Area")]
        [MinLength(ValidationConstants.PropertyAreaMinLength)]
        [MaxLength(ValidationConstants.PropertyAreaMaxLength)]
        public int Area { get; set; }
        [XmlElement("Details")]
        [MinLength(ValidationConstants.PropertyDetailsMinLength)]
        [MaxLength(ValidationConstants.PropertyDetailsMaxLength)]
        public string? Details { get; set; }
        [XmlElement("Address")]
        [MinLength(ValidationConstants.PropertyAddressMinLength)]
        [MaxLength(ValidationConstants.PropertyAddressMaxLength)]
        public string Address { get; set; } = null!;
        [XmlElement("DateOfAcquisition")]
        public DateTime DateOfAcquisition { get; set; }
        //[XmlIgnore]
        //public District District { get; set; } = null!;
    }
}
