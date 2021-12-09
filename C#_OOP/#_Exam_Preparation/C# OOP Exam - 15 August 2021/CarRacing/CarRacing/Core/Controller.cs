using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IRacer> racers;
        private readonly IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = type switch
            {
                "SuperCar" => new SuperCar(make, model, VIN, horsePower),
                "TunedCar" => new TunedCar(make, model, VIN, horsePower),
                _ => throw new ArgumentException(ExceptionMessages.InvalidCarType),
            };

            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);

            if (car is null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = type switch
            {
                "ProfessionalRacer" => new ProfessionalRacer(username, car),
                "StreetRacer" => new StreetRacer(username, car),
                _ => throw new ArgumentException(ExceptionMessages.InvalidRacerType),
            };

            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer firstRacer = racers.FindBy(racerOneUsername);

            if (firstRacer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            IRacer secondRacer = racers.FindBy(racerTwoUsername);

            if (secondRacer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(firstRacer, secondRacer);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var racer in racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
