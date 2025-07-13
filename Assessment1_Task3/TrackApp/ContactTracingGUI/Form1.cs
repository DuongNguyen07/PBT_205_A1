using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;

namespace ContactTracingGUI;

public partial class Form1 : Form
{
    private int GridSize = 10; 
    private int CellSize => GridPanel.Width / GridSize;
    private Dictionary<string, Point> usersPositions = new Dictionary<string, Point>();
    private Dictionary<string, List<string>> usersContacts = new Dictionary<string, List<string>>();
    private Dictionary<string, HashSet<string>> contactLog = new();
    private IModel? channel;
    private IConnection? connection;
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
        SetUpGridPanel();
        InitializeRabbitMQ();
        SetDoubleBuffered(GridPanel);
        NumericBoardSize.Value = GridSize;
    }
    private void SetDoubleBuffered(Control control)
    {
        typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(control, true, null);
    }
    private void SetUpGridPanel()
    {
        GridPanel.Paint += (s, e) =>
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            g.Clear(GridPanel.BackColor);
            var pen = Pens.Black;
            float width = GridPanel.Width;
            float height = GridPanel.Height;
            float cellWidth = width / GridSize;
            float cellHeight = height / GridSize;
            for (int i = 0; i <= GridSize; i++)
            {
                float x = i * cellWidth;
                if (x >= width) x = width - 1; 
                g.DrawLine(pen, x, 0, x, height - 1);
            }
            for (int i = 0; i <= GridSize; i++)
            {
                float y = i * cellHeight;
                if (y >= height) y = height - 1; 
                g.DrawLine(pen, 0, y, width - 1, y);
            }
            foreach (var user in usersPositions)
            {
                var name = user.Key;
                if (name == "") continue;
                var point = user.Value;
                var rect = new RectangleF((point.X - 1) * cellWidth, (point.Y - 1) * cellHeight, cellWidth, cellHeight);
                g.FillRectangle(Brushes.Blue, rect);
                float fontSize = Math.Max(Math.Min(cellWidth, cellHeight) / 5f, 6f);
                using var font = new Font("Arial", fontSize, FontStyle.Bold);
                var textSize = g.MeasureString(name, font);
                var textX = rect.X + (cellWidth - textSize.Width) / 2;
                var textY = rect.Y + (cellHeight - textSize.Height) / 2;

                g.DrawString(name, font, Brushes.White, textX, textY);

            }
        };


    }

    private void NumericGridSize_ValueChanged(object sender, EventArgs e)
    {
        GridSize = (int)NumericBoardSize.Value;
        GridPanel.Invalidate();
    }
    private void StartButton_Click(object sender, EventArgs e)
    {
        NumericGridSize_ValueChanged(sender, e);
        StartButton.Enabled = false;
    }

    private void InitializeRabbitMQ()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        connection = factory.CreateConnection();
        channel = connection.CreateModel();
        channel.ExchangeDeclare("position", ExchangeType.Fanout);
        channel.ExchangeDeclare("query", ExchangeType.Fanout);
        channel.ExchangeDeclare("query-response", ExchangeType.Fanout);
        var queueName = channel.QueueDeclare().QueueName;
        channel.QueueBind(queueName, "position", "");
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += Position_Received;
        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
    }
    private void Position_Received(object? sender, BasicDeliverEventArgs e)
    {
        var message = Encoding.UTF8.GetString(e.Body.ToArray());
        var pos = JsonConvert.DeserializeObject<PositionMessage>(message);
        if (pos == null) return;

        Invoke(() =>
        {
            if (string.IsNullOrEmpty(pos.Name))
            {
                if (pos.BoardSize != GridSize && pos.BoardSize > 0)
                {
                    GridSize = pos.BoardSize;
                    GridPanel.Invalidate();
                }
                return;
            }

            var point = new Point(pos.X, pos.Y);
            if (!usersPositions.ContainsKey(pos.Name) || usersPositions[pos.Name] != point)
            {
                usersPositions[pos.Name] = point;
                foreach (var other in usersPositions)
                {
                    if (other.Key != pos.Name && other.Value == point)
                    {
                        contactLog.TryAdd(pos.Name, new());
                        contactLog[pos.Name].Add(other.Key);

                        contactLog.TryAdd(other.Key, new());
                        contactLog[other.Key].Add(pos.Name);
                    }
                }
            }
            GridPanel.Invalidate();
        });
    }

    private void QueryButton_Click(object sender, EventArgs e)
    {
        var targetUsername = QuerryBox.Text.Trim();
        ContactListbox.Items.Clear();
        if (string.IsNullOrEmpty(targetUsername) || !usersPositions.ContainsKey(targetUsername))
        {
            ContactListbox.Items.Clear();
            MessageBox.Show("User not found.");
            return;
        }
        if (contactLog.TryGetValue(targetUsername, out var contacts) && contacts.Any())
        {
            foreach (var name in contacts)
            {
                ContactListbox.Items.Add(name);
            }
        }
        else
        {
            ContactListbox.Items.Add("No contacts found.");
        }
    }

    private void UsernameLabel_Click(object sender, EventArgs e)
    {

    }
}
