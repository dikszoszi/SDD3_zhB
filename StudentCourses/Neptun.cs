using System.Linq;

namespace StudentCourses
{
    public class Neptun
    {
        public System.Collections.Generic.IEnumerable<Student> Students { get; set; }
        public Microsoft.EntityFrameworkCore.DbContext Context { get; set; }

        public Neptun()
        {
        }

        public Neptun(System.Collections.Generic.IEnumerable<Student> students, Microsoft.EntityFrameworkCore.DbContext ctx)
        {
            this.Students = students;
            this.Context = ctx;
        }

        public void ListOSstudents()
        {
            this.Students.DisplayResult();
        }
        public void ListOSstudentNames()
        {
            this.Students.Select(student => student.Name).DisplayResult();
        }
        public void CourseAverageWithShortName()
        {
            this.Students.GroupBy(stud => stud.Course)
                .Select(grp => new { Course = grp.Key, Average = grp.Average(stud => stud.Mark) })
                .DisplayResult();
        }

        public void CourseAverageWithLongtName()
        {
            this.Context.Set<Tables.Course>().AsEnumerable()
                .Join(this.Students, crs => crs.CourseShortName, stud => stud.Course, (course, student) => new { course, student })
                .GroupBy(join => join.course.CourseLongName)
                .Select(grp => new { Course = grp.Key, Average = grp.Average(join => join.student.Mark) })
                .DisplayResult();
        }

        public void NamesAndCourseLongNames()
        {
            this.Context.Set<Tables.Course>().AsEnumerable()
                 .Join(this.Students, crs => crs.CourseShortName, stud => stud.Course, (course, student) => new { course, student })
                 .GroupBy(join => join.student.Name)
                 .SelectMany(grp => grp, (group, jointype) => new { StudentName = group.Key, jointype.course.CourseLongName })
                 .DisplayResult();
        }
    }
}
