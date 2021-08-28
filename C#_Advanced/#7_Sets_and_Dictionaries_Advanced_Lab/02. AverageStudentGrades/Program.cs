using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _02._AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> averageGrade = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (averageGrade.ContainsKey(name) == false)
                {
                    averageGrade.Add(name, new List<decimal>());
                }

                averageGrade[name].Add(grade);
            }

            foreach (var (key,value) in averageGrade)
            {
                Console.WriteLine($"{key} -> {string.Join(' ', value.Select(v => $"{v:F2}"))} (avg: {value.Average():F2})");
            }
        }
    }
}
