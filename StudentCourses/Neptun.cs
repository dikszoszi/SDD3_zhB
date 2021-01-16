using System.Linq;

namespace StudentCourses
{
    public class Neptun
    {
        public System.Collections.Generic.IEnumerable<Student> Students { get; private set; }
        public Microsoft.EntityFrameworkCore.DbContext Context { get; private set; }

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
            var q = from student in this.Students
                    group student by student.Course into grp
                    select new { Course = grp.Key, Average = grp.Average(stud => stud.Mark) };
            q.DisplayResult();
        }

        public void CourseAverageWithLongtName()
        {
            var q = from course in this.Context.Set<Tables.Course>().AsEnumerable()
                    join student in this.Students on course.CourseShortName equals student.Course
                    let compound = new { student, course }
                    group compound by compound.course.CourseLongName into grp
                    select new { Course = grp.Key, Average = grp.Average(compound => compound.student.Mark) };
            q.DisplayResult();
        }

        public void NamesAndCourseLongNames()
        {
            /*
            this.Context.Set<Tables.Course>().AsEnumerable()
                 .Join(this.Students, crs => crs.CourseShortName, stud => stud.Course, (course, student) => new { course, student })
                 .GroupBy(join => join.student.Name)
                 .SelectMany(collectionSelector: grp => grp,
                             resultSelector: (group, jointype) => new { StudentName = group.Key, jointype.course.CourseLongName })
                 .DisplayResult();
            */
            var q = from course in this.Context.Set<Tables.Course>().AsEnumerable()
                    join student in this.Students on course.CourseShortName equals student.Course
                    let compound = new { student, course }
                    group compound by compound.student.Name into grp
                    from compound in grp
                    select new { StudentName = grp.Key, compound.course.CourseLongName };
            q.DisplayResult();
        }
    }
}
