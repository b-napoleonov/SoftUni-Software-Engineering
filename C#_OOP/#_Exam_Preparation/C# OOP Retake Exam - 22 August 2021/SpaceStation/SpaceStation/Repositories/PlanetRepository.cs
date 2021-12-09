using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => planets.ToImmutableList();

        public void Add(IPlanet model) 
            => planets.Add(model);

        public IPlanet FindByName(string name) 
            => planets.FirstOrDefault(p => p.Name == name);

        public bool Remove(IPlanet model) 
            => planets.Remove(model);
    }
}
