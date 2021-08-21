using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int totalTickets = 0;
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;

            while (movie != "Finish")
            {
                int freePlaces = int.Parse(Console.ReadLine());

                int countOfTickets = 0;
                string ticket = Console.ReadLine();

                while (ticket != "End")
                {
                    countOfTickets++;

                    switch (ticket)
                    {
                        case "student":
                            studentTickets++;
                            break;
                        case "standard":
                            standardTickets++;
                            break;
                        case "kid":
                            kidTickets++;
                            break;
                    }

                    if (countOfTickets == freePlaces)
                    {
                        break;
                    }

                    ticket = Console.ReadLine();
                }
                totalTickets += countOfTickets;
                Console.WriteLine($"{movie} - {(double)countOfTickets / freePlaces * 100:F2}% full.");

                movie = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(double)studentTickets / totalTickets * 100:F2}% student tickets.");
            Console.WriteLine($"{(double)standardTickets / totalTickets * 100:F2}% standard tickets.");
            Console.WriteLine($"{(double)kidTickets / totalTickets * 100:F2}% kids tickets.");
        }
    }
}
