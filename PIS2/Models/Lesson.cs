using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PIS2.Models
{
    public abstract class LessonBase
    {
        public DateTime Date { get; }
        public string Teacher { get; }
        protected LessonBase(DateTime date, string teacher)
        {
            Date = date;
            Teacher = teacher;
        }
        public abstract override string ToString();
    }
    
    public class Lesson : LessonBase
    {
        public string Cabinet { get; }
        public Lesson(DateTime date, string cabinet, string teacher) 
            : base(date, teacher)
        {
            Cabinet = cabinet;
        }
        public override string ToString()
        {
            return $"Дата: {Date:yyyy.MM.dd}\nКабинет: {Cabinet}\nПреподаватель: {Teacher}\n";
        }
    }
    public class OnlineLesson : LessonBase
    {
        public string Platform { get; }
        public string MeetingLink { get; }
        public int LessonCount { get; }
        public string LessonName { get; }
        public string LessonPart { get; }
        public OnlineLesson(DateTime date, string platform, string teacher, string meetingLink, int lessonCount, string lessonName, string lessonPart)
            : base(date, teacher)
        {
            Platform = platform;
            MeetingLink = meetingLink;
            LessonCount = lessonCount;
            LessonName = lessonName;
            LessonPart = lessonPart;
        }
        public override string ToString()
        {
            return $"Дата: {Date:yyyy.MM.dd}\nПлатформа: {Platform}\nПреподаватель: {Teacher}\nСсылка: {MeetingLink}\nКоличество занятий: {LessonCount}\nНазвание занятия: {LessonName}\nЧасть: {LessonPart}\n";
        }
    }
    public class CourseLesson : LessonBase
    {
        public string Platform { get; }
        public TimeSpan Duration { get; }
        public CourseLesson(DateTime date, string platform, string teacher, TimeSpan duration)
            : base(date, teacher)
        {
            Platform = platform;
            Duration = duration;
        }
        public override string ToString()
        {
            return $"Дата: {Date:yyyy.MM.dd}\nПлатформа:{Platform}\nПреподаватель: {Teacher}\nПродолжительность: {Duration}\n";
        }
    }
}
