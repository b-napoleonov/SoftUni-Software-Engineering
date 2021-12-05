using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//TODO There are mistake somewhere and Judge gives 126/150 points

namespace Bakery.Core
{
    public class Controller : IController
    {
        private IList<BakedFood> bakedFoods;
        private IList<Drink> drinks;
        private IList<Table> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            bakedFoods = new List<BakedFood>();
            drinks = new List<Drink>();
            tables = new List<Table>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            switch (type)
            {
                case "Tea":

                    drinks.Add(new Tea(name, portion, brand));

                    break;

                case "Water":

                    drinks.Add(new Water(name, portion, brand));

                    break;
            }

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Bread":

                    bakedFoods.Add(new Bread(name, price));

                    break;

                case "Cake":

                    bakedFoods.Add(new Cake(name, price));

                    break;
            }

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "InsideTable":

                    tables.Add(new InsideTable(tableNumber, capacity));

                    break;

                case "OutsideTable":

                    tables.Add(new OutsideTable(tableNumber, capacity));

                    break;
            }

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            List<Table> freeTables = tables.Where(t => t.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var freeTable in freeTables)
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            totalIncome += bill + table.Price;
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            Drink drink = drinks.FirstOrDefault(d => d.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            BakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            Table table = tables.Where(t => t.IsReserved == false && t.Capacity < numberOfPeople).FirstOrDefault();

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);

            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
