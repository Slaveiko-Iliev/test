using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Data.Models
{
    public class TourPackage
    {
        public TourPackage()
        {
            Bookings = new HashSet<Booking>();
            TourPackagesGuides = new HashSet<TourPackageGuide>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string PackageName { get; set; } = null!;
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public ICollection<Booking> Bookings { get; set; }
        [Required]
        public ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
    }
}

//•	TourPackagesGuides - collection of type TourPackageGuide
