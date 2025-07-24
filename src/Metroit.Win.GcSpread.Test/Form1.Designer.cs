namespace Metroit.Win.GcSpread.Test
{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            metFpSpread1 = new MetFpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("resource1"));
            metFpSpread1_Sheet1 = metFpSpread1.GetSheet(0);
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)metFpSpread1).BeginInit();
            SuspendLayout();
            // 
            // metFpSpread1
            // 
            metFpSpread1.AccessibleDescription = "metFpSpread1, Sheet1, Row 0, Column 0";
            metFpSpread1.AllowSheetCopy = false;
            metFpSpread1.AutoOpenDropDown = true;
            metFpSpread1.Font = new Font("ＭＳ Ｐゴシック", 11F);
            metFpSpread1.Location = new Point(119, 110);
            metFpSpread1.Margin = new Padding(4);
            metFpSpread1.Name = "metFpSpread1";
            metFpSpread1.Size = new Size(720, 328);
            metFpSpread1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(595, 51);
            button1.Name = "button1";
            button1.Size = new Size(122, 23);
            button1.TabIndex = 1;
            button1.Text = "GetActualCellType";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(595, 80);
            button2.Name = "button2";
            button2.Size = new Size(122, 23);
            button2.TabIndex = 2;
            button2.Text = "CopyActualCellType";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 562);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(metFpSpread1);
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)metFpSpread1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MetFpSpread metFpSpread1;
        private FarPoint.Win.Spread.SheetView metFpSpread1_Sheet1;
        private Button button1;
        private Button button2;
    }
}
