using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            ClientsTrucks = new HashSet<ClientTruck>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(8)]
        public string RegistrationNumber { get; set; } = null!;
        [Required]
        [StringLength(17)]
        public string VinNumber { get; set; } = null!;
        [Range(950, 1420)]
        public int TankCapacity { get; set; }
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }
        public CategoryType CategoryType { get; set; }
        public MakeType MakeType { get; set; }
        public int DespatcherId { get; set; }
        [ForeignKey(nameof(DespatcherId))]
        public Despatcher Despatcher { get; set; } = null!;
        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
