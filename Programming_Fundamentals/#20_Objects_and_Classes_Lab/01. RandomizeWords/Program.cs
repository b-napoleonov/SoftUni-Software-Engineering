using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random(); // Нова инстанция на класа Random, получаваме обекта rnd

            for (int i = 0; i < words.Length; i++)
            {
                int pos = rnd.Next(words.Length); // Инициализираме му нова случайна стойност
                
                string current = words[i];
                words[i] = words[pos];
                words[pos] = current;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
