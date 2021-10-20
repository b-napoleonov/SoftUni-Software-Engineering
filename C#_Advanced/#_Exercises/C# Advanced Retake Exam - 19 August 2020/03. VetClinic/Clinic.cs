using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (Capacity > Count)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name) 
            => data.Remove(data.FirstOrDefault(n => n.Name == name));

        public Pet GetPet(string name, string owner) 
            => data.FirstOrDefault(n => n.Name == name && n.Owner == owner);

        public Pet GetOldestPet() 
            => Count != 0 ? data.OrderByDescending(p => p.Age).FirstOrDefault() : null;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
