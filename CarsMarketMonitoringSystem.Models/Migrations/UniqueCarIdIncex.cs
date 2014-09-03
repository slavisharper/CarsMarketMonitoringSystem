namespace CarsMarketMonitoringSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UniqueCarIdIncex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Sales", "CarId", true);
        }

        public override void Down()
        {
            DropIndex("dbo.Sales", "CarId");
        }
    }

}
