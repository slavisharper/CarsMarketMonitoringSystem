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
        private const string ExtendedProperties = ";Extended Properties=\"Excel 12.0; HDR=No\"";

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
                var readTable = new OleDbCommand("SELECT * FROM [Sales$B4:E]", oleDbCon);
                var reader = readTable.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int carId = int.Parse(reader[0].ToString());
                        int sellerId = int.Parse(reader[1].ToString());
                        DateTime date = (DateTime)reader[2];
                        decimal price = decimal.Parse(reader[3].ToString());

                        var sale = new Sale()
                        {
                            CarId = carId,
                            Date = date,
                            SellerId = sellerId,
                            Price = price
                        };
                        
                        sales.Add(sale);
                    }
                }
            }

            return sales;
        }
    }
}
