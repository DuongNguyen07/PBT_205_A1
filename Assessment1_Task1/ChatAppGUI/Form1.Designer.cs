namespace ChatAppGUI;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        TextUsername = new TextBox();
        label1 = new Label();
        label2 = new Label();
        Join_button = new Button();
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        ChatTextBox = new RichTextBox();
        label3 = new Label();
        MessageTextBox = new TextBox();
        Send_button = new Button();
        RoomBox = new ComboBox();
        SuspendLayout();
        // 
        // TextUsername
        // 
        TextUsername.Location = new Point(50, 52);
        TextUsername.Name = "TextUsername";
        TextUsername.Size = new Size(149, 27);
        TextUsername.TabIndex = 0;
        TextUsername.TextChanged += TextUsername_TextChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(50, 29);
        label1.Name = "label1";
        label1.Size = new Size(75, 20);
        label1.TabIndex = 2;
        label1.Text = "Username";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(261, 29);
        label2.Name = "label2";
        label2.Size = new Size(49, 20);
        label2.TabIndex = 3;
        label2.Text = "Room";
        // 
        // Join_button
        // 
        Join_button.Location = new Point(448, 52);
        Join_button.Name = "Join_button";
        Join_button.Size = new Size(94, 29);
        Join_button.TabIndex = 4;
        Join_button.Text = "Join";
        Join_button.UseVisualStyleBackColor = true;
        Join_button.Click += JoinButton_Click;
        // 
        // ChatTextBox
        // 
        ChatTextBox.Location = new Point(50, 125);
        ChatTextBox.Name = "ChatTextBox";
        ChatTextBox.ReadOnly = true;
        ChatTextBox.Size = new Size(615, 252);
        ChatTextBox.TabIndex = 6;
        ChatTextBox.Text = "";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(22, 392);
        label3.Name = "label3";
        label3.Size = new Size(42, 20);
        label3.TabIndex = 7;
        label3.Text = "Chat:";
        // 
        // MessageTextBox
        // 
        MessageTextBox.Location = new Point(70, 389);
        MessageTextBox.Name = "MessageTextBox";
        MessageTextBox.Size = new Size(472, 27);
        MessageTextBox.TabIndex = 8;
        MessageTextBox.KeyDown += TypeTextBox_KeyDown;
        // 
        // Send_button
        // 
        Send_button.Enabled = false;
        Send_button.Location = new Point(571, 389);
        Send_button.Name = "Send_button";
        Send_button.Size = new Size(94, 29);
        Send_button.TabIndex = 9;
        Send_button.Text = "Send";
        Send_button.UseVisualStyleBackColor = true;
        Send_button.Click += SendButton_Click;
        // 
        // RoomBox
        // 
        RoomBox.FormattingEnabled = true;
        RoomBox.Items.AddRange(new object[] { "General", "Sports", "Techology", "Gaming", "Food", "Travel", "Others" });
        RoomBox.Location = new Point(261, 51);
        RoomBox.Name = "RoomBox";
        RoomBox.Size = new Size(142, 28);
        RoomBox.TabIndex = 10;
        RoomBox.SelectedIndexChanged += RoomBox_SelectedIndexChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(RoomBox);
        Controls.Add(Send_button);
        Controls.Add(MessageTextBox);
        Controls.Add(label3);
        Controls.Add(ChatTextBox);
        Controls.Add(Join_button);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(TextUsername);
        Name = "Form1";
        Text = "Chat Application";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox TextUsername;
    private Label label1;
    private Label label2;
    private Button Join_button;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private RichTextBox ChatTextBox;
    private Label label3;
    private TextBox MessageTextBox;
    private Button Send_button;
    private ComboBox RoomBox;
}
