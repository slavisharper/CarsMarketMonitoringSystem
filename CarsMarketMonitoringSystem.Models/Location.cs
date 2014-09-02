namespace CarsMarketMonitoringSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [MaxLength(50), Required]
        public string Town { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }
    }
}
