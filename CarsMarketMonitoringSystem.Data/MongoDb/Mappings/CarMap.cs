namespace CarsMarketMonitoringSystem.Data.MongoDb.Mappings
{
    using System;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class CarMap
    {
        [BsonConstructor]
        public CarMap(int carId, string model, int manufacturerId, int topSpeed, int brakeHorsePower, decimal basePrice)
        {
            this.CarId = carId;
            this.Model = model;
            this.ManufacturerId = manufacturerId;
            this.TopSpeed = topSpeed;
            this.BrakeHorsePower = brakeHorsePower;
            this.BasePrice = basePrice;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int CarId { get; set; }

        public string Model { get; set; }

        public int ManufacturerId { get; set; }

        public int TopSpeed { get; set; }

        public int BrakeHorsePower { get; set; }

        public decimal BasePrice { get; set; }
    }
}
