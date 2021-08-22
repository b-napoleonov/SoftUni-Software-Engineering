using System;
using System.Linq;

namespace _05_Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Join("", username.Reverse());

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i]; 
            }


            for (int i = 0; i < 4; i++)
            {
                string passwordTry = Console.ReadLine();
                if (passwordTry == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                if (i != 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
            Console.WriteLine($"User {username} blocked!");
        }
    }
}
