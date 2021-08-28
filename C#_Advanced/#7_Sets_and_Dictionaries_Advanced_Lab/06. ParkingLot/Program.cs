using System;
using System.Collections.Generic;

namespace _06._ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string carNumber = tokens[1];

                switch (command)
                {
                    case "IN":
                        parkingLot.Add(carNumber);
                        break;

                    case "OUT":
                        parkingLot.Remove(carNumber);
                        break;
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var car in parkingLot)
            {
                Console.WriteLine(car);
            }
        }
    }
}
