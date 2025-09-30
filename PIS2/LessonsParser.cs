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
                List<object> lessons = new List<object>();

                foreach (string line in lines)
                {
                    var parts = new List<string>();
                    int i = 0;

                    while (i < line.Length)
                    {
                        if (line[i] == '"')
                        {
                            int endQuote = line.IndexOf('"', i + 1);
                            if (endQuote != -1)
                            {
                                parts.Add(line.Substring(i + 1, endQuote - i - 1));
                                i = endQuote + 1;
                            }
                            else
                            {
                                i++;
                            }
                        }
                        else if (!char.IsWhiteSpace(line[i]))
                        {
                            int end = i;
                            while (end < line.Length && !char.IsWhiteSpace(line[end]))
                            {
                                end++;
                            }
                            parts.Add(line.Substring(i, end - i));
                            i = end;
                        }
                        else
                        {
                            i++;
                        }
                    }

                    if (parts.Count == 3)
                    {
                        lessons.Add(ParseBasicLesson(parts.ToArray()));
                    }
                    else if (parts.Count >= 4)
                    {
                        if (parts[3].Contains("http") || parts[3].Contains("www"))
                        {
                            lessons.Add(ParseOnlineLesson(parts.ToArray()));
                        }
                        else if (parts[3].Contains(":"))
                        {
                            lessons.Add(ParseCourseLesson(parts.ToArray()));
                        }
                    }
                }
                return lessons;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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

            return new OnlineLesson(dateTime, platform, teacherName, meetingLink);
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
