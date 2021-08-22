using System;
using System.Text;
using System.Threading;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Finish")
            {
                string[] commands = input.Split();
                string command = commands[0];

                switch (command)
                {
                    case "Replace":

                        string currentChar = commands[1];
                        string newChar = commands[2];

                        text = text.Replace(currentChar, newChar);

                        Console.WriteLine(text);

                        break;

                    case "Cut":

                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);

                        if (startIndex >= 0 && endIndex < text.Length)
                        {
                            text = text.Remove(startIndex, (endIndex - startIndex) + 1);

                            Console.WriteLine(text);
                        }
                        else
                        {
                            Console.WriteLine("Invalid indices!");
                        }

                        break;

                    case "Make":

                        string upperLower = commands[1];

                        if (upperLower == "Upper")
                        {
                            text = text.ToUpper();
                            Console.WriteLine(text);
                        }
                        else
                        {
                            text = text.ToLower();
                            Console.WriteLine(text);
                        }

                        break;

                    case "Check":

                        string current = commands[1];

                        if (text.Contains(current))
                        {
                            Console.WriteLine($"Message contains {current}");
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {current}");
                        }

                        break;

                    case "Sum":

                        int startInd = int.Parse(commands[1]);
                        int endInd = int.Parse(commands[2]);

                        if (startInd >= 0 && endInd < text.Length - 1)
                        {
                            int sum = 0;

                            for (int i = startInd; i <= endInd; i++)
                            {
                                sum += text[i];
                            }

                            Console.WriteLine(sum);
                        }
                        else
                        {
                            Console.WriteLine("Invalid indices!");
                        }

                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
