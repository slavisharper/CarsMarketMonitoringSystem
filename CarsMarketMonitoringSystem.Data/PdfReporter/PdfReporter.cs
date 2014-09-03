using CarsMarketMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsMarketMonitoringSystem.Data.PdfReporter
{
    public class PdfReporter
    {
        private CarsMarketDbContext database;

        public PdfReporter(CarsMarketDbContext database)
        {
            this.database = database;
        }

        public void GenerateReportsForMonth(int year, int month)
        {
            var sales = this.database.Sales
                //.Where(s => s.Date.Year == year && s.Date.Month == month)
                .GroupBy(s => s.SaleId).ToList();
            
        }
    }
}
