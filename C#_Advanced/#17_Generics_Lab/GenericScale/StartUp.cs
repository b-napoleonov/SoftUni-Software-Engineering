using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new EqualityScale<int>(55, 55).AreEqual());
        }
    }
}
