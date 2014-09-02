namespace CarsMarketMonitoringSystem.ConsoleClient
{
    using CarsMarketMonitoringSystem.Data;
    using CarsMarketMonitoringSystem.Models;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new DataManager();
            //DatabaseModelTest(manager);
            var sales = manager.DatabaseContex.Cars.Take(10).ToList();
            Console.WriteLine(sales.Count);
        }

        private static void DatabaseModelTest(DataManager manager)
        {
            manager.DatabaseContex.Locations.Add(new Location()
            {
                Town = "Sofia",
                Address = "Car Boris"
            });
            
            manager.DatabaseContex.Manufacturers.Add(new Manufacturer()
            {
                LocationId = 1,
                Name = "BMW-Sofia"
            });
            
            manager.DatabaseContex.Cars.Add(new Car()
            {
                ManufacturerId = 1,
                Model = "318M",
                BasePrice = 20000m
            });
            
            manager.DatabaseContex.Sellers.Add(new Seller()
            {
                Name = "PeshoCars",
                LocationId = 1
            });

            manager.DatabaseContex.Sales.Add(new Sale()
            {
                CarId = 1,
                Date = DateTime.Now,
                Price = 32000m,
                SellerId = 1
            });

            manager.DatabaseContex.SaveChanges();
        }
    }
}
