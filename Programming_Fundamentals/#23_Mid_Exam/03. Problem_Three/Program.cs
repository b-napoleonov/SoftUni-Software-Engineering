using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem_Three
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] arr = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = arr[0];
                string phone = arr[1];

                switch (command)
                {
                    case "Add":

                        if (!list.Contains(phone))
                        {
                            list.Add(phone);
                        }
                        
                        break;

                    case "Remove":

                        if (list.Contains(phone))
                        {
                            list.Remove(phone);
                        }
                        
                        break;

                    case "Bonus phone":
                        string oldPhone = arr[1].Split(':')[0];
                        string newPhone = arr[1].Split(':')[1];

                        if (list.Contains(oldPhone))
                        {
                            list.Insert(list.IndexOf(oldPhone), newPhone);
                            list.Remove(oldPhone);
                            list.Insert(list.IndexOf(newPhone), oldPhone);
                        }
                        
                        break;

                    case "Last":

                        if (list.Contains(phone))
                        {
                            list.Remove(phone);
                            list.Add(phone);
                        }
                        
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
