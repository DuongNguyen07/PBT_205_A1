namespace ExchangeAppGUI;

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
        TradeDisplay = new RichTextBox();
        LatestPriceLabel = new Label();
        TradeDisplayLabel = new Label();
        BuyOrdersListbox = new ListBox();
        SellOrdersListbox = new ListBox();
        BuyOrdersLabel = new Label();
        SellOrdersLabel = new Label();
        StartButton = new Button();
        LatestPriceListbox = new ListBox();
        SuspendLayout();
        // 
        // TradeDisplay
        // 
        TradeDisplay.Location = new Point(285, 153);
        TradeDisplay.Name = "TradeDisplay";
        TradeDisplay.ReadOnly = true;
        TradeDisplay.Size = new Size(417, 264);
        TradeDisplay.TabIndex = 0;
        TradeDisplay.Text = "";
        // 
        // LatestPriceLabel
        // 
        LatestPriceLabel.AutoSize = true;
        LatestPriceLabel.ForeColor = Color.Red;
        LatestPriceLabel.Location = new Point(429, 9);
        LatestPriceLabel.Name = "LatestPriceLabel";
        LatestPriceLabel.Size = new Size(125, 20);
        LatestPriceLabel.TabIndex = 1;
        LatestPriceLabel.Text = "Latest Trade Price";
        // 
        // TradeDisplayLabel
        // 
        TradeDisplayLabel.AutoSize = true;
        TradeDisplayLabel.Location = new Point(429, 130);
        TradeDisplayLabel.Name = "TradeDisplayLabel";
        TradeDisplayLabel.Size = new Size(150, 20);
        TradeDisplayLabel.TabIndex = 3;
        TradeDisplayLabel.Text = "Trade History Display";
        // 
        // BuyOrdersListbox
        // 
        BuyOrdersListbox.FormattingEnabled = true;
        BuyOrdersListbox.Location = new Point(27, 153);
        BuyOrdersListbox.Name = "BuyOrdersListbox";
        BuyOrdersListbox.Size = new Size(207, 264);
        BuyOrdersListbox.TabIndex = 4;
        // 
        // SellOrdersListbox
        // 
        SellOrdersListbox.FormattingEnabled = true;
        SellOrdersListbox.Location = new Point(766, 153);
        SellOrdersListbox.Name = "SellOrdersListbox";
        SellOrdersListbox.Size = new Size(207, 264);
        SellOrdersListbox.TabIndex = 5;
        // 
        // BuyOrdersLabel
        // 
        BuyOrdersLabel.AutoSize = true;
        BuyOrdersLabel.Location = new Point(81, 130);
        BuyOrdersLabel.Name = "BuyOrdersLabel";
        BuyOrdersLabel.Size = new Size(81, 20);
        BuyOrdersLabel.TabIndex = 6;
        BuyOrdersLabel.Text = "Buy Orders";
        // 
        // SellOrdersLabel
        // 
        SellOrdersLabel.AutoSize = true;
        SellOrdersLabel.Location = new Point(831, 130);
        SellOrdersLabel.Name = "SellOrdersLabel";
        SellOrdersLabel.Size = new Size(81, 20);
        SellOrdersLabel.TabIndex = 7;
        SellOrdersLabel.Text = "Sell Orders";
        // 
        // StartButton
        // 
        StartButton.Location = new Point(458, 432);
        StartButton.Name = "StartButton";
        StartButton.Size = new Size(135, 51);
        StartButton.TabIndex = 2;
        StartButton.Text = "Start ";
        StartButton.UseVisualStyleBackColor = true;
        StartButton.Click += Button_Click;
        // 
        // LatestPriceListbox
        // 
        LatestPriceListbox.FormattingEnabled = true;
        LatestPriceListbox.Location = new Point(337, 43);
        LatestPriceListbox.Name = "LatestPriceListbox";
        LatestPriceListbox.Size = new Size(311, 84);
        LatestPriceListbox.TabIndex = 8;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1021, 517);
        Controls.Add(LatestPriceListbox);
        Controls.Add(SellOrdersLabel);
        Controls.Add(BuyOrdersLabel);
        Controls.Add(SellOrdersListbox);
        Controls.Add(BuyOrdersListbox);
        Controls.Add(TradeDisplayLabel);
        Controls.Add(StartButton);
        Controls.Add(LatestPriceLabel);
        Controls.Add(TradeDisplay);
        Name = "Form1";
        Text = "Exchange App";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RichTextBox TradeDisplay;
    private Label LatestPriceLabel;
    private Label TradeDisplayLabel;
    private ListBox BuyOrdersListbox;
    private ListBox SellOrdersListbox;
    private Label BuyOrdersLabel;
    private Label SellOrdersLabel;
    private Button StartButton;
    private ListBox LatestPriceListbox;
}
