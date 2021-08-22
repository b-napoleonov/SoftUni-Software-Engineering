using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Problem_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            
            string input = Console.ReadLine();

            while (input != "No More Money")
            {
                string[] arr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = arr[0];
                string biscuit = arr[1];

                switch (command)
                {
                    case "OutOfStock":

                        if (list.Contains(biscuit))
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i] == biscuit)
                                {
                                    list[i] = "None";
                                }
                            }
                        }
                        
                        break;

                    case "Required":

                        int index = int.Parse(arr[2]);

                        if (index >= 0 && index < list.Count && list[index] != "None")
                        {
                            list[index] = biscuit;
                        }
                        
                        break;

                    case "Last":

                        list.Add(biscuit);
                        
                        break;
                }

                input = Console.ReadLine();
            }

            list.RemoveAll(x => x == "None");
            Console.WriteLine(string.Join(' ', list));
        }
    }
}
