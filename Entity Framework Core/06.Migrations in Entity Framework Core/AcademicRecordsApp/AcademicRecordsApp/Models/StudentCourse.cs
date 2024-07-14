using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicRecordsApp.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
