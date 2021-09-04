using System;
using System.Linq;

namespace _01._ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> name = name => Console.WriteLine(name);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(t => name(t));
        }
    }
}
