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
            string input = "2025.09.09  \"23-03\"  \"Губерниев Иван\"";
            Console.WriteLine(ParseString(input));
        }

        static Lesson ParseString(string input)
        {
            string[] array = input.Split(new char[] { ' ', '"' }, StringSplitOptions.RemoveEmptyEntries);
            string date = array[0];
            string cabinet = array[1];
            string teacherName = ParseName(input);

            DateTime dateTime = DateTime.ParseExact(date, "yyyy.MM.dd", null);

            return new Lesson(dateTime, cabinet, teacherName);
        }

        static string ParseName(string input)
        {
            int quoteCount = 0;
            StringBuilder nameBuilder = new StringBuilder();

            foreach (char c in input)
            {
                if (c == '"')
                {
                    quoteCount++;
                    continue;
                }

                if (quoteCount == 3)
                {
                    nameBuilder.Append(c);
                }
                else if (quoteCount > 3)
                {
                    break;
                }
            }
            return nameBuilder.ToString();
        }
    }
}
