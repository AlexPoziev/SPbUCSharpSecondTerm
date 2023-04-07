namespace Calculator
{
    partial class Calculator
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
            OperationsTable = new TableLayoutPanel();
            DotButton = new Button();
            ZeroButton = new Button();
            ThreeButton = new Button();
            TwoButton = new Button();
            OneButton = new Button();
            SixButton = new Button();
            FiveButton = new Button();
            FourButton = new Button();
            NineButton = new Button();
            EightButton = new Button();
            SevenButton = new Button();
            DeleteSymbolButton = new Button();
            ClearButton = new Button();
            EqualityButton = new Button();
            PlusButton = new Button();
            button3 = new Button();
            MultiplyButton = new Button();
            DivideButton = new Button();
            PercentButton = new Button();
            ConveyorPanel = new Panel();
            ExpressionConveyor = new Label();
            OperationsTable.SuspendLayout();
            ConveyorPanel.SuspendLayout();
            SuspendLayout();
            // 
            // OperationsTable
            // 
            OperationsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OperationsTable.ColumnCount = 4;
            OperationsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            OperationsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            OperationsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            OperationsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            OperationsTable.Controls.Add(DotButton, 2, 4);
            OperationsTable.Controls.Add(ZeroButton, 0, 4);
            OperationsTable.Controls.Add(ThreeButton, 2, 3);
            OperationsTable.Controls.Add(TwoButton, 1, 3);
            OperationsTable.Controls.Add(OneButton, 0, 3);
            OperationsTable.Controls.Add(SixButton, 2, 2);
            OperationsTable.Controls.Add(FiveButton, 1, 2);
            OperationsTable.Controls.Add(FourButton, 0, 2);
            OperationsTable.Controls.Add(NineButton, 2, 1);
            OperationsTable.Controls.Add(EightButton, 1, 1);
            OperationsTable.Controls.Add(SevenButton, 0, 1);
            OperationsTable.Controls.Add(DeleteSymbolButton, 1, 0);
            OperationsTable.Controls.Add(ClearButton, 0, 0);
            OperationsTable.Controls.Add(EqualityButton, 3, 4);
            OperationsTable.Controls.Add(PlusButton, 3, 3);
            OperationsTable.Controls.Add(button3, 3, 2);
            OperationsTable.Controls.Add(MultiplyButton, 3, 1);
            OperationsTable.Controls.Add(DivideButton, 3, 0);
            OperationsTable.Controls.Add(PercentButton, 2, 0);
            OperationsTable.Location = new Point(12, 204);
            OperationsTable.Name = "OperationsTable";
            OperationsTable.RowCount = 5;
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9999981F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9999981F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0000038F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            OperationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            OperationsTable.Size = new Size(565, 639);
            OperationsTable.TabIndex = 0;
            OperationsTable.Paint += OperationsTable_Paint;
            // 
            // DotButton
            // 
            DotButton.BackColor = SystemColors.ButtonShadow;
            DotButton.Dock = DockStyle.Fill;
            DotButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            DotButton.ForeColor = SystemColors.ControlLightLight;
            DotButton.Location = new Point(285, 511);
            DotButton.Name = "DotButton";
            DotButton.Size = new Size(135, 125);
            DotButton.TabIndex = 19;
            DotButton.Text = ".";
            DotButton.UseVisualStyleBackColor = false;
            // 
            // ZeroButton
            // 
            ZeroButton.BackColor = SystemColors.ButtonShadow;
            OperationsTable.SetColumnSpan(ZeroButton, 2);
            ZeroButton.Dock = DockStyle.Fill;
            ZeroButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            ZeroButton.ForeColor = SystemColors.ControlLightLight;
            ZeroButton.Location = new Point(3, 511);
            ZeroButton.Name = "ZeroButton";
            ZeroButton.Size = new Size(276, 125);
            ZeroButton.TabIndex = 17;
            ZeroButton.Text = "0";
            ZeroButton.UseVisualStyleBackColor = false;
            ZeroButton.Click += NumberClick;
            // 
            // ThreeButton
            // 
            ThreeButton.BackColor = SystemColors.ButtonShadow;
            ThreeButton.Dock = DockStyle.Fill;
            ThreeButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            ThreeButton.ForeColor = SystemColors.ControlLightLight;
            ThreeButton.Location = new Point(285, 384);
            ThreeButton.Name = "ThreeButton";
            ThreeButton.Size = new Size(135, 121);
            ThreeButton.TabIndex = 16;
            ThreeButton.Text = "3";
            ThreeButton.UseVisualStyleBackColor = false;
            ThreeButton.Click += NumberClick;
            // 
            // TwoButton
            // 
            TwoButton.BackColor = SystemColors.ButtonShadow;
            TwoButton.Dock = DockStyle.Fill;
            TwoButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            TwoButton.ForeColor = SystemColors.ControlLightLight;
            TwoButton.Location = new Point(144, 384);
            TwoButton.Name = "TwoButton";
            TwoButton.Size = new Size(135, 121);
            TwoButton.TabIndex = 15;
            TwoButton.Text = "2";
            TwoButton.UseVisualStyleBackColor = false;
            TwoButton.Click += NumberClick;
            // 
            // OneButton
            // 
            OneButton.BackColor = SystemColors.ButtonShadow;
            OneButton.Dock = DockStyle.Fill;
            OneButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            OneButton.ForeColor = SystemColors.ControlLightLight;
            OneButton.Location = new Point(3, 384);
            OneButton.Name = "OneButton";
            OneButton.Size = new Size(135, 121);
            OneButton.TabIndex = 14;
            OneButton.Text = "1";
            OneButton.UseVisualStyleBackColor = false;
            OneButton.Click += NumberClick;
            // 
            // SixButton
            // 
            SixButton.BackColor = SystemColors.ButtonShadow;
            SixButton.Dock = DockStyle.Fill;
            SixButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            SixButton.ForeColor = SystemColors.ControlLightLight;
            SixButton.Location = new Point(285, 257);
            SixButton.Name = "SixButton";
            SixButton.Size = new Size(135, 121);
            SixButton.TabIndex = 13;
            SixButton.Text = "6";
            SixButton.UseVisualStyleBackColor = false;
            SixButton.Click += NumberClick;
            // 
            // FiveButton
            // 
            FiveButton.BackColor = SystemColors.ButtonShadow;
            FiveButton.Dock = DockStyle.Fill;
            FiveButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            FiveButton.ForeColor = SystemColors.ControlLightLight;
            FiveButton.Location = new Point(144, 257);
            FiveButton.Name = "FiveButton";
            FiveButton.Size = new Size(135, 121);
            FiveButton.TabIndex = 12;
            FiveButton.Text = "5";
            FiveButton.UseVisualStyleBackColor = false;
            FiveButton.Click += NumberClick;
            // 
            // FourButton
            // 
            FourButton.BackColor = SystemColors.ButtonShadow;
            FourButton.Dock = DockStyle.Fill;
            FourButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            FourButton.ForeColor = SystemColors.ControlLightLight;
            FourButton.Location = new Point(3, 257);
            FourButton.Name = "FourButton";
            FourButton.Size = new Size(135, 121);
            FourButton.TabIndex = 11;
            FourButton.Text = "4";
            FourButton.UseVisualStyleBackColor = false;
            FourButton.Click += NumberClick;
            // 
            // NineButton
            // 
            NineButton.BackColor = SystemColors.ButtonShadow;
            NineButton.Dock = DockStyle.Fill;
            NineButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            NineButton.ForeColor = SystemColors.ControlLightLight;
            NineButton.Location = new Point(285, 130);
            NineButton.Name = "NineButton";
            NineButton.Size = new Size(135, 121);
            NineButton.TabIndex = 10;
            NineButton.Text = "9";
            NineButton.UseVisualStyleBackColor = false;
            NineButton.Click += NumberClick;
            // 
            // EightButton
            // 
            EightButton.BackColor = SystemColors.ButtonShadow;
            EightButton.Dock = DockStyle.Fill;
            EightButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            EightButton.ForeColor = SystemColors.ControlLightLight;
            EightButton.Location = new Point(144, 130);
            EightButton.Name = "EightButton";
            EightButton.Size = new Size(135, 121);
            EightButton.TabIndex = 9;
            EightButton.Text = "8";
            EightButton.UseVisualStyleBackColor = false;
            EightButton.Click += NumberClick;
            // 
            // SevenButton
            // 
            SevenButton.BackColor = SystemColors.ButtonShadow;
            SevenButton.Dock = DockStyle.Fill;
            SevenButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            SevenButton.ForeColor = SystemColors.ControlLightLight;
            SevenButton.Location = new Point(3, 130);
            SevenButton.Name = "SevenButton";
            SevenButton.Size = new Size(135, 121);
            SevenButton.TabIndex = 8;
            SevenButton.Text = "7";
            SevenButton.UseVisualStyleBackColor = false;
            SevenButton.Click += NumberClick;
            // 
            // DeleteSymbolButton
            // 
            DeleteSymbolButton.BackColor = SystemColors.ControlDarkDark;
            DeleteSymbolButton.Dock = DockStyle.Fill;
            DeleteSymbolButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteSymbolButton.ForeColor = SystemColors.ControlLightLight;
            DeleteSymbolButton.Location = new Point(144, 3);
            DeleteSymbolButton.Name = "DeleteSymbolButton";
            DeleteSymbolButton.Size = new Size(135, 121);
            DeleteSymbolButton.TabIndex = 7;
            DeleteSymbolButton.Text = "<=";
            DeleteSymbolButton.UseVisualStyleBackColor = false;
            DeleteSymbolButton.Click += DeleteLastSymbolClick;
            // 
            // ClearButton
            // 
            ClearButton.BackColor = SystemColors.ControlDarkDark;
            ClearButton.Dock = DockStyle.Fill;
            ClearButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            ClearButton.ForeColor = SystemColors.ControlLightLight;
            ClearButton.Location = new Point(3, 3);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(135, 121);
            ClearButton.TabIndex = 6;
            ClearButton.Text = "C";
            ClearButton.UseVisualStyleBackColor = false;
            ClearButton.Click += ClearClick;
            // 
            // EqualityButton
            // 
            EqualityButton.BackColor = Color.DarkOrange;
            EqualityButton.Dock = DockStyle.Fill;
            EqualityButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            EqualityButton.ForeColor = SystemColors.ControlLightLight;
            EqualityButton.Location = new Point(426, 511);
            EqualityButton.Name = "EqualityButton";
            EqualityButton.Size = new Size(136, 125);
            EqualityButton.TabIndex = 0;
            EqualityButton.Text = "=";
            EqualityButton.UseVisualStyleBackColor = false;
            EqualityButton.Click += ResultClick;
            // 
            // PlusButton
            // 
            PlusButton.BackColor = Color.DarkOrange;
            PlusButton.Dock = DockStyle.Fill;
            PlusButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            PlusButton.ForeColor = SystemColors.ControlLightLight;
            PlusButton.Location = new Point(426, 384);
            PlusButton.Name = "PlusButton";
            PlusButton.Size = new Size(136, 121);
            PlusButton.TabIndex = 1;
            PlusButton.Text = "+";
            PlusButton.UseVisualStyleBackColor = false;
            PlusButton.Click += OperationClick;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkOrange;
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(426, 257);
            button3.Name = "button3";
            button3.Size = new Size(136, 121);
            button3.TabIndex = 2;
            button3.Text = "-";
            button3.UseVisualStyleBackColor = false;
            button3.Click += OperationClick;
            // 
            // MultiplyButton
            // 
            MultiplyButton.BackColor = Color.DarkOrange;
            MultiplyButton.Dock = DockStyle.Fill;
            MultiplyButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            MultiplyButton.ForeColor = SystemColors.ControlLightLight;
            MultiplyButton.Location = new Point(426, 130);
            MultiplyButton.Name = "MultiplyButton";
            MultiplyButton.Size = new Size(136, 121);
            MultiplyButton.TabIndex = 3;
            MultiplyButton.Text = "*";
            MultiplyButton.UseVisualStyleBackColor = false;
            MultiplyButton.Click += OperationClick;
            // 
            // DivideButton
            // 
            DivideButton.BackColor = Color.DarkOrange;
            DivideButton.Dock = DockStyle.Fill;
            DivideButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            DivideButton.ForeColor = SystemColors.ControlLightLight;
            DivideButton.Location = new Point(426, 3);
            DivideButton.Name = "DivideButton";
            DivideButton.Size = new Size(136, 121);
            DivideButton.TabIndex = 4;
            DivideButton.Text = "/";
            DivideButton.UseVisualStyleBackColor = false;
            DivideButton.Click += OperationClick;
            // 
            // PercentButton
            // 
            PercentButton.BackColor = SystemColors.ControlDarkDark;
            PercentButton.Dock = DockStyle.Fill;
            PercentButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            PercentButton.ForeColor = SystemColors.ControlLightLight;
            PercentButton.Location = new Point(285, 3);
            PercentButton.Name = "PercentButton";
            PercentButton.Size = new Size(135, 121);
            PercentButton.TabIndex = 5;
            PercentButton.Text = "%";
            PercentButton.UseVisualStyleBackColor = false;
            PercentButton.Click += OperationClick;
            // 
            // ConveyorPanel
            // 
            ConveyorPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ConveyorPanel.BorderStyle = BorderStyle.FixedSingle;
            ConveyorPanel.Controls.Add(ExpressionConveyor);
            ConveyorPanel.Location = new Point(12, 12);
            ConveyorPanel.Name = "ConveyorPanel";
            ConveyorPanel.Size = new Size(565, 141);
            ConveyorPanel.TabIndex = 1;
            // 
            // ExpressionConveyor
            // 
            ExpressionConveyor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ExpressionConveyor.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            ExpressionConveyor.ForeColor = Color.Ivory;
            ExpressionConveyor.Location = new Point(3, 9);
            ExpressionConveyor.Name = "ExpressionConveyor";
            ExpressionConveyor.Size = new Size(564, 127);
            ExpressionConveyor.TabIndex = 0;
            ExpressionConveyor.Text = "5245";
            ExpressionConveyor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(589, 844);
            Controls.Add(ConveyorPanel);
            Controls.Add(OperationsTable);
            Name = "Calculator";
            Text = "x\\";
            Load += Calculator_Load;
            OperationsTable.ResumeLayout(false);
            ConveyorPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel OperationsTable;
        private Panel ConveyorPanel;
        private Label ExpressionConveyor;
        private Button DotButton;
        private Button ZeroButton;
        private Button ThreeButton;
        private Button TwoButton;
        private Button OneButton;
        private Button SixButton;
        private Button FiveButton;
        private Button FourButton;
        private Button NineButton;
        private Button EightButton;
        private Button SevenButton;
        private Button DeleteSymbolButton;
        private Button ClearButton;
        private Button EqualityButton;
        private Button PlusButton;
        private Button button3;
        private Button MultiplyButton;
        private Button DivideButton;
        private Button PercentButton;
    }
}