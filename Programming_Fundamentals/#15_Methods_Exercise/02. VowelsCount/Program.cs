using System;

namespace _02._VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(VowelsFinder(input));
        }

        static int VowelsFinder(string input)
        {
            input = input.ToLower();
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || 
                    input[i] == 'e' || 
                    input[i] == 'i' || 
                    input[i] == 'o' || 
                    input[i] == 'u')
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
