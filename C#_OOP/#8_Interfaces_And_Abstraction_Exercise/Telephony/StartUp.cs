using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbers)
            {
                if (!number.All(c => char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                ICallable current = null;

                if (number.Length == 7)
                {
                    current = new StationaryPhone();
                }
                else
                {
                    current = new Smartphone();
                }

                current.Call(number);
            }

            foreach (var site in sites)
            {
                if (site.Any(c => char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                Smartphone current = new Smartphone();
                current.Browse(site);
            }
        }
    }
}
