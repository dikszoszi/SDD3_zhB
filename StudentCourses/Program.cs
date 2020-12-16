namespace StudentCourses
{
    /* Tools - NuGet Package Manager - Package Manager Console => paste and run:
     * Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Resources\CourseDb.mdf;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Tables
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Neptun neptun = new Neptun(Student.GetStudentsFromXml(
                System.Xml.Linq.XDocument.Load(@"Resources\students.xml")),
                new Tables.CourseDbContext());
            neptun.ListOSstudents();
            neptun.ListOSstudentNames();
            neptun.CourseAverageWithShortName();
            neptun.CourseAverageWithLongtName();
            neptun.NamesAndCourseLongNames();
        }
    }
}
