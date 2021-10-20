using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model) 
            => data.Remove(data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model));

        public Car GetLatestCar() 
            => Count != 0 ? data.OrderByDescending(c => c.Year).FirstOrDefault() : null;

        public Car GetCar(string manufacturer, string model) 
            => data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
