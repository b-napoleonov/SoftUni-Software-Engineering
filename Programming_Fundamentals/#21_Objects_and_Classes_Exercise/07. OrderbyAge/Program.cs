using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._OrderbyAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> persons = new List<Person>();

            while (input != "End")
            {
                string[] person = input.Split(' ');

                string name = person[0];
                string id = person[1];
                int age = int.Parse(person[2]);

                persons.Add(new Person(name, id, age));

                input = Console.ReadLine();
            }

            foreach (var person in persons.OrderBy(x => x.Age))
            {
                Console.WriteLine(person);
            }
        }
    }

    public class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
