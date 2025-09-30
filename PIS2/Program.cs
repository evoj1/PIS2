using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LessonsParser parser = new LessonsParser();
            var result = parser.ParseLessons();

            if (result is List<object> lessons)
            {
                var regularLessons = lessons.OfType<Lesson>();
                var onlineLessons = lessons.OfType<OnlineLesson>();
                var courseLessons = lessons.OfType<CourseLesson>();

                PrintGroup("LESSONS", regularLessons);
                PrintGroup("ONLINE LESSONS", onlineLessons);
                PrintGroup("COURSE LESSONS", courseLessons);
            }
        }

        private static void PrintGroup<T>(string title, IEnumerable<T> items)
        {
            if (!items.Any()) return;
            Console.WriteLine(title);
            Console.WriteLine();
            foreach (var item in items)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
    }
}
