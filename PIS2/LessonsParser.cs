using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace PIS2
{
    public class LessonsParser
    {
        public object ParseLessons()
        {
            string filePath = @"C:\Users\evoj1\source\repos\PIS2\PIS2\lessons.txt";

            if (!File.Exists(filePath))
            {
                return "Файл не найден";
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return AddLessonsInList(lines);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private List<object> AddLessonsInList(string[] lines)
        {
            List<object> lessons = new List<object>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var lesson = ParseLineInFile(line);
                if (lesson != null)
                {
                    lessons.Add(lesson);
                }
            }

            return lessons;
        }
        private object ParseLineInFile(string line)
        {
            string[] parts = ParseLineInPartsRemoveQuotes(line);
            return CreateLessonFromParts(parts);
        }
        private static string[] ParseLineInPartsRemoveQuotes(string line)
        {
            var parts = new List<string>();
            var current = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    inQuotes = !inQuotes;
                    continue;
                }

                if (char.IsWhiteSpace(c) && !inQuotes)
                {
                    if (current.Length > 0)
                    {
                        parts.Add(current.ToString());
                        current.Clear();
                    }
                }
                else
                {
                    current.Append(c);
                }
            }

            if (current.Length > 0)
            {
                parts.Add(current.ToString());
            }

            return parts.ToArray();
        }
        private object CreateLessonFromParts(string[] parts)
        {
            if (parts.Length == 3)
            {
                return ParseBasicLesson(parts);
            }

            if (parts.Length >= 4)
            {
                string fourth = parts[3];
                if (fourth.Contains("http") || fourth.Contains("www"))
                {
                    return ParseOnlineLesson(parts);
                }
                if (fourth.Contains(":"))
                {
                    return ParseCourseLesson(parts);
                }
            }

            return null;
        }
        private Lesson ParseBasicLesson(string[] parts)
        {
            DateTime dateTime = DateTime.Parse(parts[0]);
            string cabinet = parts[1];
            string teacherName = parts[2];

            return new Lesson(dateTime, cabinet, teacherName);
        }
        private OnlineLesson ParseOnlineLesson(string[] parts)
        {
            DateTime dateTime = DateTime.Parse(parts[0]);
            string platform = parts[1];
            string teacherName = parts[2];
            string meetingLink = parts[3];
            int countLessons = parts.Length > 4 ? int.Parse(parts[4]) : 0;
            string nameOfLesson = parts.Length > 5 ? parts[5] : string.Empty;

            return new OnlineLesson(dateTime, platform, teacherName, meetingLink, countLessons, nameOfLesson);
        }
        private CourseLesson ParseCourseLesson(string[] parts)
        {
            DateTime dateTime = DateTime.Parse(parts[0]);
            string webSyte = parts[1];
            string teacherName = parts[2];
            TimeSpan timeSpan = TimeSpan.Parse(parts[3]);

            return new CourseLesson(dateTime, webSyte, teacherName, timeSpan);
        }
    }
}
