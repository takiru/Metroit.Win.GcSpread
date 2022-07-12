
namespace Metroit.Win.GcSpread.Test
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.metFpSpread1 = new Metroit.Win.GcSpread.MetFpSpread();
            this.metFpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.metFpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metFpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // metFpSpread1
            // 
            this.metFpSpread1.AccessibleDescription = "metFpSpread1, Sheet1, Row 0, Column 0, a";
            this.metFpSpread1.Location = new System.Drawing.Point(187, 93);
            this.metFpSpread1.Name = "metFpSpread1";
            this.metFpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.metFpSpread1_Sheet1});
            this.metFpSpread1.Size = new System.Drawing.Size(465, 263);
            this.metFpSpread1.TabIndex = 0;
            // 
            // metFpSpread1_Sheet1
            // 
            this.metFpSpread1_Sheet1.Reset();
            this.metFpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.metFpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.metFpSpread1_Sheet1.Cells.Get(0, 0).Value = "a";
            this.metFpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.metFpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metFpSpread1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.metFpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metFpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetFpSpread metFpSpread1;
        private FarPoint.Win.Spread.SheetView metFpSpread1_Sheet1;
    }
}

