using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string FullName { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(13)]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public ICollection<Booking> Bookings { get; set; }
    }
}

//•	Bookings - a collection of type Booking
