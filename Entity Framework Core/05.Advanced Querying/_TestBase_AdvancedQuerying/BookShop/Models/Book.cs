using BookShop.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Book
    {
        public Book()
        {
            BookCategories = new HashSet<BookCategory>();
        }

        [Key]
        public int BookId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Title { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int Copies { get; set; }

        public decimal Price { get; set; }

        public EditionType EditionType { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = null!; //check

        public ICollection<BookCategory> BookCategories { get; set; } = null!;
    }
}
