namespace CarsMarketMonitoringSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using CarsMarketMonitoringSystem.Models.Migrations;

    public class CarsMarketDbContext : DbContext
    {
        public CarsMarketDbContext()
            : base("CarsMarketDatabase")
        {
            Database.SetInitializer(
                    new MigrateDatabaseToLatestVersion<CarsMarketDbContext, Configuration>()); //
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Seller> Sellers { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .HasRequired(l => l.Location)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seller>()
                .HasRequired(s => s.Location)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}