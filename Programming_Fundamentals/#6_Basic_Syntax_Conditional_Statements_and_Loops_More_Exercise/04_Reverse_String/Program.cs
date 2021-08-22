using System;
using System.Linq;

namespace _04_Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string normalSTring = Console.ReadLine();
            Console.WriteLine(string.Concat(normalSTring.Reverse()));
        }
    }
}
