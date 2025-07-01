using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ChatAppGUI
{
    public partial class Form1 : Form
    {
        private IConnection? connection;
        private IModel? channel;
        private string? exchangeName;
        private string? queueName;
        private string? username;

        public Form1()
        {
            InitializeComponent();
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            username = TextUsername.Text.Trim();
            string room = RoomBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(room))
            {
                System.Windows.Forms.MessageBox.Show("Please enter both a username and room name.");
                return;
            }

            exchangeName = $"chat-{room}";
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Fanout);
            queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: "");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                Invoke(new Action(() =>
                {
                    ChatTextBox.AppendText(message + Environment.NewLine);
                    ChatTextBox.ScrollToCaret();
                }));
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            Join_button.Enabled = false;
            TextUsername.Enabled = false;
            RoomBox.Enabled = false;
            Send_button.Enabled = true;
            ChatTextBox.Clear();
            MessageTextBox.Focus();
            this.Text = $"Chat Apllication - {username} in Room: {room}";
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (channel == null || string.IsNullOrEmpty(exchangeName) || string.IsNullOrEmpty(username)) return;

            string input = MessageTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            string fullMessage = $"[{username}]: {input}";
            var body = Encoding.UTF8.GetBytes(fullMessage);

            channel.BasicPublish(exchange: exchangeName,
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);

            MessageTextBox.Clear();
        }
        private void TypeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendButton_Click(this, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                channel?.Close();
                connection?.Close();
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e) {
            
        }
        private void TextUsername_TextChanged(object sender, EventArgs e) { }

        private void RoomBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
