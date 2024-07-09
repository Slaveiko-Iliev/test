using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Category
    {
        public Category()
        {
            CategoryBooks = new HashSet<BookCategory>();
        }

        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = null!;

        ICollection<BookCategory> CategoryBooks { get; set; } = null!;
    }
}
