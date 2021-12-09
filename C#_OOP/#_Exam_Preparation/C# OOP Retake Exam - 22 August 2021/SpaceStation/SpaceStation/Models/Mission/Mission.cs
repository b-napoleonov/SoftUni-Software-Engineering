using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            var validAstronauts = astronauts.Where(a => a.CanBreath);

            foreach (var astronaut in validAstronauts)
            {
                while (astronaut.CanBreath && planet.Items.Any())
                {
                    var item = planet.Items.FirstOrDefault();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    astronaut.Breath();
                }

                if (planet.Items.Any() == false)
                {
                    break;
                }
            }
        }
    }
}
