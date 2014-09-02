namespace CarsMarketMonitoringSystem.Data.MongoDb
{
    using System;
    using System.Linq;
    using MongoDB.Driver;
    using CarsMarketMonitoringSystem.Data.MongoDb.Mappings;

    public class MongoDbContext
    {
        private readonly string connectionString;
        private readonly string databaseName;
  
        public MongoDbContext(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        public MongoCollection<CarMap> Cars
        {
            get
            {
                return this.GetCollection<CarMap>("Cars");
            }
        }

        public MongoCollection<ExpenseMap> Expenses
        {
            get
            {
                return this.GetCollection<ExpenseMap>("Expenses");
            }
        }

        public MongoCollection<LocationMap> Locations
        {
            get
            {
                return this.GetCollection<LocationMap>("Locations");
            }
        }

        public MongoCollection<ManufacturerMap> Manufacturers
        {
            get
            {
                return this.GetCollection<ManufacturerMap>("Manufacturers");
            }
        }

        public MongoCollection<SellerMap> Sellers
        {
            get
            {
                return this.GetCollection<SellerMap>("Sellers");
            }
        }

        private MongoCollection<T> GetCollection<T>(string collectionName)
        {
            var database = this.GetDatabase();
            var collection = database.GetCollection<T>(collectionName);
            return collection;
        }

        private MongoDatabase GetDatabase()
        {
            var mongoClient = new MongoClient(this.connectionString);
            var mongoServer = mongoClient.GetServer();

            var database = mongoServer.GetDatabase(this.databaseName);
            return database;
        }
    }
}
