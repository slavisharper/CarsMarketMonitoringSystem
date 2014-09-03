using CarsMarketMonitoringSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsMarketMonitoringSystem.Data.MongoDb.Mappings;

namespace CarsMarketMonitoringSystem.ConsoleClient
{
    public class MongoDbFiller
    {
        private DataManager manager;

        public MongoDbFiller(DataManager manager)
        {
            this.manager = manager;
        }

        public void FillDataBase()
        {
            AddLocations();
            AddManufacturers();
            AddSellers();
            AddCars();
        }

        private void AddCars()
        {
            this.manager.MongoDbContext.Cars.Insert(new CarMap(19, "316", 8, 260, 100, 10000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(20, "SL500", 9, 280, 150, 20000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(21, "E200", 9, 200, 90, 10000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(22, "Astra", 10, 260, 120, 9000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(23, "Corsa", 10, 220, 80, 5000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(24, "Fabia", 11, 240, 110, 12000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(25, "Yaris", 13, 250, 130, 11000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(26, "Niva", 12, 160, 70, 3000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(27, "1500", 12, 170, 80, 3500));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(28, "Corolla", 13, 260, 130, 16000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(29, "Swift", 34, 260, 1300, 9000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(30, "Vitara", 34, 200, 140, 11000)); 
            this.manager.MongoDbContext.Cars.Insert(new CarMap(31, "Civic", 14, 260, 150, 15000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(32, "Accord", 14, 270, 180, 16000));
            this.manager.MongoDbContext.Cars.Insert(new CarMap(33, "Pilot", 14, 260, 200, 20000));
        }

        private void AddManufacturers()
        {
            this.manager.MongoDbContext.Manufacturers.Insert(new ManufacturerMap(8, "BMW", 1));
            this.manager.MongoDbContext.Manufacturers.Insert(new ManufacturerMap(9, "Mercedes", 2));
            this.manager.MongoDbContext.Manufacturers.Insert(new ManufacturerMap(10, "Opel", 3));
            this.manager.MongoDbContext.Manufacturers.Insert(new ManufacturerMap(11, "Skoda", 4));
            this.manager.MongoDbContext.Manufacturers.Insert(new ManufacturerMap(12, "Lada", 5));
            this.manager.MongoDbContext.Manufacturers.Insert(new ManufacturerMap(13, "Toyota", 6));
            this.manager.MongoDbContext.Manufacturers.Insert(new ManufacturerMap(14, "Honda", 7));
            this.manager.MongoDbContext.Manufacturers.Insert(new ManufacturerMap(34, "Suzuki", 7));
        }

        private void AddSellers()
        {
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap(15, "Pesho Cars", 1));
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap(16, "Tosho Cars", 2));
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap(17, "Mitko Cars", 4));
            this.manager.MongoDbContext.Sellers.Insert(new SellerMap(18, "Unufrii Cars", 5));
        }


        private void AddLocations()
        {
            this.manager.MongoDbContext.Locations.Insert(new LocationMap(1, "Sofia", "TsarBoris"));
            this.manager.MongoDbContext.Locations.Insert(new LocationMap(2, "Varna", "TsarBoris"));
            this.manager.MongoDbContext.Locations.Insert(new LocationMap(3, "Plovdiv", "TsarBoris"));
            this.manager.MongoDbContext.Locations.Insert(new LocationMap(4, "Burgas", "TsarBoris"));
            this.manager.MongoDbContext.Locations.Insert(new LocationMap(5, "Sofia", "Cherni vruh"));
            this.manager.MongoDbContext.Locations.Insert(new LocationMap(6, "Sofia", "Okolovrusten put"));
            this.manager.MongoDbContext.Locations.Insert(new LocationMap(7, "Pernik", "TsarBoris"));
        }
    }
}
