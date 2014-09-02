namespace CarsMarketMonitoringSystem.Data.MongoDb.Mappings
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class ExpenseMap
    {
        [BsonConstructor]
        public ExpenseMap(int expenseId, int manufacturerId, decimal expenses, DateTime month)
        {
            this.ExpenseId = expenseId;
            this.ManufacturerId = manufacturerId;
            this.Expenses = expenses;
            this.Month = month;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int ExpenseId { get; set; }

        public int ManufacturerId { get; set; }

        public decimal Expenses { get; set; }

        public DateTime Month { get; set; }
    }
}

