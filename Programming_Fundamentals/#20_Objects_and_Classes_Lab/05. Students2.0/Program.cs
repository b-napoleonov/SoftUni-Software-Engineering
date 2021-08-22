using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students2._0
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string firstName = input.Split(' ')[0];
                string lastName = input.Split(' ')[1];
                int age = int.Parse(input.Split(' ')[2]);
                string city = input.Split(' ')[3];

                Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName); // Нова инстанция на класа Student

                if (student == null)
                {
                    students.Add(new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city
                    });
                }
                else
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;
                }

                input = Console.ReadLine();
            }

            string filterCity = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.City == filterCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }

            }
        }
    }
}
