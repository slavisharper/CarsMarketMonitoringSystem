namespace CarsMarketMonitoringSystem.ConsoleClient
{
    using CarsMarketMonitoringSystem.Data;
    using CarsMarketMonitoringSystem.Models;
    using CarsMarketMonitoringSystem.MySqlConnector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Telerik.OpenAccess; 

    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new DataManager();
            //DatabaseModelTest(manager);
            //manager.ImportExelReports("../../../Sales-reports.zip");

            //var mongoFiller = new MongoDbFiller(manager);
            //mongoFiller.FillDataBase();

            var saleOld = new Sale();
                saleOld.SaleId = 1;
                saleOld.CarId = 1;
                saleOld.SellerId = 1;
                saleOld.Price = 1300;
                saleOld.Date = DateTime.Now;
                manager.ExportJSONReports(new List<Sale>() { saleOld });

            var saleModel = new SaleModel();

            saleModel.SaleId = 1;
            saleModel.CarId = 1;
            saleModel.SellerId = 1;
            saleModel.Price = 1300;
            saleModel.Date = DateTime.Now;

            manager.ExportDataToMySQL(new List<SaleModel>() { saleModel });
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
