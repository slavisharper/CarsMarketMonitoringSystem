namespace CarsMarketMonitoringSystem.Data.MongoDb.Mappings
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Collections.Generic;
    using CarsMarketMonitoringSystem.Models;

    public class SellerMap
    {
        [BsonConstructor]
        public SellerMap(int sellerId, string name, int locationId, ICollection<Car> cars = null)
        {
            this.SellerId = sellerId;
            this.Name = name;
            this.LocationId = locationId;
            this.Cars = cars;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int SellerId { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }

        public ICollection<Car> Cars { get; set; }

    }
}

