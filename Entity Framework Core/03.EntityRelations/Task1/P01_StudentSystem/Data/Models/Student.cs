using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

public class Student
{
    public Student()
    {
        Homeworks = new HashSet<Homework>();
        StudentsCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int StudentId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "char(10)")]
    public string PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime Birthday { get; }

    public virtual ICollection<Homework> Homeworks { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
}
