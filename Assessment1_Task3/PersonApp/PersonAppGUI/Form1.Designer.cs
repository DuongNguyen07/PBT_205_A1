namespace PersonAppGUI;

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
        UsernameTextbox = new TextBox();
        UsernameLabel = new Label();
        NumericSpeed = new NumericUpDown();
        SpeedLabel = new Label();
        StartButton = new Button();
        LogBox = new RichTextBox();
        ((System.ComponentModel.ISupportInitialize)NumericSpeed).BeginInit();
        SuspendLayout();
        // 
        // UsernameTextbox
        // 
        UsernameTextbox.Location = new Point(144, 98);
        UsernameTextbox.Name = "UsernameTextbox";
        UsernameTextbox.Size = new Size(136, 27);
        UsernameTextbox.TabIndex = 0;
        // 
        // UsernameLabel
        // 
        UsernameLabel.AutoSize = true;
        UsernameLabel.Location = new Point(144, 74);
        UsernameLabel.Name = "UsernameLabel";
        UsernameLabel.Size = new Size(75, 20);
        UsernameLabel.TabIndex = 1;
        UsernameLabel.Text = "Username";
        // 
        // NumericSpeed
        // 
        NumericSpeed.Location = new Point(351, 98);
        NumericSpeed.Name = "NumericSpeed";
        NumericSpeed.Size = new Size(138, 27);
        NumericSpeed.TabIndex = 2;
        // 
        // SpeedLabel
        // 
        SpeedLabel.AutoSize = true;
        SpeedLabel.Location = new Point(351, 74);
        SpeedLabel.Name = "SpeedLabel";
        SpeedLabel.Size = new Size(179, 20);
        SpeedLabel.TabIndex = 3;
        SpeedLabel.Text = "Speed (move per second)";
        // 
        // StartButton
        // 
        StartButton.Location = new Point(592, 97);
        StartButton.Name = "StartButton";
        StartButton.Size = new Size(134, 39);
        StartButton.TabIndex = 6;
        StartButton.Text = "Start";
        StartButton.UseVisualStyleBackColor = true;
        StartButton.Click += StartButton_Click;
        // 
        // LogBox
        // 
        LogBox.Location = new Point(144, 169);
        LogBox.Name = "LogBox";
        LogBox.Size = new Size(582, 288);
        LogBox.TabIndex = 7;
        LogBox.Text = "";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(876, 492);
        Controls.Add(LogBox);
        Controls.Add(StartButton);
        Controls.Add(SpeedLabel);
        Controls.Add(NumericSpeed);
        Controls.Add(UsernameLabel);
        Controls.Add(UsernameTextbox);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)NumericSpeed).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox UsernameTextbox;
    private Label UsernameLabel;
    private NumericUpDown NumericSpeed;
    private Label SpeedLabel;
    private Button StartButton;
    private RichTextBox LogBox;
}
