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
            operationsTable = new TableLayoutPanel();
            dotButton = new Button();
            zeroButton = new Button();
            threeButton = new Button();
            twoButton = new Button();
            oneButton = new Button();
            sixButton = new Button();
            fiveButton = new Button();
            fourButton = new Button();
            nineButton = new Button();
            eightButton = new Button();
            sevenButton = new Button();
            changeSignButton = new Button();
            clearButton = new Button();
            equalityButton = new Button();
            plusButton = new Button();
            minusButton = new Button();
            multiplyButton = new Button();
            divideButton = new Button();
            percentButton = new Button();
            expressionConveyor = new Label();
            operationsTable.SuspendLayout();
            SuspendLayout();
            // 
            // operationsTable
            // 
            operationsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            operationsTable.ColumnCount = 4;
            operationsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            operationsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            operationsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.8015881F));
            operationsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.1984119F));
            operationsTable.Controls.Add(dotButton, 2, 5);
            operationsTable.Controls.Add(zeroButton, 0, 5);
            operationsTable.Controls.Add(threeButton, 2, 4);
            operationsTable.Controls.Add(twoButton, 1, 4);
            operationsTable.Controls.Add(oneButton, 0, 4);
            operationsTable.Controls.Add(sixButton, 2, 3);
            operationsTable.Controls.Add(fiveButton, 1, 3);
            operationsTable.Controls.Add(fourButton, 0, 3);
            operationsTable.Controls.Add(nineButton, 2, 2);
            operationsTable.Controls.Add(eightButton, 1, 2);
            operationsTable.Controls.Add(sevenButton, 0, 2);
            operationsTable.Controls.Add(changeSignButton, 1, 1);
            operationsTable.Controls.Add(clearButton, 0, 1);
            operationsTable.Controls.Add(equalityButton, 3, 5);
            operationsTable.Controls.Add(plusButton, 3, 4);
            operationsTable.Controls.Add(minusButton, 3, 3);
            operationsTable.Controls.Add(multiplyButton, 3, 2);
            operationsTable.Controls.Add(divideButton, 3, 1);
            operationsTable.Controls.Add(percentButton, 2, 1);
            operationsTable.Controls.Add(expressionConveyor, 0, 0);
            operationsTable.Location = new Point(12, 25);
            operationsTable.Name = "operationsTable";
            operationsTable.RowCount = 6;
            operationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 27.5336037F));
            operationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 14.4932766F));
            operationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 14.4932766F));
            operationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 14.4932766F));
            operationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 14.49328F));
            operationsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 14.4932766F));
            operationsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            operationsTable.Size = new Size(392, 475);
            operationsTable.TabIndex = 0;
            // 
            // dotButton
            // 
            dotButton.BackColor = SystemColors.ButtonShadow;
            dotButton.Dock = DockStyle.Fill;
            dotButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            dotButton.ForeColor = SystemColors.ControlLightLight;
            dotButton.Location = new Point(199, 405);
            dotButton.Name = "dotButton";
            dotButton.Size = new Size(91, 67);
            dotButton.TabIndex = 8;
            dotButton.Text = ".";
            dotButton.UseVisualStyleBackColor = false;
            dotButton.Click += NumberOrOperationButtonClick;
            // 
            // zeroButton
            // 
            zeroButton.BackColor = SystemColors.ButtonShadow;
            operationsTable.SetColumnSpan(zeroButton, 2);
            zeroButton.Dock = DockStyle.Fill;
            zeroButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            zeroButton.ForeColor = SystemColors.ControlLightLight;
            zeroButton.Location = new Point(3, 405);
            zeroButton.Name = "zeroButton";
            zeroButton.Size = new Size(190, 67);
            zeroButton.TabIndex = 9;
            zeroButton.Text = "0";
            zeroButton.UseVisualStyleBackColor = false;
            zeroButton.Click += NumberOrOperationButtonClick;
            // 
            // threeButton
            // 
            threeButton.BackColor = SystemColors.ButtonShadow;
            threeButton.Dock = DockStyle.Fill;
            threeButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            threeButton.ForeColor = SystemColors.ControlLightLight;
            threeButton.Location = new Point(199, 337);
            threeButton.Name = "threeButton";
            threeButton.Size = new Size(91, 62);
            threeButton.TabIndex = 12;
            threeButton.Text = "3";
            threeButton.UseVisualStyleBackColor = false;
            threeButton.Click += NumberOrOperationButtonClick;
            // 
            // twoButton
            // 
            twoButton.BackColor = SystemColors.ButtonShadow;
            twoButton.Dock = DockStyle.Fill;
            twoButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            twoButton.ForeColor = SystemColors.ControlLightLight;
            twoButton.Location = new Point(101, 337);
            twoButton.Name = "twoButton";
            twoButton.Size = new Size(92, 62);
            twoButton.TabIndex = 11;
            twoButton.Text = "2";
            twoButton.UseVisualStyleBackColor = false;
            twoButton.Click += NumberOrOperationButtonClick;
            // 
            // oneButton
            // 
            oneButton.BackColor = SystemColors.ButtonShadow;
            oneButton.Dock = DockStyle.Fill;
            oneButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            oneButton.ForeColor = SystemColors.ControlLightLight;
            oneButton.Location = new Point(3, 337);
            oneButton.Name = "oneButton";
            oneButton.Size = new Size(92, 62);
            oneButton.TabIndex = 10;
            oneButton.Text = "1";
            oneButton.UseVisualStyleBackColor = false;
            oneButton.Click += NumberOrOperationButtonClick;
            // 
            // sixButton
            // 
            sixButton.BackColor = SystemColors.ButtonShadow;
            sixButton.Dock = DockStyle.Fill;
            sixButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            sixButton.ForeColor = SystemColors.ControlLightLight;
            sixButton.Location = new Point(199, 269);
            sixButton.Name = "sixButton";
            sixButton.Size = new Size(91, 62);
            sixButton.TabIndex = 15;
            sixButton.Text = "6";
            sixButton.UseVisualStyleBackColor = false;
            sixButton.Click += NumberOrOperationButtonClick;
            // 
            // fiveButton
            // 
            fiveButton.BackColor = SystemColors.ButtonShadow;
            fiveButton.Dock = DockStyle.Fill;
            fiveButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            fiveButton.ForeColor = SystemColors.ControlLightLight;
            fiveButton.Location = new Point(101, 269);
            fiveButton.Name = "fiveButton";
            fiveButton.Size = new Size(92, 62);
            fiveButton.TabIndex = 14;
            fiveButton.Text = "5";
            fiveButton.UseVisualStyleBackColor = false;
            fiveButton.Click += NumberOrOperationButtonClick;
            // 
            // fourButton
            // 
            fourButton.BackColor = SystemColors.ButtonShadow;
            fourButton.Dock = DockStyle.Fill;
            fourButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            fourButton.ForeColor = SystemColors.ControlLightLight;
            fourButton.Location = new Point(3, 269);
            fourButton.Name = "fourButton";
            fourButton.Size = new Size(92, 62);
            fourButton.TabIndex = 13;
            fourButton.Text = "4";
            fourButton.UseVisualStyleBackColor = false;
            fourButton.Click += NumberOrOperationButtonClick;
            // 
            // nineButton
            // 
            nineButton.BackColor = SystemColors.ButtonShadow;
            nineButton.Dock = DockStyle.Fill;
            nineButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            nineButton.ForeColor = SystemColors.ControlLightLight;
            nineButton.Location = new Point(199, 201);
            nineButton.Name = "nineButton";
            nineButton.Size = new Size(91, 62);
            nineButton.TabIndex = 18;
            nineButton.Text = "9";
            nineButton.UseVisualStyleBackColor = false;
            nineButton.Click += NumberOrOperationButtonClick;
            // 
            // eightButton
            // 
            eightButton.BackColor = SystemColors.ButtonShadow;
            eightButton.Dock = DockStyle.Fill;
            eightButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            eightButton.ForeColor = SystemColors.ControlLightLight;
            eightButton.Location = new Point(101, 201);
            eightButton.Name = "eightButton";
            eightButton.Size = new Size(92, 62);
            eightButton.TabIndex = 17;
            eightButton.Text = "8";
            eightButton.UseVisualStyleBackColor = false;
            eightButton.Click += NumberOrOperationButtonClick;
            // 
            // sevenButton
            // 
            sevenButton.BackColor = SystemColors.ButtonShadow;
            sevenButton.Dock = DockStyle.Fill;
            sevenButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            sevenButton.ForeColor = SystemColors.ControlLightLight;
            sevenButton.Location = new Point(3, 201);
            sevenButton.Name = "sevenButton";
            sevenButton.Size = new Size(92, 62);
            sevenButton.TabIndex = 16;
            sevenButton.Text = "7";
            sevenButton.UseVisualStyleBackColor = false;
            sevenButton.Click += NumberOrOperationButtonClick;
            // 
            // changeSignButton
            // 
            changeSignButton.BackColor = SystemColors.ControlDarkDark;
            changeSignButton.Dock = DockStyle.Fill;
            changeSignButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            changeSignButton.ForeColor = SystemColors.ControlLightLight;
            changeSignButton.Location = new Point(101, 133);
            changeSignButton.Name = "changeSignButton";
            changeSignButton.Size = new Size(92, 62);
            changeSignButton.TabIndex = 1;
            changeSignButton.Text = "±";
            changeSignButton.UseVisualStyleBackColor = false;
            changeSignButton.Click += ChangeSignClick;
            // 
            // clearButton
            // 
            clearButton.BackColor = SystemColors.ControlDarkDark;
            clearButton.Dock = DockStyle.Fill;
            clearButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            clearButton.ForeColor = SystemColors.ControlLightLight;
            clearButton.Location = new Point(3, 133);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(92, 62);
            clearButton.TabIndex = 0;
            clearButton.Text = "C";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += ClearClick;
            // 
            // equalityButton
            // 
            equalityButton.BackColor = Color.DarkOrange;
            equalityButton.Dock = DockStyle.Fill;
            equalityButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            equalityButton.ForeColor = SystemColors.ControlLightLight;
            equalityButton.Location = new Point(296, 405);
            equalityButton.Name = "equalityButton";
            equalityButton.Size = new Size(93, 67);
            equalityButton.TabIndex = 7;
            equalityButton.Text = "=";
            equalityButton.UseVisualStyleBackColor = false;
            equalityButton.Click += NumberOrOperationButtonClick;
            // 
            // plusButton
            // 
            plusButton.BackColor = Color.DarkOrange;
            plusButton.Dock = DockStyle.Fill;
            plusButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            plusButton.ForeColor = SystemColors.ControlLightLight;
            plusButton.Location = new Point(296, 337);
            plusButton.Name = "plusButton";
            plusButton.Size = new Size(93, 62);
            plusButton.TabIndex = 6;
            plusButton.Text = "+";
            plusButton.UseVisualStyleBackColor = false;
            plusButton.Click += NumberOrOperationButtonClick;
            // 
            // minusButton
            // 
            minusButton.BackColor = Color.DarkOrange;
            minusButton.Dock = DockStyle.Fill;
            minusButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            minusButton.ForeColor = SystemColors.ControlLightLight;
            minusButton.Location = new Point(296, 269);
            minusButton.Name = "minusButton";
            minusButton.Size = new Size(93, 62);
            minusButton.TabIndex = 5;
            minusButton.Text = "-";
            minusButton.UseVisualStyleBackColor = false;
            minusButton.Click += NumberOrOperationButtonClick;
            // 
            // multiplyButton
            // 
            multiplyButton.BackColor = Color.DarkOrange;
            multiplyButton.Dock = DockStyle.Fill;
            multiplyButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            multiplyButton.ForeColor = SystemColors.ControlLightLight;
            multiplyButton.Location = new Point(296, 201);
            multiplyButton.Name = "multiplyButton";
            multiplyButton.Size = new Size(93, 62);
            multiplyButton.TabIndex = 4;
            multiplyButton.Text = "*";
            multiplyButton.UseVisualStyleBackColor = false;
            multiplyButton.Click += NumberOrOperationButtonClick;
            // 
            // divideButton
            // 
            divideButton.BackColor = Color.DarkOrange;
            divideButton.Dock = DockStyle.Fill;
            divideButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            divideButton.ForeColor = SystemColors.ControlLightLight;
            divideButton.Location = new Point(296, 133);
            divideButton.Name = "divideButton";
            divideButton.Size = new Size(93, 62);
            divideButton.TabIndex = 3;
            divideButton.Text = "/";
            divideButton.UseVisualStyleBackColor = false;
            divideButton.Click += NumberOrOperationButtonClick;
            // 
            // percentButton
            // 
            percentButton.BackColor = SystemColors.ControlDarkDark;
            percentButton.Dock = DockStyle.Fill;
            percentButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            percentButton.ForeColor = SystemColors.ControlLightLight;
            percentButton.Location = new Point(199, 133);
            percentButton.Name = "percentButton";
            percentButton.Size = new Size(91, 62);
            percentButton.TabIndex = 2;
            percentButton.Text = "%";
            percentButton.UseVisualStyleBackColor = false;
            percentButton.Click += NumberOrOperationButtonClick;
            // 
            // expressionConveyor
            // 
            expressionConveyor.AutoSize = true;
            operationsTable.SetColumnSpan(expressionConveyor, 4);
            expressionConveyor.Dock = DockStyle.Fill;
            expressionConveyor.Font = new Font("Segoe UI", 32F, FontStyle.Regular, GraphicsUnit.Point);
            expressionConveyor.ForeColor = SystemColors.ButtonHighlight;
            expressionConveyor.Location = new Point(3, 0);
            expressionConveyor.Name = "expressionConveyor";
            expressionConveyor.Size = new Size(386, 130);
            expressionConveyor.TabIndex = 19;
            expressionConveyor.Text = "Test";
            expressionConveyor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(405, 512);
            Controls.Add(operationsTable);
            MinimumSize = new Size(260, 540);
            Name = "Calculator";
            Text = "Calculator";
            Load += Calculator_Load;
            operationsTable.ResumeLayout(false);
            operationsTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel operationsTable;
        private Button dotButton;
        private Button zeroButton;
        private Button threeButton;
        private Button twoButton;
        private Button oneButton;
        private Button sixButton;
        private Button fiveButton;
        private Button fourButton;
        private Button nineButton;
        private Button eightButton;
        private Button sevenButton;
        private Button changeSignButton;
        private Button clearButton;
        private Button equalityButton;
        private Button plusButton;
        private Button minusButton;
        private Button multiplyButton;
        private Button divideButton;
        private Button percentButton;
        private Label expressionConveyor;
    }
}