namespace CarsMarketMonitoringSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public decimal Expenses { get; set; }

        public DateTime Month { get; set; }
    }
}
