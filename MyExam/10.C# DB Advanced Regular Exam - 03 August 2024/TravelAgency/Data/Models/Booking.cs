using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Data.Models
{
    public class Booking
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;
        [Required]
        public int TourPackageId { get; set; }
        [Required]
        [ForeignKey(nameof(TourPackageId))]
        public TourPackage TourPackage { get; set; } = null!;
    }
}
