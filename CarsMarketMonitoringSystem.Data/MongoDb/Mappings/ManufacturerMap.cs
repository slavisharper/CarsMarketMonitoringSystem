namespace CarsMarketMonitoringSystem.Data.MongoDb.Mappings
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class ManufacturerMap
    {
        [BsonConstructor]
        public ManufacturerMap(int manufacturerId, string name, int locationId)
        {
            this.ManufacturerId = manufacturerId;
            this.Name = name;
            this.LocationId = locationId;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int ManufacturerId { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }
    }
}

