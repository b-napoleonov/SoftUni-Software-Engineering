using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => cars.AsReadOnly();

        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            cars.Add(model);
        }

        public ICar FindBy(string property) 
            => cars.FirstOrDefault(c => c.VIN == property);

        public bool Remove(ICar model) 
            => cars.Remove(model);
    }
}
