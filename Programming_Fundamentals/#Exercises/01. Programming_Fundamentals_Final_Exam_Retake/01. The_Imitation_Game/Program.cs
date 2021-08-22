using System;
using System.Text;

namespace _01._TheImiG
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            StringBuilder decrypted = new StringBuilder(encryptedMessage);
            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] commands = input.Split('|');
                string operation = commands[0];

                switch (operation)
                {
                    case "Move":
                        
                        int numberOfLetters = int.Parse(commands[1]);
                        string firstLetters = decrypted.ToString().Substring(0, numberOfLetters);

                        decrypted.Remove(0, numberOfLetters);
                        decrypted.Append(firstLetters);

                        break;

                    case "Insert":

                        int index = int.Parse(commands[1]);
                        string value = commands[2];

                        decrypted.Insert(index, value);

                        break;

                    case "ChangeAll":

                        string substring = commands[1];
                        string replacement = commands[2];

                        decrypted.Replace(substring, replacement);

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {decrypted}");
        }
    }
}
