using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;

//TODO there are some special cases that cause 2 errors in Judge

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> driversRepo;
        private IRepository<ICar> carsRepo;
        private IRepository<IRace> racesRepo;

        public ChampionshipController()
        {
            driversRepo = new DriverRepository();
            carsRepo = new CarRepository();
            racesRepo = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = driversRepo.GetByName(driverName);
            ICar car = carsRepo.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = racesRepo.GetByName(raceName);
            IDriver driver = driversRepo.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            type = type + "Car";
            ICar car = type switch
            {
                nameof(MuscleCar) => new MuscleCar(model, horsePower),
                nameof(SportsCar) => new SportsCar(model, horsePower),
            };

            if (carsRepo.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            carsRepo.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (driversRepo.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driversRepo.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            if (racesRepo.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            racesRepo.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = racesRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            IDriver[] winners = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .ToArray();

            racesRepo.Remove(race);

            string first = string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, raceName);
            string second = string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, raceName);
            string thrird = string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, raceName);

            return first + Environment.NewLine + second + Environment.NewLine + thrird;
        }
    }
}
