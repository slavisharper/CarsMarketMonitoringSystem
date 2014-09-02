namespace CarsMarketMonitoringSystem.Data
{
    using System;

    using CarsMarketMonitoringSystem.Models;

    /// <summary>
    /// Class that controls getting and loading the data from outer
    /// sourses to the central MS SQL Server
    /// </summary>
    public class DataManager
    {
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
            throw new NotImplementedException();
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
