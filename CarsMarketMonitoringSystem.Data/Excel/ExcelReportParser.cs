namespace CarsMarketMonitoringSystem.Data.Excel
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;

    using CarsMarketMonitoringSystem.Models;
    using System.Data;

    public class ExcelReportParser
    {
        private const string DataProvider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        private const string ExtendedProperties = ";Extended Properties=\"Excel 12.0; HDR=Yes;IMEX=1\"";

        private string connectionString;
        private FileInfo file;

        public ExcelReportParser(FileInfo file)
        {
            this.connectionString = DataProvider + file.FullName + ExtendedProperties;
            this.file = file;
        }

        public IEnumerable<Sale> GetSalesReports()
        {
            var sales = this.ReadSalesData();
            return sales;
        }

        private HashSet<Sale> ReadSalesData()
        {
            var oleDbCon = new OleDbConnection(this.connectionString);
            var sales = new HashSet<Sale>();
            oleDbCon.Open();
            using (oleDbCon)
            {
                OleDbCommand readAllCommand = new OleDbCommand(
                    @"SELECT * FROM [Sales$B2:E]", oleDbCon);
                var reader = readAllCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var carId = reader["Pesho Cars Report"];
                        var sellerId = reader["F2"];
                        var date = reader["F3"];
                        var price = reader["F4"];

                        //var sale = new Sale()
                        //{
                        //    CarId = carId,
                        //    Date = date,
                        //    SellerId = sellerId,
                        //    Price = price
                        //};
                        //
                        //sales.Add(sale);
                    }
                }
            }

            return sales;
        }
    }
}
