using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.ExchangeAppGUI
{
    public class Trade
    {
        public string Buyer { get; set; } = "";
        public string Seller { get; set; } = "";
        public string StockSymbol { get; set; } = "";
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
