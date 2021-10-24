using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> Participants;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (Count < Capacity && car.HorsePower <= MaxHorsePower && !Participants.Any(c => c.LicensePlate != car.LicensePlate))
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car carToRemove = Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);

            if (carToRemove == null)
            {
                return false;
            }

            Participants.Remove(carToRemove);
            return true;
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
