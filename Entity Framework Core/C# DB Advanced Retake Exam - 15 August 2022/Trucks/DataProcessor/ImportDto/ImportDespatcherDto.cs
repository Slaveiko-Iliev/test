using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType(nameof(Despatcher))]
    public class ImportDespatcherDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement(nameof(Name))]
        public string Name { get; set; } = null!;
        [XmlElement(nameof(Position))]
        public string? Position { get; set; }
        [XmlArray(nameof(Trucks))]
        public ImportTruckDto[] Trucks { get; set; } = null!;
    }

    [XmlType(nameof(Truck))]
    public class ImportTruckDto
    {
        [Required]
        [StringLength(8)]
        [RegularExpression("^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
        [XmlElement(nameof(RegistrationNumber))]
        public string RegistrationNumber { get; set; } = null!;
        [Required]
        [StringLength(17)]
        [XmlElement(nameof(VinNumber))]
        public string VinNumber { get; set; } = null!;
        [Range(950, 1420)]
        [XmlElement(nameof(TankCapacity))]
        public int TankCapacity { get; set; }
        [Range(5000, 29000)]
        [XmlElement(nameof(CargoCapacity))]
        public int CargoCapacity { get; set; }
        [XmlElement(nameof(CategoryType))]
        public int CategoryType { get; set; }
        [XmlElement(nameof(MakeType))]
        public int MakeType { get; set; }
    }

}

