namespace StudentCourses
{
    using System;
    [AttributeUsage(AttributeTargets.Property)]
    internal class ColoredPropertyAttribute : Attribute
    {
        public ColoredPropertyAttribute(ConsoleColor consleColor)
        {
            this.ConsoleColor = consleColor;
        }

        public ConsoleColor ConsoleColor { get; }
    }
}