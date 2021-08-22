using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._HCLVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroes = Console.ReadLine().Split();

                string heroName = heroes[0];
                int HP = int.Parse(heroes[1]);
                int MP = int.Parse(heroes[2]);

                if (!dict.ContainsKey(heroName))
                {
                    dict.Add(heroName, new List<int> { HP, MP });
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(" - ");

                string command = commands[0];
                string name = commands[1];

                switch (command)
                {
                    case "CastSpell":

                        int MPneeded = int.Parse(commands[2]);
                        string spellName = commands[3];

                        if (dict[name][1] < MPneeded)
                        {
                            Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} has successfully cast {spellName} and now has {dict[name][1] - MPneeded} MP!");
                            dict[name][1] -= MPneeded;
                        }

                        break;

                    case "TakeDamage":

                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];

                        if (dict[name][0] <= damage)
                        {
                            Console.WriteLine($"{name} has been killed by {attacker}!");
                            dict.Remove(name);
                        }
                        else
                        {
                            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {dict[name][0] - damage} HP left!");
                            dict[name][0] -= damage;
                        }

                        break;

                    case "Recharge":

                        int amountMP = int.Parse(commands[2]);

                        if (dict[name][1] + amountMP > 200)
                        {
                            Console.WriteLine($"{name} recharged for {200 - dict[name][1]} MP!");
                            dict[name][1] = 200;
                        }
                        else
                        {
                            Console.WriteLine($"{name} recharged for {amountMP} MP!");
                            dict[name][1] += amountMP;
                        }

                        break;

                    case "Heal":

                        int amountHP = int.Parse(commands[2]);

                        if (dict[name][0] + amountHP > 100)
                        {
                            Console.WriteLine($"{name} healed for {100 - dict[name][0]} HP!");
                            dict[name][0] = 100;
                        }
                        else
                        {
                            Console.WriteLine($"{name} healed for {amountHP} HP!");
                            dict[name][0] += amountHP;
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var hero in dict.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value[0]}   \n  MP: {hero.Value[1]}");
            }
        }
    }
}
