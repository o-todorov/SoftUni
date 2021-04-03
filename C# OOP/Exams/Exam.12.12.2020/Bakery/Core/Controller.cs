using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Core
{
    class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink>     drinks;
        private List<ITable>     tables;
        private decimal totalBill;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks     = new List<IDrink>();
            this.tables     = new List<ITable>();
            totalBill = 0m;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }
            else if(type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }

            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == nameof(Bread))
            {
                food = new Bread(name, price);
            }
            else if (type == nameof(Cake))
            {
                food = new Cake(name, price);
            }

            bakedFoods.Add(food);
            return string.Format(OutputMessages.FoodAdded, food.Name, food.GetType().Name);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null; 

            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);
            return string.Format(OutputMessages.TableAdded, table.TableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var notReservedTablesInfos = tables.Where(t => !t.IsReserved).Select(t => t.GetFreeTableInfo());
            return string.Join(Environment.NewLine, notReservedTablesInfos);
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalBill);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            decimal bill = table.GetBill() + table.Price;
            totalBill += bill;
            table.Clear();

            return string.Format("Table: {0}{1}Bill: {2:f2}", tableNumber, Environment.NewLine, bill);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            var drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var food = bakedFoods.FirstOrDefault(d => d.Name == foodName);

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var tableToReserve = tables.Where(t => !t.IsReserved)
                                        .FirstOrDefault(tables => tables.Capacity >= numberOfPeople);
            if (tableToReserve == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                tableToReserve.Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, tableToReserve.TableNumber, numberOfPeople);
            }
        }
    }
}
