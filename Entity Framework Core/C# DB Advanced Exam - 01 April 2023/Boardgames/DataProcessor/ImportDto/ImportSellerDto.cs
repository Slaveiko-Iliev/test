using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;
        [RegularExpression(@"(www\.[a-zA-Z0-9\-]{2,256}\.com)")]
        [Required]
        public string Website { get; set; } = null!;
        public int[] Boardgames { get; set; }
    }
}

//@"^(www\.)[a-zA-Z0-9-]*(\.com)$"