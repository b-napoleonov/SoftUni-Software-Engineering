using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (Components.Any() == false)
                {
                    return base.OverallPerformance;
                }

                double averagePerformance = (double)(Components.Any() ? Components.Average(c => c.Price) : 0);

                return base.OverallPerformance + averagePerformance;
            }
        }

        public override decimal Price
        {
            get
            {
                decimal componentsPrice = Components.Any() ? Components.Sum(c => c.Price) : 0;
                decimal peripheralsPrice = Peripherals.Any() ? Peripherals.Sum(p => p.Price) : 0;

                return base.Price + componentsPrice + peripheralsPrice;
            }
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            string componentType = component
                .GetType()
                .Name;

            if (Components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, componentType, GetType().Name, Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            string peripheralType = peripheral
                .GetType()
                .Name;

            if (Peripherals.Any(p => p.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheralType, GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (Components.All(c => c.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id));
            }

            IComponent component = components.FirstOrDefault(c => c.GetType().Name == componentType);

            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (Peripherals.All(p => p.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id));
            }

            IPeripheral peripheral = Peripherals
                .FirstOrDefault(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(" " + string.Format(SuccessMessages.ComputerComponentsToString, Components.Count));

            foreach (IComponent component in Components)
            {
                sb.AppendLine(" " + component.ToString());
            }

            sb.AppendLine(" " + string.Format(SuccessMessages.ComputerPeripheralsToString, Peripherals.Count,
                Peripherals.Any() ? Peripherals.Average(p => p.OverallPerformance) : 0));

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine(" " + peripheral.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
