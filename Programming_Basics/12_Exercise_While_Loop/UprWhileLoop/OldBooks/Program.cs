using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            string nextBook = Console.ReadLine();

            int counter = 0;

            while (nextBook != "No More Books")
            {
                if (nextBook == favouriteBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }
                counter++;
                nextBook = Console.ReadLine();
            }
            if (nextBook != favouriteBook)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
