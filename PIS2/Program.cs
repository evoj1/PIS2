using System;
using System.Linq;
using PIS2.Parsers;
using PIS2.Models;

namespace PIS2
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    string filePath = "lessons.txt";
            //    var parser = new LessonParser();
            //    var lessons = parser.ParseLessons(filePath);

            //    PrintGroup("Обычные занятия", lessons.OfType<Lesson>());
            //    PrintGroup("Оналйн занятия", lessons.OfType<OnlineLesson>());
            //    PrintGroup("Курсы", lessons.OfType<CourseLesson>());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Ошибка: {ex.Message}");
            //}
            
        }

        private static void PrintGroup<T>(string title, System.Collections.Generic.IEnumerable<T> lessons)
        {
            if (!lessons.Any()) return;
            Console.WriteLine($"\n--- {title} ---\n");
            foreach (var lesson in lessons)
            {
                Console.WriteLine(lesson);
                Console.WriteLine();
            }
        }
    }
}
