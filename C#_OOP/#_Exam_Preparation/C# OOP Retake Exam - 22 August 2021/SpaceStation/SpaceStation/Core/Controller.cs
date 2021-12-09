using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronauts;
        private readonly IRepository<IPlanet> planets;
        private readonly IMission mission;
        private int exploredPlanets = 0;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = type switch
            {
                "Biologist" => new Biologist(astronautName),
                "Geodesist" => new Geodesist(astronautName),
                "Meteorologist" => new Meteorologist(astronautName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType),
            };

            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var bestAstronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (bestAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = planets.FindByName(planetName);
            mission.Explore(planet, bestAstronauts);
            exploredPlanets++;
            int deadAstronauts = bestAstronauts.Count(a => a.CanBreath == false);

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {(astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronautToRetire = astronauts.FindByName(astronautName);

            if (astronautToRetire is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronautToRetire);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
