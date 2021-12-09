using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => astronauts.ToImmutableList();

        public void Add(IAstronaut model) 
            => astronauts.Add(model);

        public IAstronaut FindByName(string name) 
            => astronauts.FirstOrDefault(a => a.Name == name);

        public bool Remove(IAstronaut model) 
            => astronauts.Remove(model);
    }
}
