namespace CarsMarketMonitoringSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seller
    {
        private ICollection<Sale> sales;

        public Seller()
        {
            this.sales = new HashSet<Sale>();
        }

        [Key]
        public int SellerId { get; set; }

        [MaxLength(50), MinLength(3), Required]
        public string Name { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }
    }
}
