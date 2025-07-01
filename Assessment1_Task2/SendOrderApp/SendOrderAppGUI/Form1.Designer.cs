namespace SendOrderAppGUI;

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
        ComboSide = new ComboBox();
        SideLabel = new Label();
        PriceInput = new NumericUpDown();
        PriceLabel = new Label();
        SendButton = new Button();
        label4 = new Label();
        StatusLabel = new Label();
        ComboStockSymbol = new ComboBox();
        StockSymbolLabel = new Label();
        ((System.ComponentModel.ISupportInitialize)PriceInput).BeginInit();
        SuspendLayout();
        // 
        // TextUsername
        // 
        TextUsername.Location = new Point(35, 164);
        TextUsername.Name = "TextUsername";
        TextUsername.Size = new Size(137, 27);
        TextUsername.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(35, 141);
        label1.Name = "label1";
        label1.Size = new Size(75, 20);
        label1.TabIndex = 1;
        label1.Text = "Username";
        // 
        // ComboSide
        // 
        ComboSide.FormattingEnabled = true;
        ComboSide.Location = new Point(199, 164);
        ComboSide.Name = "ComboSide";
        ComboSide.Size = new Size(151, 28);
        ComboSide.TabIndex = 2;
        // 
        // SideLabel
        // 
        SideLabel.AutoSize = true;
        SideLabel.Location = new Point(199, 142);
        SideLabel.Name = "SideLabel";
        SideLabel.Size = new Size(38, 20);
        SideLabel.TabIndex = 3;
        SideLabel.Text = "Side";
        // 
        // PriceInput
        // 
        PriceInput.DecimalPlaces = 1;
        PriceInput.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        PriceInput.Location = new Point(593, 165);
        PriceInput.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        PriceInput.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
        PriceInput.Name = "PriceInput";
        PriceInput.Size = new Size(150, 27);
        PriceInput.TabIndex = 9;
        PriceInput.Value = new decimal(new int[] { 1, 0, 0, 65536 });
        // 
        // PriceLabel
        // 
        PriceLabel.AutoSize = true;
        PriceLabel.Location = new Point(593, 142);
        PriceLabel.Name = "PriceLabel";
        PriceLabel.Size = new Size(41, 20);
        PriceLabel.TabIndex = 5;
        PriceLabel.Text = "Price";
        PriceLabel.Click += Price_Click;
        // 
        // SendButton
        // 
        SendButton.Location = new Point(297, 257);
        SendButton.Name = "SendButton";
        SendButton.Size = new Size(187, 48);
        SendButton.TabIndex = 6;
        SendButton.Text = "Send Order";
        SendButton.UseVisualStyleBackColor = true;
        SendButton.Click += ButtonSend_Click;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(184, 343);
        label4.Name = "label4";
        label4.Size = new Size(0, 20);
        label4.TabIndex = 7;
        // 
        // StatusLabel
        // 
        StatusLabel.AutoSize = true;
        StatusLabel.ForeColor = Color.IndianRed;
        StatusLabel.Location = new Point(246, 343);
        StatusLabel.Name = "StatusLabel";
        StatusLabel.Size = new Size(288, 20);
        StatusLabel.TabIndex = 8;
        StatusLabel.Text = "Order Status: No order have been sent yet.";
        // 
        // ComboStockSymbol
        // 
        ComboStockSymbol.FormattingEnabled = true;
        ComboStockSymbol.Location = new Point(401, 165);
        ComboStockSymbol.Name = "ComboStockSymbol";
        ComboStockSymbol.Size = new Size(151, 28);
        ComboStockSymbol.TabIndex = 10;
        // 
        // StockSymbolLabel
        // 
        StockSymbolLabel.AutoSize = true;
        StockSymbolLabel.Location = new Point(401, 142);
        StockSymbolLabel.Name = "StockSymbolLabel";
        StockSymbolLabel.Size = new Size(99, 20);
        StockSymbolLabel.TabIndex = 11;
        StockSymbolLabel.Text = "Stock Symbol";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(StockSymbolLabel);
        Controls.Add(ComboStockSymbol);
        Controls.Add(StatusLabel);
        Controls.Add(label4);
        Controls.Add(SendButton);
        Controls.Add(PriceLabel);
        Controls.Add(PriceInput);
        Controls.Add(SideLabel);
        Controls.Add(ComboSide);
        Controls.Add(label1);
        Controls.Add(TextUsername);
        Name = "Form1";
        Text = "SendOrderApp";
        ((System.ComponentModel.ISupportInitialize)PriceInput).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox TextUsername;
    private Label label1;
    private ComboBox ComboSide;
    private Label SideLabel;
    private NumericUpDown PriceInput;
    private Label PriceLabel;
    private Button SendButton;
    private Label label4;
    private Label StatusLabel;
    private ComboBox ComboStockSymbol;
    private Label StockSymbolLabel;
}
