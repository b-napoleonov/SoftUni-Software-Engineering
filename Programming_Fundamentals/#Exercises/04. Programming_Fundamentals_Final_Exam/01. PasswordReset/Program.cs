using System;
using System.Text;

namespace _01._PasswordRe
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawPass = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] commands = input.Split();

                string command = commands[0];

                switch (command)
                {
                    case "TakeOdd":

                        StringBuilder sb = new StringBuilder();

                        for (int i = 1; i < rawPass.Length; i += 2)
                        {
                            sb.Append(rawPass[i]);
                        }

                        rawPass = sb.ToString();

                        Console.WriteLine(rawPass);

                        break;

                    case "Cut":

                        int index = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);

                        rawPass = rawPass.Remove(index, length);

                        Console.WriteLine(rawPass);

                        break;

                    case "Substitute":

                        string substring = commands[1];
                        string substitute = commands[2];

                        if (rawPass.Contains(substring))
                        {
                            rawPass = rawPass.Replace(substring, substitute);

                            Console.WriteLine(rawPass);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {rawPass}");
        }
    }
}
