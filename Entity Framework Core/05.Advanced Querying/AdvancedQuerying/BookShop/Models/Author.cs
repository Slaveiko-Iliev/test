using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Author
    {
        public Author()
        {
            Authors = new HashSet<Author>();
        }

        [Key]
        public int AuthorId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        public ICollection<Author> Authors { get; set; }
    }
}
