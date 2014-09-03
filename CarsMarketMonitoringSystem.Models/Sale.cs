namespace CarsMarketMonitoringSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public int SellerId { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
