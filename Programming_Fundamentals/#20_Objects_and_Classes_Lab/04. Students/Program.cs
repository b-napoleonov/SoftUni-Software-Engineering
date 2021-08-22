using System;
using System.Collections.Generic;

namespace _04._Students
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

                Student student = new Student();            // Нова инстанция на класа Student
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;
                }

                students.Add(student);

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
