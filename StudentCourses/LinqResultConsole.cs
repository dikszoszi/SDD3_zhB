using System.Linq;
using System.Reflection;

namespace StudentCourses
{
    public static class LinqResultConsole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "English only")]
        public static void DisplayResult<T>(this System.Collections.Generic.IEnumerable<T> result)
        {
            if (result is null) throw new System.ArgumentNullException(nameof(result));

            if (typeof(T) != typeof(int) && typeof(T) != typeof(string))
            {
                PropertyInfo[] propInfos = typeof(T).GetProperties();
                System.Console.WriteLine();
                foreach (PropertyInfo propInfo in propInfos)
                {
                    System.Console.Write(propInfo.Name + "\t");
                }
                System.Console.WriteLine();
            }

            foreach (T item in result)
            {
                var coloredProps = typeof(T).GetProperties()
                    .Where(prop => prop.GetCustomAttributes(typeof(ColoredPropertyAttribute), false).Length > 0)
                    .ToList();
                if (coloredProps is not null && coloredProps.Any())
                {
                    coloredProps.ForEach(cp =>
                    {
                        System.Console.ForegroundColor = cp.GetCustomAttribute<ColoredPropertyAttribute>().ConsoleColor;
                        System.Console.Write($"{cp.Name}:  {cp.GetValue(item)}\t");
                        System.Console.ResetColor();
                    });
                }
                else
                {
                    System.Console.Write(item.ToString());
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("** Press Enter. **");
            System.Console.ReadLine();
        }
    }
}
