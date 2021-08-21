using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int lame = int.Parse(Console.ReadLine());
            string problems = Console.ReadLine();
            int counter = 0;
            double sum = 0;
            int problemsCounter = 0;
            string problemName = problems;

            
            while (problems != "Enough")
            {
                problemName = problems;
                int grade = int.Parse(Console.ReadLine());
                sum += grade;
                problemsCounter++;
                if (grade <= 4)
                {
                    counter++;
                    if (counter >= lame)
                    {
                        Console.WriteLine($"You need a break, {counter} poor grades.");
                        break;
                    }
                }
                problems = Console.ReadLine();
            }
            if (counter < lame)
            {
                Console.WriteLine($"Average score: {sum / problemsCounter:F2}");
                Console.WriteLine($"Number of problems: {problemsCounter}");
                Console.WriteLine($"Last problem: {problemName}");
            }
        }
    }
}
