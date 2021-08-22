using System;
using System.Linq;

namespace _04._PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isTrue = true;

            if (PasswordCheckerRule1(password) != "")
            {
                Console.WriteLine(PasswordCheckerRule1(password));
                isTrue = false;
            }
            if (PasswordCheckerRule2(password) != "")
            {
                Console.WriteLine(PasswordCheckerRule2(password));
                isTrue = false;
            }
            if (PasswordCheckerRule3(password) != "")
            {
                Console.WriteLine(PasswordCheckerRule3(password));
                isTrue = false;
            }
            if (isTrue)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static string PasswordCheckerRule1(string password)
        {
            string output = "";


            if (password.Length < 6 || password.Length > 10)
            {
                output = "Password must be between 6 and 10 characters";
            }

            return output;
        }

        static string PasswordCheckerRule2(string password)
        {
            string output = "";

            if (!password.All(Char.IsLetterOrDigit))
            {
                output = "Password must consist only of letters and digits";
            }

            return output;
        }

        static string PasswordCheckerRule3(string password)
        {
            string output = "";

            if (password.Count(Char.IsDigit) < 2)
            {
                output = "Password must have at least 2 digits";
            }

            return output;
        }
    }
}
