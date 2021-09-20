using System;

namespace GenericBoxOfString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStrings; i++)
            {
                Box<string> inputs = new Box<string>(Console.ReadLine());
                Console.WriteLine(inputs);
            }
        }
    }
}
