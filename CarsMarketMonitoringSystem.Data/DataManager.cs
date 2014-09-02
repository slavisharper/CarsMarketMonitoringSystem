namespace CarsMarketMonitoringSystem.Data
{
    using System;

    using CarsMarketMonitoringSystem.Models;
    using Excel;
    /// <summary>
    /// Class that controls getting and loading the data from outer
    /// sourses to the central MS SQL Server
    /// </summary>
    public class DataManager
    {
        private const string ExtractedFilesPath = "../../Extracted-reports";

        private CarsMarketDbContext dbContext;

        public DataManager()
        {
            this.DatabaseContex = new CarsMarketDbContext();
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

        public void ImportExelReports(string zipFilePath) 
        {
            var exelManager = new ExcelReportsManager(zipFilePath, ExtractedFilesPath, this.dbContext);
            exelManager.ImportSalesReport();
        }

        public void ImportDataFromMongoDb()
        {
            throw new NotImplementedException();
        }

        public void ImportManufacturersExpenses(string xmlFilePath)
        {
            throw new NotImplementedException();
        }
    }
}
