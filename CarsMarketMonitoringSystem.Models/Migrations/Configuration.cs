namespace CarsMarketMonitoringSystem.Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarsMarketMonitoringSystem.Models.CarsMarketDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarsMarketMonitoringSystem.Models.CarsMarketDbContext context)
        {
           
        }
    }
}
