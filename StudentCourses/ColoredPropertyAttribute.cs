namespace StudentCourses
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class ColoredPropertyAttribute : Attribute
    {
        public ColoredPropertyAttribute(ConsoleColor consoleColor)
        {
            this.ConsoleColor = consoleColor;
        }
        public ConsoleColor ConsoleColor { get; private set; }
    }
}
