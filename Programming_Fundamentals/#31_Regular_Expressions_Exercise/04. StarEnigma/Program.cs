using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            
            string pattern = @"\@(?<planet>[A-Z][a-z]+)[^\@\-!:>]*?:(?<population>\d+)[^\@\-!:>]*?!(?<attackType>[A-D])![^\@\-!:>]*?->(?<soldiers>\d+)";

            for (int i = 0; i < n; i++)
            {
                StringBuilder decryptedMessage = new StringBuilder();
                string input = Console.ReadLine();
                string buffer = input.ToLower();
                int decryptionKey = 0;

                for (int j = 0; j < buffer.Length; j++)
                {

                    switch (buffer[j])
                    {
                        case 's':
                        case 't':
                        case 'a':
                        case 'r':
                            decryptionKey++;
                            break;
                    }
                }

                for (int j = 0; j < input.Length; j++)
                {
                    decryptedMessage.Append((char)(input[j] - decryptionKey));
                }

                MatchCollection planets = Regex.Matches(decryptedMessage.ToString(), pattern);

                foreach (Match item in planets)
                {
                    if (item.Groups["attackType"].Value == "A")
                    {
                        attackedPlanets.Add(item.Groups["planet"].Value);
                    }
                    else
                    {
                        destroyedPlanets.Add(item.Groups["planet"].Value);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            if (attackedPlanets.Count > 0)
            {
                Console.WriteLine("-> " + string.Join(Environment.NewLine + "-> ", attackedPlanets.OrderBy(x => x)));
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            if (destroyedPlanets.Count > 0)
            {
                Console.WriteLine("-> " +  string.Join(Environment.NewLine + "-> ", destroyedPlanets.OrderBy(x => x)));
            }
            //......................................................................
            //Better printing
            //Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            //foreach (var planet in attackedPlanets.OrderBy(p => p))
            //{
            //    Console.WriteLine($"-> {planet}");
            //}

            //Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            //foreach (var planet in destroyedPlanets.OrderBy(p => p))
            //{
            //    Console.WriteLine($"-> {planet}");
            //}
            //......................................................................
        }
    }
}
