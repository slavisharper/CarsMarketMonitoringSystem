namespace CarsMarketMonitoringSystem.Data
{
    using System;

    using CarsMarketMonitoringSystem.Models;
    using CarsMarketMonitoringSystem.Data.MongoDb;
    using Excel;
    using JSON;
    using MySQL;
    using System.Collections.Generic;
    using CarsMarketMonitoringSystem.MySqlConnector;

    /// <summary>
    /// Class that controls getting and loading the data from outer
    /// sourses to the central MS SQL Server
    /// </summary>
    public class DataManager
    {
        private const string ExtractedFilesPath = "../../Extracted-reports";
        private const string ConnectionStringMongoDb = "mongodb://localhost";
        private const string DatabaseNameMongoDb = "CarsMarketMonitoringSystem";

        private CarsMarketDbContext dbContext;
        private MongoDbContext mongoDbContext;

        public DataManager()
        {
            this.DatabaseContex = new CarsMarketDbContext();
            this.MongoDbContext = new MongoDbContext(ConnectionStringMongoDb, DatabaseNameMongoDb);
        }

        public CarsMarketDbContext DatabaseContex 
        {
            get
            {
                return this.dbContext;
            }

            private set
            {
                this.dbContext = value;
            }
        }

        public MongoDbContext MongoDbContext
        {
            get
            {
                return this.mongoDbContext;
            }

            private set
            {
                this.mongoDbContext = value;
            }
        }

        public void ImportExelReports(string zipFilePath) 
        {
            var exelManager = new ExcelReportsManager(zipFilePath, ExtractedFilesPath, this.dbContext);
            exelManager.ImportSalesReport();
        }

        public void ImportDataFromMongoDb()
        {
            var mongoDbSeeder = new MongoDbManager(this.dbContext, this.mongoDbContext);
            mongoDbSeeder.ImportData();
        }

        public void ImportManufacturersExpenses(string xmlFilePath)
        {
            throw new NotImplementedException();
        }

        public void ExportJSONReports(IEnumerable<Sale> sales)
        {
            var jsonManager = new JSONReportManager();
            jsonManager.GenerateJSONReports(sales, "../../Generated-reports");
        }

        public void ExportDataToMySQL(IEnumerable<SaleModel> sales) 
        {
            var sqlManager = new MySQLReportsManager();
            sqlManager.UpdateDatabase();
            sqlManager.AddSales(sales);
            
        }

        public void ExpordPDFReports()
        { 
        }
    }
}
