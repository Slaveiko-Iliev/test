namespace AcademicRecordsApp.Models
{
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
            //CourseStudents = new HashSet<CourseStudent>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Student> Students { get; set; }
        public ICollection<StudentCourse> CourseStudents { get; set; }
    }
}
