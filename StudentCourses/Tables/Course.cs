#nullable disable

namespace StudentCourses.Tables
{
    public partial class Course
    {
        public Course()
        {
        }

        public decimal CourseId { get; set; }
        public string CourseShortName { get; set; }
        public string CourseLongName { get; set; }
        public int Credit { get; set; }

        public override string ToString()
        {
            return $"#{this.CourseId} {this.CourseShortName} | {this.CourseLongName} | {this.Credit}";
        }
    }
}
