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
    }
}
