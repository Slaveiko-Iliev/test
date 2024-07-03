using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Url { get; set; }

        public enum ResourceType
        {
            Video, Presentation, Document, Other
        }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }


    }
}

