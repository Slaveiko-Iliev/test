using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Content { get; set; }


        public enum ContentType
        {
            Application, Pdf, Zip
        }

        [Required]
        public DateTime SubmissionTime { get; set; }

        [Required]
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}


//o HomeworkId
//o	Content – string, linking to a file, not unicode
//o	ContentType - enum, can be Application, Pdf or Zip
//o	SubmissionTime
//o	StudentId
//o	CourseId
