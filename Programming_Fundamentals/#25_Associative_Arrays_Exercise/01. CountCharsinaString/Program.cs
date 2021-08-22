using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountCharsinaString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            //string input = Console.ReadLine();

            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (!dict.ContainsKey(input[i]))
            //    {
            //        dict.Add(input[i], 0);
            //    }

            //    dict[input[i]]++;

            //    if (dict.ContainsKey(' '))
            //    {
            //        dict.Remove(' ');
            //    }
            //}

            //foreach (var (key, value) in dict)
            //{
            //    Console.WriteLine($"{key} -> {value}");
            //}

            string[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string word = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                word += arr[i];
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (!dict.ContainsKey(word[i]))
                {
                    dict.Add(word[i], 0);
                }

                dict[word[i]]++;
            }

            foreach (var (key, value) in dict)
            {
                Console.WriteLine($"{key} -> {value}");
            }
        }
    }
}
