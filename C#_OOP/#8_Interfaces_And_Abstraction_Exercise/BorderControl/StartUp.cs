using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Citizen> citizenBuyers = new List<Citizen>();
            List<Rebel> rebelBuyers = new List<Rebel>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);

                switch (info.Length)
                {
                    case 4:

                        string id = info[2];
                        string birthdate = info[3];
                        Citizen currCitizen = new Citizen(name, age, id, birthdate);
                        citizenBuyers.Add(currCitizen);

                        break;

                    case 3:

                        string group = info[2];
                        Rebel currRebel = new Rebel(name, age, group);
                        rebelBuyers.Add(currRebel);

                        break;
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                Citizen currentCitizen = citizenBuyers.FirstOrDefault(b => b.Name == input);
                Rebel currentRebel = rebelBuyers.FirstOrDefault(r => r.Name == input);

                if (currentCitizen != null)
                {
                    currentCitizen.BuyFood();
                }
                else if (currentRebel != null)
                {
                    currentRebel.BuyFood();
                }
            }

            Console.WriteLine(citizenBuyers.Sum(f => f.Food) + rebelBuyers.Sum(f => f.Food));
        }
    }
}
