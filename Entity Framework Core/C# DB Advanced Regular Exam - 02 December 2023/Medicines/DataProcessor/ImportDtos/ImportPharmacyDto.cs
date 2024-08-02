using Medicines.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [XmlAttribute("non-stop")]
        public string IsNonStop { get; set; } = null!;
        [XmlElement]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [XmlElement]
        [StringLength(14)]
        [RegularExpression("^\\(?\\d{3}\\)?[- ]?\\d{3}[- ]?\\d{4}$")]
        public string PhoneNumber { get; set; } = null!;
        [XmlArray]
        public MedicineDto[] Medicines { get; set; } = null!;
    }

    [XmlType("Medicine")]
    public class MedicineDto
    {
        [XmlAttribute("category")]
        public string Category { get; set; } = null!;
        [XmlElement]
        [MinLength(3)]
        [MaxLength(150)]
        public string Name { get; set; } = null!;
        [XmlElement]
        [Range(typeof(decimal), "0.01", "1000.00")]
        public decimal Price { get; set; }
        [XmlElement]
        public string ProductionDate { get; set; } = null!;
        [XmlElement]
        public string ExpiryDate { get; set; } = null!;
        [XmlElement]
        [MinLength(3)]
        [MaxLength(100)]
        public string Producer { get; set; } = null!;
    }
}
