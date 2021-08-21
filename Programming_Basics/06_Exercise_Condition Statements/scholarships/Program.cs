using System;

namespace scholarships
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double successRate = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(minSalary * 0.35);
            double excelentScholarship = Math.Floor(successRate * 25);

            if (successRate >= 5.50)
            {
                if (income < minSalary && socialScholarship > excelentScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
                else if (income < minSalary && socialScholarship == excelentScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {excelentScholarship} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {excelentScholarship} BGN");
                }
            }
            if (income < minSalary && successRate >= 4.50)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
