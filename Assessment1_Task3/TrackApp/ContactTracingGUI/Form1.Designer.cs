namespace ContactTracingGUI;

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
        GridPanel = new Panel();
        QuerryBox = new TextBox();
        UsernameLabel = new Label();
        QueryButton = new Button();
        ContactListbox = new ListBox();
        label1 = new Label();
        NumericBoardSize = new NumericUpDown();
        BoardSizeLabel = new Label();
        StartButton = new Button();
        ((System.ComponentModel.ISupportInitialize)NumericBoardSize).BeginInit();
        SuspendLayout();
        // 
        // GridPanel
        // 
        GridPanel.Location = new Point(31, 22);
        GridPanel.Name = "GridPanel";
        GridPanel.Size = new Size(550, 550);
        GridPanel.TabIndex = 0;
        // 
        // QuerryBox
        // 
        QuerryBox.Location = new Point(615, 198);
        QuerryBox.Name = "QuerryBox";
        QuerryBox.Size = new Size(173, 27);
        QuerryBox.TabIndex = 1;
        // 
        // UsernameLabel
        // 
        UsernameLabel.AutoSize = true;
        UsernameLabel.Location = new Point(615, 175);
        UsernameLabel.Name = "UsernameLabel";
        UsernameLabel.Size = new Size(75, 20);
        UsernameLabel.TabIndex = 2;
        UsernameLabel.Text = "Username";
        UsernameLabel.Click += UsernameLabel_Click;
        // 
        // QueryButton
        // 
        QueryButton.Location = new Point(658, 231);
        QueryButton.Name = "QueryButton";
        QueryButton.Size = new Size(94, 29);
        QueryButton.TabIndex = 3;
        QueryButton.Text = "Query";
        QueryButton.UseVisualStyleBackColor = true;
        QueryButton.Click += QueryButton_Click;
        // 
        // ContactListbox
        // 
        ContactListbox.FormattingEnabled = true;
        ContactListbox.Location = new Point(614, 299);
        ContactListbox.Name = "ContactListbox";
        ContactListbox.Size = new Size(232, 244);
        ContactListbox.TabIndex = 4;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(614, 263);
        label1.Name = "label1";
        label1.Size = new Size(110, 20);
        label1.TabIndex = 5;
        label1.Text = "Contacted User";
        // 
        // NumericBoardSize
        // 
        NumericBoardSize.Location = new Point(614, 58);
        NumericBoardSize.Name = "NumericBoardSize";
        NumericBoardSize.Size = new Size(150, 27);
        NumericBoardSize.TabIndex = 6;
        // 
        // BoardSizeLabel
        // 
        BoardSizeLabel.AutoSize = true;
        BoardSizeLabel.Location = new Point(614, 35);
        BoardSizeLabel.Name = "BoardSizeLabel";
        BoardSizeLabel.Size = new Size(76, 20);
        BoardSizeLabel.TabIndex = 7;
        BoardSizeLabel.Text = "BoardSize";
        // 
        // StartButton
        // 
        StartButton.Location = new Point(614, 101);
        StartButton.Name = "StartButton";
        StartButton.Size = new Size(110, 34);
        StartButton.TabIndex = 8;
        StartButton.Text = "Start";
        StartButton.UseVisualStyleBackColor = true;
        StartButton.Click += StartButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(875, 592);
        Controls.Add(StartButton);
        Controls.Add(BoardSizeLabel);
        Controls.Add(NumericBoardSize);
        Controls.Add(label1);
        Controls.Add(ContactListbox);
        Controls.Add(QueryButton);
        Controls.Add(UsernameLabel);
        Controls.Add(QuerryBox);
        Controls.Add(GridPanel);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)NumericBoardSize).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel GridPanel;
    private TextBox QuerryBox;
    private Label UsernameLabel;
    private Button QueryButton;
    private ListBox ContactListbox;
    private Label label1;
    private NumericUpDown NumericBoardSize;
    private Label BoardSizeLabel;
    private Button StartButton;
}
