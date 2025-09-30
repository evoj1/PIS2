using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS2
{
    public class Lesson
    {
        public DateTime DateTime { get; set; }
        public string Cabinet { get; set; }
        public string TeacherName { get; set; }

        public Lesson(DateTime dateTime, string cabinet, string teacherName)
        {
            DateTime = dateTime;
            Cabinet = cabinet;
            TeacherName = teacherName;
        }
        public override string ToString()
        {
            return $"Дата: {DateTime:yyyy.MM.dd}\n" +
                $"Кабинет: {Cabinet}\n" +
                $"Имя преподавтаеля: {TeacherName}";
        }
    }
}
