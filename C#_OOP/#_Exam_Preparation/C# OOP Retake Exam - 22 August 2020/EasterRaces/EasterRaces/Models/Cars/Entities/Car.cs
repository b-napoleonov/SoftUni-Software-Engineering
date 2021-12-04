using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;

            protected set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;

            protected set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            }
        }

        public double CubicCentimeters { get => cubicCentimeters; private set => cubicCentimeters = value; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
