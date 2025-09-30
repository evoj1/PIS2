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
                var basicLessons = lessons.OfType<Lesson>();
                var onlineLessons = lessons.OfType<Lesson>();
                var courseLessons = lessons.OfType<Lesson>();

                Console.WriteLine("BASIC LESSONS");

                foreach ( var lesson in basicLessons)
                {
                    Console.WriteLine($"{lesson}\n");
                }

                Console.WriteLine("ONLINE LESSONS");

                foreach ( var lesson in onlineLessons)
                {
                    Console.WriteLine($"{lesson}\n");
                }

                Console.WriteLine("COURSE LESSONS");

                foreach ( var lesson in courseLessons)
                {
                    Console.WriteLine($"{lesson}\n");
                }
            }
            else if (result == null)
            {
                Console.WriteLine("");
            }
        }
    }
}
