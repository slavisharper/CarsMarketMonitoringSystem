namespace CarsMarketMonitoringSystem.Data
{
    using System;
    using System.Linq;

    using CarsMarketMonitoringSystem.Models;
    using CarsMarketMonitoringSystem.Data.MongoDb;

    public class MongoDbManager
    {
        public MongoDbManager(CarsMarketDbContext carsMarketDbContext, MongoDbContext mongoDb)
        {
            this.CarsMarketDbContext = carsMarketDbContext;
            this.MongoDb = mongoDb;
        }

        public MongoDbContext MongoDb { get; set; }

        public CarsMarketDbContext CarsMarketDbContext { get; set; }

        public void ImportData()
        {
            this.AddCars();
            this.AddExpenses();
            this.AddLocations();
            this.AddManufacturers();
            this.AddSellers();
            this.SaveChanges();
        }

        public void AddCars()
        {
            if (this.CarsMarketDbContext.Cars.Any())
            {
                return;
            }

            foreach (var car in this.MongoDb.Cars.FindAll())
            {
                this.CarsMarketDbContext.Cars.Add(new Car()
                {
                    CarId = car.CarId,
                    Model = car.Model,
                    ManufacturerId = car.ManufacturerId,
                    TopSpeed = car.TopSpeed,
                    BrakeHorsePower = car.BrakeHorsePower,
                    BasePrice = car.BasePrice,
                });
            }
        }

        public void AddExpenses()
        {
            if (this.CarsMarketDbContext.Expenses.Any())
            {
                return;
            }

            foreach (var expense in this.MongoDb.Expenses.FindAll())
            {
                this.CarsMarketDbContext.Expenses.Add(new Expense()
                {
                    ExpenseId = expense.ExpenseId,
                    ManufacturerId = expense.ManufacturerId,
                    Expenses = expense.Expenses,
                    Month = expense.Month
                });
            }
        }

        public void AddLocations()
        {
            if (this.CarsMarketDbContext.Locations.Any())
            {
                return;
            }

            foreach (var location in this.MongoDb.Locations.FindAll())
            {
                this.CarsMarketDbContext.Locations.Add(new Location()
                {
                    LocationId = location.LocationId,
                    Town = location.Town,
                    Address = location.Address
                });
            }
        }

        public void AddManufacturers()
        {
            if (this.CarsMarketDbContext.Manufacturers.Any())
            {
                return;
            }

            foreach (var manufacturer in this.MongoDb.Manufacturers.FindAll())
            {
                this.CarsMarketDbContext.Manufacturers.Add(new Manufacturer()
                {
                    ManufacturerId = manufacturer.ManufacturerId,
                    Name = manufacturer.Name,
                    LocationId = manufacturer.LocationId
                });
            }
        }

        public void AddSellers()
        {
            if (this.CarsMarketDbContext.Sellers.Any())
            {
                return;
            }

            foreach (var seller in this.MongoDb.Sellers.FindAll())
            {
                this.CarsMarketDbContext.Sellers.Add(new Seller()
                {
                    SellerId = seller.SellerId,
                    Name = seller.Name,
                    LocationId = seller.LocationId,
                    Cars = seller.Cars
                });
            }
        }

        public void SaveChanges()
        {
            this.CarsMarketDbContext.SaveChanges();
        }
    }
}