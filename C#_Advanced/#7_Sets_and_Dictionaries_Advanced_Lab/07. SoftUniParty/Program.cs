using System;
using System.Collections.Generic;

namespace _07._SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
            bool isParty = false;
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    isParty = true;
                    continue;
                }
                if (isParty == false)
                {
                    if (VIPChecker(input))
                    {
                        VIP.Add(input);
                    }
                    else
                    {
                        regular.Add(input);
                    }
                }
                else
                {
                    if (VIPChecker(input))
                    {
                        VIP.Remove(input);
                    }
                    else
                    {
                        regular.Remove(input);
                    }
                }
            }

            Console.WriteLine(VIP.Count + regular.Count);

            foreach (var guest in VIP)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }
        }

        static bool VIPChecker(string input)
        {
            return char.IsDigit(input[0]);
        }
    }
}
