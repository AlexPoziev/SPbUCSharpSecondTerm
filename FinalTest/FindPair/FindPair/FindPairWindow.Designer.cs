namespace FindPair
{
    partial class FindPair
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
            FindPairPanel = new TableLayoutPanel();
            SuspendLayout();
            // 
            // FindPairPanel
            // 
            FindPairPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FindPairPanel.ColumnCount = 2;
            FindPairPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            FindPairPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            FindPairPanel.Location = new Point(12, 6);
            FindPairPanel.Margin = new Padding(2, 1, 2, 1);
            FindPairPanel.Name = "FindPairPanel";
            FindPairPanel.RowCount = 2;
            FindPairPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            FindPairPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            FindPairPanel.Size = new Size(491, 286);
            FindPairPanel.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 307);
            Controls.Add(FindPairPanel);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel FindPairPanel;
    }
}