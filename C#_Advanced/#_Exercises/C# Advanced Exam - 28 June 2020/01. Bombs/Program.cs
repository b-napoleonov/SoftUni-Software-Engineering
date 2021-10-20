using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> bombCasings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int daturaBomb = 0;
            int cherryBomb = 0;
            int decoybomb = 0;

            while (true)
            {
                if (bombEffects.Count < 1 || bombCasings.Count < 1 || (daturaBomb >= 3 && cherryBomb >= 3 && decoybomb >= 3))
                {
                    break;
                }

                int sum = bombEffects.Peek() + bombCasings.Peek();

                if (sum == 40)
                {
                    daturaBomb++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 60)
                {
                    cherryBomb++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 120)
                {
                    decoybomb++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    int temp = bombCasings.Pop() - 5;

                    if (temp < 0)
                    {
                        continue;
                    }

                    bombCasings.Push(temp);
                }
            }

            Console.WriteLine(daturaBomb + cherryBomb + decoybomb >= 9 ? 
                "Bene! You have successfully filled the bomb pouch!" : 
                "You don't have enough materials to fill the bomb pouch.");

            Console.WriteLine(bombEffects.Count > 0 ? $"Bomb Effects: {string.Join(", ", bombEffects)}" : "Bomb Effects: empty");
            Console.WriteLine(bombCasings.Count > 0 ? $"Bomb Casings: {string.Join(", ", bombCasings)}" : "Bomb Casings: empty");

            Console.WriteLine($"Cherry Bombs: {cherryBomb}");
            Console.WriteLine($"Datura Bombs: {daturaBomb}");
            Console.WriteLine($"Smoke Decoy Bombs: {decoybomb}");
        }
    }
}
