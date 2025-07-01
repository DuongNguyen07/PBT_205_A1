namespace SendOrderAppGUI
{
    public class Order
    {
        public string Username { get; set; } = "";
        public string Side { get; set; } = ""; // BUY or SELL
        public string StockSymbol { get; set; } = ""; 
        public int Quantity { get; set; } = 100; // Fixed
        public double Price { get; set; }
    }
}
