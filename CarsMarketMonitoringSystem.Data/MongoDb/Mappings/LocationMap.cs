namespace CarsMarketMonitoringSystem.Data.MongoDb.Mappings
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class LocationMap
    {
        [BsonConstructor]
        public LocationMap(int locationId, string town, string address)
        {
            this.LocationId = locationId;
            this.Town = town;
            this.Address = address;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int LocationId { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }
    }
}
