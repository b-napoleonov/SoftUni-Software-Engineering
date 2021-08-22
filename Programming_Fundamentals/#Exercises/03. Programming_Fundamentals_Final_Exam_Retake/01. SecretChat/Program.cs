using System;
using System.Text;
using System.Linq;

namespace _01._SecretCh
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder crypted = new StringBuilder(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] commands = input.Split(":|:");
                string command = commands[0];

                switch (command)
                {
                    case "InsertSpace":

                        int index = int.Parse(commands[1]);

                        crypted.Insert(index, " ");

                        Console.WriteLine(crypted);

                        break;

                    case "Reverse":

                        string sub = commands[1];

                        if (crypted.ToString().Contains(sub))
                        {
                            crypted.Remove(crypted.ToString().IndexOf(sub), sub.Length);

                            crypted.Append(string.Join("", sub.ToCharArray().Reverse()));

                            Console.WriteLine(crypted);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                        break;

                    case "ChangeAll":

                        string substring = commands[1];
                        string replacement = commands[2];

                        crypted.Replace(substring, replacement);

                        Console.WriteLine(crypted);

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {crypted}");
        }
    }
}
