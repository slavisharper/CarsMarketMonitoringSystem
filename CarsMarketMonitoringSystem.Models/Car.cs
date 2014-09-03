namespace CarsMarketMonitoringSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [MaxLength(50), Required]
        public string Model { get; set; }

        [ForeignKey("Manufacturer"), Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public int TopSpeed { get; set; }

        public int BrakeHorsePower { get; set; }

        [Required]
        public decimal BasePrice { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public virtual Seller Seller {get; set;}
    }
}
