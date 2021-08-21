using System;

namespace GraduationPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int counter = 0;
            double average = 0;

            for (int i = 0; i < 12; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                counter++;
                average += grade;
                if (grade < 4)
                {
                    Console.WriteLine($"{studentName} has been excluded at {counter} grade");
                    return;
                }
            }
            Console.WriteLine($"{studentName} graduated. Average grade: {average / 12:F2}");
        }
    }
}
