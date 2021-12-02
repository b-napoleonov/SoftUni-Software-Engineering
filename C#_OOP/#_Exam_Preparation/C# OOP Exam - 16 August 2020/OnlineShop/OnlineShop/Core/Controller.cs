using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

//TODO - There is mistake somewhere and 3 tests in Judge are wrong

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfExist(computerId);

            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            Enum.TryParse(componentType, out ComponentType typeOfComponent);
            IComponent component = typeOfComponent switch
            {
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),

                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);
            components.Add(component);
            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            Enum.TryParse(computerType, out ComputerType typeOfComputer);
            IComputer computer = typeOfComputer switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),

                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };

            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfExist(computerId);

            if (peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            Enum.TryParse(peripheralType, out PeripheralType typeOfPeripheral);
            IPeripheral peripheral = typeOfPeripheral switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),

                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            computers.FirstOrDefault(c => c.Id == computerId).AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, typeOfPeripheral, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer bestComputerToBuy = computers.Where(c => c.Price <= budget).OrderByDescending(c => c.OverallPerformance).FirstOrDefault();

            if (bestComputerToBuy == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(bestComputerToBuy);

            return bestComputerToBuy.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfExist(id);

            IComputer computerToBuy = computers.FirstOrDefault(c => c.Id == id);
            computers.Remove(computerToBuy);

            return computerToBuy.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfExist(id);

            IComputer computer = computers.FirstOrDefault(c => c.Id == id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfExist(computerId);

            IComponent componentToRemove = computers.FirstOrDefault(c => c.Id == computerId).RemoveComponent(componentType);
            components.Remove(componentToRemove);

            return string.Format(SuccessMessages.RemovedComponent, componentType, componentToRemove.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfExist(computerId);

            IPeripheral peripheralToRemove = computers.FirstOrDefault(c => c.Id == computerId).RemovePeripheral(peripheralType);
            peripherals.Remove(peripheralToRemove);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheralToRemove.Id);
        }

        private void CheckIfExist(int id)
        {
            if (computers.Any(c => c.Id == id) == false)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
