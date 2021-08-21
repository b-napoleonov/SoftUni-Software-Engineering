using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = 1; i < num1; i++)
            {
                for (int j = 1; j < num1; j++)
                {
                    for (int k = 'a'; k < 'a' + num2; k++)
                    {
                        for (int l = 'a'; l < 'a' + num2; l++)
                        {   
                            for (int m = 2; m <= num1; m++)
                            {
                                if (m > i && m > j)
                                {
                                    Console.Write($"{i}{j}{(char)k}{(char)l}{m} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
