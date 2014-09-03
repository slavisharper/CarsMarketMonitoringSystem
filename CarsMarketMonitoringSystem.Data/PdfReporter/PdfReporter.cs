using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsMarketMonitoringSystem.Data.PdfReporter
{
    public class PdfReporter
    {
        private DataManager manager;

        public PdfReporter(DataManager manager)
        {
            this.manager = manager;
        }

        public void GenerateReportsForMonth(int year, int month)
        {
            var sales = this.manager.DatabaseContex.Sales
                .Where(s => s.Date.Year == year && s.Date.Month == month)
                .GroupBy(s => s.SaleId);
            
        }
    }
}
