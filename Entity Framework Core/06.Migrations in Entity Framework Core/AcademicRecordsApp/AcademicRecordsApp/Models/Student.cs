namespace AcademicRecordsApp.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            Courses = new HashSet<Course>();
            //StudentCourses = new HashSet<CourseStudent>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
