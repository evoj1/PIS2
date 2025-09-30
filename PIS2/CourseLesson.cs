using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public class CourseLesson
    {
        public DateTime DateTime { get; set; }
        public string WebSyte { get; set; }
        public string TeacherName { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public CourseLesson(DateTime dateTime, string webSyte, string teacherName, TimeSpan timeSpan)
        {
            DateTime = dateTime;
            WebSyte = webSyte;
            TeacherName = teacherName;
            TimeSpan = timeSpan;
        }
        public override string ToString()
        {
            return $"Дата: {DateTime}\n" +
                $"Сайт: {WebSyte}\n" +
                $"Имя преподавателя: {TeacherName}\n" +
                $"Продолжительность: {TimeSpan}";
        }
    }
}
