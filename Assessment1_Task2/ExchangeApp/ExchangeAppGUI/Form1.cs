using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Collections.Generic;
using ExchangeApp.ExchangeAppGUI;

namespace ExchangeAppGUI;

public partial class Form1 : Form
{
    private List<Order> buyOrders = new();
    private List<Order> sellOrders = new();
    private IConnection? connection;
    private IModel? channel;
    public Form1()
    {
        InitializeComponent();
    }
    private void Button_Click(object sender, EventArgs e)
    {
        StartButton.Enabled = false;
        ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };
        connection = factory.CreateConnection();
        channel = connection.CreateModel();
        channel.ExchangeDeclare("Orders", ExchangeType.Fanout);
        channel.ExchangeDeclare("Trades", ExchangeType.Fanout);
        string queueName = channel.QueueDeclare().QueueName;
        channel.QueueBind(queueName, "Orders", "");
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += OrderReceived;
        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        TradeDisplay.AppendText("Exchange started and listening for orders...\n");
    }
    private void OrderReceived(object? sender, BasicDeliverEventArgs e)
    {
        string message = Encoding.UTF8.GetString(e.Body.ToArray());
        Order order = JsonConvert.DeserializeObject<Order>(message);
        if (order == null)
        {
            return;
        }
        Invoke(() => TradeDisplay.AppendText($"Received {order.Side} {order.Quantity} {order.StockSymbol} at {order.Price}$ by {order.Username}\n"));
        if (order.Side == "BUY")
        {
            MatchOrder(order, sellOrders, buyOrders, isBuy: true);
        }
        else if (order.Side == "SELL")
        {
            MatchOrder(order, buyOrders, sellOrders, isBuy: false);
        }
    }
    private void MatchOrder(Order incomingOrder, List<Order> oppositeBook, List<Order> sameBook, bool isBuy)
    {
        var match = oppositeBook.FirstOrDefault(o => o.StockSymbol == incomingOrder.StockSymbol && (isBuy ? o.Price <= incomingOrder.Price : o.Price >= incomingOrder.Price));
        if (match != null)
        {
            oppositeBook.Remove(match);
            var Trade = new Trade
            {
                Buyer = isBuy ? incomingOrder.Username : match.Username,
                Seller = isBuy ? match.Username : incomingOrder.Username,
                Quantity = Math.Min(incomingOrder.Quantity, match.Quantity),
                Price = isBuy ? match.Price : incomingOrder.Price,
                StockSymbol = incomingOrder.StockSymbol
            };
            string tradeMessage = JsonConvert.SerializeObject(Trade);
            byte[] body = Encoding.UTF8.GetBytes(tradeMessage);
            channel.BasicPublish("Trade", "", null, body);
            Invoke(() =>
            {
                TradeDisplay.AppendText($"Trade executed: {Trade.Buyer} bought {Trade.Quantity} {Trade.StockSymbol} at @ {Trade.Price} from {Trade.Seller}\n");
                TradeDisplay.ScrollToCaret();
                LatestPriceListbox.Items.Add($"{Trade.StockSymbol}: {Trade.Price}$");
                buyOrders.RemoveAll(o => o.Username == Trade.Buyer && o.StockSymbol == Trade.StockSymbol && o.Price == Trade.Price);
                sellOrders.RemoveAll(o => o.Username == Trade.Seller && o.StockSymbol == Trade.StockSymbol && o.Price == Trade.Price);
                UpdateOrderBooks();
            });
        }
        else
        {
            sameBook.Add(incomingOrder);
            sameBook.Sort((x, y) => isBuy ? y.Price.CompareTo(x.Price) : x.Price.CompareTo(y.Price));
            UpdateOrderBooks();
        }
    }
    private void UpdateOrderBooks()
    {
        Invoke(() =>
        {
            BuyOrdersListbox.Items.Clear();
            foreach (var order in buyOrders)
            {
                BuyOrdersListbox.Items.Add($"BUY {order.Quantity} {order.StockSymbol} at {order.Price}$ ({order.Username})");
            }

            SellOrdersListbox.Items.Clear();
            foreach (var order in sellOrders)
            {
                SellOrdersListbox.Items.Add($"SELL {order.Quantity} {order.StockSymbol} at {order.Price}$ ({order.Username})");
            }
        });
    }

    private void LatestPriceLabel_Click(object sender, EventArgs e)
    {

    }
}
