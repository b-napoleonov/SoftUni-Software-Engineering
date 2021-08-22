using System;
using System.Text;

namespace _01._ActivaK
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] commands = input.Split(">>>");
                string command = commands[0];

                switch (command)
                {
                    case "Contains":

                        string substring = commands[1];

                        if (rawKey.Contains(substring))
                        {
                            Console.WriteLine($"{rawKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }

                        break;

                    case "Flip":

                        string upperLower = commands[1];
                        int startIndex = int.Parse(commands[2]);
                        int endIndex = int.Parse(commands[3]);

                        if (upperLower == "Upper")
                        {
                            StringBuilder current = new StringBuilder();

                            for (int i = startIndex; i < endIndex; i++)
                            {
                                current.Append(rawKey[i]);
                            }

                            rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
                            rawKey = rawKey.Insert(startIndex, current.ToString().ToUpper());

                            Console.WriteLine(rawKey);
                        }
                        else
                        {
                            StringBuilder current = new StringBuilder();

                            for (int i = startIndex; i < endIndex; i++)
                            {
                                current.Append(rawKey[i]);
                            }

                            rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
                            rawKey = rawKey.Insert(startIndex, current.ToString().ToLower());

                            Console.WriteLine(rawKey);
                        }

                        break;

                    case "Slice":

                        int startI = int.Parse(commands[1]);
                        int endI = int.Parse(commands[2]);

                        rawKey = rawKey.Remove(startI, endI - startI);

                        Console.WriteLine(rawKey);

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
