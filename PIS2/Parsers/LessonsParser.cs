using PIS2.Models;
using PIS2.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using static PIS2.Utilities.Utilities;

namespace PIS2.Parsers
{
    public class LessonParser
    {
        public int CountNumbers(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("1");

            var parts = input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            foreach (var part in parts)
            {
                var trimmed = part.TrimStart('0');
                if (trimmed.Length == 0)
                    continue;

                count++;
            }

            return count;
        }
        public int Foo(string[] text)
        {
            int countStrings = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Length % 2 == 0)
                {
                    countStrings++;
                }
            }
            return countStrings;
        }
        public List<LessonBase> ParseLessons(string filePath)
        {
            var lessons = new List<LessonBase>();
            string[] lines;

            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось открыть файл: {ex.Message}");
            }

            int lineNumber = 0;
            foreach (var line in lines)
            {
                lineNumber++;
                if (string.IsNullOrWhiteSpace(line)) continue;

                try
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    var lesson = ParseLine(line);
                    lessons.Add(lesson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка парсинга строки {lineNumber}: {line}\nПричина: {ex.Message}\n");
                }
            }

            return lessons;
        }

        public LessonBase ParseLine(string line)
        {
            try
            {
                var parts = StringUtils.SplitWordsKeepQuotes(line);

                if (parts.Length == 3)
                    return ParseLesson(parts);

                if (parts.Length >= 4 && (parts[3].StartsWith("http") || parts[3].StartsWith("www")))
                    return ParseOnlineLesson(parts);

                if (parts.Length == 4 && TimeSpan.TryParse(parts[3], out _))
                    return ParseCourseLesson(parts);

                throw new FormatException("Строка не соответствует ни одному формату занятия");
            }
            catch (Exception ex)
            {
                throw new FormatException($"Ошибка при парсинге строки: [{line}]\nПричина: {ex.Message}\n", ex);
            }
        }

        private Lesson ParseLesson(string[] parts)
        {
            if (!DateTime.TryParse(parts[0], out var date))
                throw new Exception("Некорректная дата для обычного урока");
            return new Lesson(date, parts[1], parts[2]);
        }

        private OnlineLesson ParseOnlineLesson(string[] parts)
        {
            if (!DateTime.TryParse(parts[0], out var date))
                throw new Exception("Некорректная дата для онлайн урока");

            var platform = parts[1];
            var teacher = parts[2];
            var meeting = parts[3];
            int count = (parts.Length > 4 && int.TryParse(parts[4], out var cnt)) ? cnt : 0;
            var name = parts.Length > 5 ? parts[5] : "";
            var part = parts.Length > 6 ? parts[6] : "";
            return new OnlineLesson(date, platform, teacher, meeting, count, name, part);
        }

        private CourseLesson ParseCourseLesson(string[] parts)
        {
            if (!DateTime.TryParse(parts[0], out var date))
                throw new Exception("Некорректная дата для курса");
            if (!TimeSpan.TryParse(parts[3], out var duration))
                throw new Exception("Некорректная продолжительность для курса");

            return new CourseLesson(date, parts[1], parts[2], duration);
        }
    }
}
