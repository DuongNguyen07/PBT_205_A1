using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.ExchangeAppGUI
{
    public class Order
    {
        public string Username { get; set; } = "";
        public string Side { get; set; } = "";
        public string StockSymbol { get; set; } = "";
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
