using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {
                string[] data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];
                Animal current;

                if (age > 0)
                {
                    switch (animalType)
                    {
                        case "Dog":

                            current = new Dog(name, age, gender);

                            break;

                        case "Cat":

                            current = new Cat(name, age, gender);

                            break;

                        case "Frog":

                            current = new Frog(name, age, gender);

                            break;

                        case "Tomcat":

                            current = new Tomcat(name, age);

                            break;

                        case "Kitten":

                            current = new Kitten(name, age);

                            break;

                        default:

                            Console.WriteLine($"Invalid input!");
                            animalType = Console.ReadLine();
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                    animalType = Console.ReadLine();
                    continue;
                }

                animals.Add(current);
                animalType = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }
    }
}
