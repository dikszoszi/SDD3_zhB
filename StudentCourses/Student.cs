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

        public static System.Collections.Generic.IEnumerable<Student> GetStudentsFromXml(System.Xml.Linq.XDocument document)
        {
            if (document is null) throw new System.ArgumentNullException(nameof(document));
            foreach (System.Xml.Linq.XElement item in document.Descendants("student"))
            {
                yield return new Student
                {
                    Name = item.Element("name").Value,
                    Course = item.Element("course").Value,
                    Mark = int.Parse(item.Element("mark").Value, System.Globalization.NumberFormatInfo.InvariantInfo),
                    Type = item.Element("type").Value
                };
            }
        }

        public override string ToString()
        {
            return $"{this.Name} | {this.Course} | {this.Mark} | {this.Type}";
        }
    }
}
