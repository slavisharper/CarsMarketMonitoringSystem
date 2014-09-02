namespace CarsMarketMonitoringSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seller
    {
        private ICollection<Car> cars;
        public Seller()
        {
            this.cars = new HashSet<Car>();
        }

        [Key]
        public int SellerId { get; set; }

        [MaxLength(50), MinLength(3), Required]
        public string Name { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Car> Cars 
        {
            get
            {
                return this.cars;
            }

            set
            {
                this.cars = value;
            }
        }
    }
}
