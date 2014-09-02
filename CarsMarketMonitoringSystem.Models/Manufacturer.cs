namespace CarsMarketMonitoringSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }

        [MaxLength(50), MinLength(3), Required]
        public string Name { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
