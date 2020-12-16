namespace StudentCourses
{
    public class Student
    {
        public Student()
        {
        }

        [ColoredProperty(System.ConsoleColor.DarkYellow)]
        public string Name { get; set; }

        [ColoredProperty(System.ConsoleColor.Gray)]
        public string Course { get; set; }

        [ColoredProperty(System.ConsoleColor.Blue)]
        public int Mark { get; set; }

        [ColoredProperty(System.ConsoleColor.Magenta)]
        public string Type { get; set; }

        public static System.Collections.Generic.IList<Student> GetStudentsFromXml(System.Xml.Linq.XDocument document)
        {
            System.Collections.Generic.List<Student> studentList = new System.Collections.Generic.List<Student>();
            foreach (System.Xml.Linq.XElement item in document.Descendants("student"))
            {
                studentList.Add(new Student
                {
                    Name = item.Element("name").Value,
                    Course = item.Element("course").Value,
                    Mark = int.Parse(item.Element("mark").Value),
                    Type = item.Element("type").Value
                });
            }
            return studentList;
        }

        public override string ToString()
        {
            return $"{this.Name} | {this.Course} | {this.Mark} | {this.Type}";
        }
    }
}
