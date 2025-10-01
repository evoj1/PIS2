using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public class OnlineLesson
    {
        public DateTime DateTime { get; set; }
        public string Platform { get; set; }
        public string TeacherName { get; set; }
        public string MeetingLink { get; set; }
        public string NameOfLesson { get; set; }
        public OnlineLesson(DateTime dateTime, string platform, string teacherName, string meetingLink, string nameOfLesson)
        {
            DateTime = dateTime;
            Platform = platform;
            TeacherName = teacherName;
            MeetingLink = meetingLink;
            NameOfLesson = nameOfLesson;
        }
        public override string ToString()
        {
            return $"Дата: {DateTime}\n" +
                $"Платформа: {Platform}\n" +
                $"Имя преподавателя: {TeacherName}\n" +
                $"Ссылка: {MeetingLink}\n" +
                $"Название урока: {NameOfLesson}\n";
        }
    }
}
