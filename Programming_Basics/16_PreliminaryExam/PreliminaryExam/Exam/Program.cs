using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            double sum = 0;
            int excellentCounter = 0;
            int goodCounter = 0;
            int averageCounter = 0;
            int badCounter = 0;

            for (int i = 1; i <= numberOfStudents; i++)
            {
                double examGrade = double.Parse(Console.ReadLine());
                sum += examGrade;
                if (examGrade >= 5)
                {
                    excellentCounter++;
                }
                else if (examGrade >= 4 && examGrade <= 4.99)
                {
                    goodCounter++;
                }
                else if (examGrade >= 3 && examGrade <= 3.99)
                {
                    averageCounter++;
                }
                else if (examGrade < 3)
                {
                    badCounter++;
                }
            }
            Console.WriteLine($"Top students: {(double)excellentCounter / numberOfStudents * 100:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(double)goodCounter / numberOfStudents * 100:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(double)averageCounter / numberOfStudents * 100:F2}%");
            Console.WriteLine($"Fail: {(double)badCounter / numberOfStudents * 100:F2}%");
            Console.WriteLine($"Average: {sum / numberOfStudents:F2}");
        }
    }
}
