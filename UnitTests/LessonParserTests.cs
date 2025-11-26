using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PIS2.Models;
using PIS2.Parsers;

namespace UnitTests
{
    [TestClass]
    public sealed class LessonParserTests
    {
        [TestMethod]
        public void ParseLesson_ValidData_ReturnsLesson()
        {
            var parser = new LessonParser();
            var input = "2025.09.09 \"23-03\" \"Иван А. А.\"";
            var lesson = parser.ParseLine(input) as Lesson;

            Assert.IsNotNull(lesson);
            Assert.AreEqual("23-03", lesson.Cabinet);
            Assert.AreEqual("Иван А. А.", lesson.Teacher);
            Assert.AreEqual(new DateTime(2025, 9, 9), lesson.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseLesson_InvalidDate_ThrowsException()
        {
            var parser = new LessonParser();
            var input = "ошибка \"23-03\" \"Иван А. А.\"";
            parser.ParseLine(input);
        }
        [TestMethod]
        public void ParseOnlineLesson_ValidData_ReturnsOnlineLesson()
        {
            var parser = new LessonParser();
            var input = "2025.09.11 \"Zoom\" \"Сидоров Алексей Петров\" \"https://meet.com/abc123\" 23 \"Математика\" \"1 часть\"";
            var lesson = parser.ParseLine(input) as OnlineLesson;

            Assert.IsNotNull(lesson);
            Assert.AreEqual("Zoom", lesson.Platform);
            Assert.AreEqual("Сидоров Алексей Петров", lesson.Teacher);
            Assert.AreEqual("https://meet.com/abc123", lesson.MeetingLink);
            Assert.AreEqual(23, lesson.LessonCount);
            Assert.AreEqual("Математика", lesson.LessonName);
            Assert.AreEqual("1 часть", lesson.LessonPart);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseCourseLesson_InvalidDuration_ThrowsFormatException()
        {
            var parser = new LessonParser();
            var input = "2025.09.12 \"https://meet.com\" \"Кузнецова Анна\" \"not_a_time\"";
            parser.ParseLine(input);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseLesson_EmptyTeacher_ThrowsFormatException()
        {
            var parser = new LessonParser();
            var input = "2025.09.09 \"23-03\" \"\"";
            parser.ParseLine(input);
        }

        [TestMethod]
        public void CountStrings()
        {
            var parser = new LessonParser();
            string[] input = { "hello", "world" };
            int goodResult = 0;
            int realResult = parser.Foo(input);
            Assert.AreEqual(goodResult, realResult);
        }
    }
}