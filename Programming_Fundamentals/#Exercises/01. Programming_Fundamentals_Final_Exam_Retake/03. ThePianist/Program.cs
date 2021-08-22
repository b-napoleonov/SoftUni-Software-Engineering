using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._ThePian
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] pieces = Console.ReadLine()
                    .Split('|');

                string piece = pieces[0];
                string composer = pieces[1];
                string key = pieces[2];

                if (!dict.ContainsKey(piece))
                {
                    dict.Add(piece, new List<string>());
                }

                dict[piece].Add(composer);
                dict[piece].Add(key);
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] commands = input.Split('|');
                string command = commands[0];
                string piece = commands[1];

                switch (command)
                {
                    case "Add":

                        string composer = commands[2];
                        string key = commands[3];

                        if (dict.ContainsKey(piece))
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        else
                        {
                            dict.Add(piece, new List<string>());

                            dict[piece].Add(composer);
                            dict[piece].Add(key);

                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }

                        break;

                    case "Remove":

                        if (dict.ContainsKey(piece))
                        {
                            dict.Remove(piece);
                            
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }

                        break;

                    case "ChangeKey":

                        string newKey = commands[2];

                        if (dict.ContainsKey(piece))
                        {
                            dict[piece][1] = newKey;

                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var (key, value) in dict.OrderBy(x => x.Key).ThenBy(x => x.Value[0]))
            {
                Console.WriteLine($"{key} -> Composer: {value[0]}, Key: {value[1]}");
            }
        }
    }
}
