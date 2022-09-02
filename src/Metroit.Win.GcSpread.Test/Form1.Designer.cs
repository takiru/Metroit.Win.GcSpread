
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
            GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType gcComboBoxCellType1 = new GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo dropDownButtonInfo1 = new GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo();
            GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType gcComboBoxCellType2 = new GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo dropDownButtonInfo2 = new GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo();
            this.metFpSpread1 = new Metroit.Win.GcSpread.MetFpSpread();
            this.metFpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.metFpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metFpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // metFpSpread1
            // 
            this.metFpSpread1.AccessibleDescription = "metFpSpread1, Sheet1, Row 0, Column 0";
            this.metFpSpread1.AutoOpenDropDown = true;
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
            gcComboBoxCellType1.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top);
            gcComboBoxCellType1.ClearCollection = true;
            gcComboBoxCellType1.DropDownMaxHeight = null;
            gcComboBoxCellType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            gcComboBoxCellType1.EllipsisString = "...";
            gcComboBoxCellType1.ListHeaderPane.Height = 19;
            gcComboBoxCellType1.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear"),
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Return))), "ApplyRecommendedValue")});
            gcComboBoxCellType1.SideButtons.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.SideButtonBaseInfo[] {
            dropDownButtonInfo1});
            this.metFpSpread1_Sheet1.Cells.Get(1, 3).CellType = gcComboBoxCellType1;
            this.metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefaultEnhanced";
            gcComboBoxCellType2.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top);
            gcComboBoxCellType2.ClearCollection = true;
            gcComboBoxCellType2.DropDownMaxHeight = null;
            gcComboBoxCellType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            gcComboBoxCellType2.EllipsisString = "...";
            gcComboBoxCellType2.ListHeaderPane.Height = 19;
            gcComboBoxCellType2.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear"),
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Return))), "ApplyRecommendedValue")});
            gcComboBoxCellType2.SideButtons.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.SideButtonBaseInfo[] {
            dropDownButtonInfo2});
            this.metFpSpread1_Sheet1.Columns.Get(1).CellType = gcComboBoxCellType2;
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

