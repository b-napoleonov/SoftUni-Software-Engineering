using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05._NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            //add to the list and check the input

            List<string> demons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = 0; i < demons.Count; i++)
            {
                demons[i] = demons[i].Trim();
                string item = demons[i];
                bool remove = true;

                for (int j = 0; j < item.Length; j++)
                {
                    if (char.IsWhiteSpace(item[j]) || item[j] == ',')
                    {
                        demons.Remove(item);
                        break;
                    }
                    if (char.IsLetter(item[j]))
                    {
                        remove = false;
                    }
                    if (remove)
                    {
                        demons.Remove(item);
                    }
                }
            }
            //sorting the demons by name

            demons.Sort();

            foreach (var demonName in demons)
            {
                //getting health of th demon

                int demonHealth = 0;

                MatchCollection words = Regex.Matches(demonName, @"[^\d+\-*/.]");

                foreach (Match word in words)
                {
                    demonHealth += char.Parse(word.ToString());
                }

                //getting the damage of the demon

                decimal baseDamage = 0;

                MatchCollection digits = Regex.Matches(demonName, @"[+-]?([0-9]*[.])?[0-9]+");

                foreach (Match digit in digits)
                {
                    baseDamage += decimal.Parse(digit.ToString());
                }

                for (int i = 0; i < demonName.Length; i++)
                {
                    if (demonName[i] == '*')
                    {
                        baseDamage *= 2;
                    }
                    else if (demonName[i] == '/')
                    {
                        baseDamage /= 2;
                    }
                }

                //printing
                Console.WriteLine($"{demonName} - {demonHealth} health, {baseDamage:F2} damage");
            }
        }
    }
}
