using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Diagnostics;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SendOrderAppGUI;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        ComboSide.Items.AddRange(new string[] { "BUY", "SELL" });
        ComboSide.SelectedIndex = 0;
        ComboStockSymbol.Items.AddRange(new string[] { "XYZ", "ABC", "MSFT", "AMZN" });
        ComboStockSymbol.SelectedIndex = 0;
    }
    private void ButtonSend_Click(object sender, EventArgs e)
    {
        string username = TextUsername.Text.Trim();
        string side = ComboSide.SelectedItem?.ToString() ?? "";
        string stockSymbol = ComboStockSymbol.SelectedItem?.ToString() ?? "";
        double price = (double)PriceInput.Value;
        if (string.IsNullOrEmpty(username))
        {
            MessageBox.Show("Please enter an username.");
            return;
        }
        var order = new Order
        {
            Username = username,
            Side = side,
            StockSymbol = stockSymbol,
            Quantity = 100, // fixed
            Price = price
        };
        try
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "Orders", type: ExchangeType.Fanout);
            string message = JsonConvert.SerializeObject(order);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "Orders", routingKey: "", basicProperties: null, body: body);
            MessageBox.Show("Order sent successfully!");
            StatusLabel.ForeColor = Color.Green;
            StatusLabel.Text = $"Order sent: {order.Side} {order.Quantity} {order.StockSymbol} at {order.Price}$ by {order.Username}";
        }
        catch (Exception ex)
        {
            StatusLabel.ForeColor = Color.Red;
            StatusLabel.Text = "Error: " + ex.Message;
        }
    }

    private void Price_Click(object sender, EventArgs e)
    {

    }
}
