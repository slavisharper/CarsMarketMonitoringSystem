using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MySQLConnector
{
    public class SaleModel
    {
        public int SaleId { get; set; }

        public int CarId { get; set; }

        public int SellerId { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
