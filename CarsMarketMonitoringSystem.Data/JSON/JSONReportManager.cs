using CarsMarketMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace CarsMarketMonitoringSystem.Data.JSON
{
    public class JSONReportManager
    {
        public void GenerateJSONReports(IEnumerable<Sale> sales, string path)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            foreach (var sale in sales)
            {
                Sale tempSale = new Sale();

                tempSale.SaleId = sale.SaleId;
                tempSale.CarId = sale.CarId;
                tempSale.SellerId = sale.SellerId;
                tempSale.Price = sale.Price;
                tempSale.Date = sale.Date;


                string jsonSale = JsonConvert.SerializeObject(tempSale);
                //write string to file
                string finalPath = String.Format(@"{0}\{1}.json", path, sale.SaleId);
                System.IO.File.WriteAllText(finalPath, jsonSale);
            }
        }

    }
}
