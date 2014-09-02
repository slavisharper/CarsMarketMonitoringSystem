namespace CarsMarketMonitoringSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Expense
    {
        [Key]
        public int ExpenceId { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public decimal Expences { get; set; }

        public DateTime Month { get; set; }
    }
}
