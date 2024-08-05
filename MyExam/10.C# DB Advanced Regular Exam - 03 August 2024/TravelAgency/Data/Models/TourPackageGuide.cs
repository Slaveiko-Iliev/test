using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Data.Models
{
    public class TourPackageGuide
    {
        [Required]
        public int TourPackageId { get; set; }
        [Required]
        [ForeignKey(nameof(TourPackageId))]
        public TourPackage TourPackage { get; set; } = null!;
        [Required]
        public int GuideId { get; set; }
        [Required]
        [ForeignKey(nameof(GuideId))]
        public Guide Guide { get; set; } = null!;
    }
}
