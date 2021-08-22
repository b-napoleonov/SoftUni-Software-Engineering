using System;
using System.Collections.Generic;

namespace _01._AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Messages phrases = new Messages();

            phrases.Phrases = new List<string>()
                {
                    "Excellent product.",
                    "Such a great product.",
                    "I always use that product.",
                    "Best product of its category.",
                    "Exceptional product.",
                    "I can’t live without this product."
                };

            phrases.Events = new List<string>()
            {
                "Now I feel good.", 
                "I have succeeded with this product.", 
                "Makes miracles. I am happy of the results!", 
                "I cannot believe but now I feel awesome.", 
                "Try it yourself, I am very satisfied.", 
                "I feel great!"
            };

            phrases.Authors = new List<string>()
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };

            phrases.Cities = new List<string>()
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            for (int i = 0; i < n; i++)
            {
                phrases.GetRandom();
            }
        }
    }

    public class Messages
    {
        public List<string> Phrases;
        public List<string> Events;
        public List<string> Authors;
        public List<string> Cities;

        public void GetRandom()
        {
            Random random = new Random();

            Console.WriteLine($"{Phrases[random.Next(Phrases.Count)]} {Events[random.Next(Events.Count)]} {Authors[random.Next(Events.Count)]} – {Cities[random.Next(Cities.Count)]}");
        }
    }
}
