using System;
using System.Text;

namespace _01._WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] commands = input.Split(':');
                string command = commands[0];

                switch (command)
                {
                    case "Add Stop":

                        int index = int.Parse(commands[1]);
                        string text = commands[2];

                        if (index >= 0 && index < sb.Length)
                        {
                            sb.Insert(index, text);
                        }

                        Console.WriteLine(sb);

                        break;

                    case "Remove Stop":

                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);

                        if (startIndex >= 0
                            && startIndex < sb.Length
                            && endIndex >= 0
                            && endIndex < sb.Length)
                        {
                            sb.Remove(startIndex, endIndex + 1 - startIndex);
                        }

                        Console.WriteLine(sb);

                        break;

                    case "Switch":

                        string oldString = commands[1];
                        string newString = commands[2];
                         
                        sb.Replace(oldString, newString);

                        Console.WriteLine(sb);

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {sb}");
        }
    }
}
