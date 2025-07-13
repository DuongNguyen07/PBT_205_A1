using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
namespace PersonAppGUI;

public partial class Form1 : Form
{
    private IConnection? connection;
    private IModel? channel;
    private readonly Random random = new Random();
    private int posX, posY;
    private string userName = "";
    private int currentBoardSize = 10;
    public class PositionMessage
    {
        public string Name { get; set; } = "";
        public int X { get; set; }
        public int Y { get; set; }
        public int BoardSize { get; set; }
    }
    public Form1()
    {
        InitializeComponent();
        NumericSpeed.Value = 1;
    }
    private void StartButton_Click(object sender, EventArgs e)
    {
        userName = UsernameTextbox.Text.Trim();
        if (string.IsNullOrEmpty(userName))
        {
            MessageBox.Show("Enter a username");
            return;
        }
        var factory = new ConnectionFactory() { HostName = "localhost" };
        connection = factory.CreateConnection();
        channel = connection.CreateModel();
        channel.ExchangeDeclare("position", ExchangeType.Fanout, durable: false);
        var queueName = channel.QueueDeclare().QueueName;
        channel.QueueBind(queueName, "position", "");
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (s, ea) =>
        {
            var message = Encoding.UTF8.GetString(ea.Body.ToArray());
            var pos = JsonConvert.DeserializeObject<PositionMessage>(message);
            if (pos?.Name == userName) return; 

            currentBoardSize = pos?.BoardSize ?? currentBoardSize;
        };
        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        Task.Run(async () =>
        {
            Invoke(() =>
            {
                posX = random.Next(1, currentBoardSize+1);
                posY = random.Next(1, currentBoardSize+1);
                SendPosition();
                LogBox.AppendText($"Started as '{userName}' at ({posX},{posY})\n");
            });

            while (true)
            {
                BeginInvoke(() => MoveRandom());
                await Task.Delay((int)NumericSpeed.Value * 1000);
            }
        });
        StartButton.Enabled = false;
    }
    private void SendPosition()
    {
        var message = new PositionMessage
        {
            Name = userName,
            X = posX,
            Y = posY,
            BoardSize = currentBoardSize
        };

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);
        channel?.BasicPublish("position", "", null, body);
    }
    private void MoveRandom()
    {
        if (currentBoardSize <= 0) return;
        int dx = random.Next(-1, 2); // -1, 0, or 1
        int dy = random.Next(-1, 2);
        posX = Math.Clamp(posX + dx, 1, currentBoardSize);
        posY = Math.Clamp(posY + dy, 1, currentBoardSize);
        SendPosition(); // Broadcast new position
        LogBox.AppendText($"Moved to ({posX},{posY})\n");
        LogBox.ScrollToCaret();
    }


}
