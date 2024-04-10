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
            GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType gcComboBoxCellType7 = new GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo dropDownButtonInfo7 = new GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo();
            GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType gcComboBoxCellType8 = new GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo dropDownButtonInfo8 = new GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo();
            GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType gcComboBoxCellType9 = new GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo dropDownButtonInfo9 = new GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo();
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
            this.metFpSpread1.MessageBoxCaption = "SPREADデザイナ";
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
            gcComboBoxCellType7.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top);
            gcComboBoxCellType7.ClearCollection = true;
            gcComboBoxCellType7.DropDownMaxHeight = null;
            gcComboBoxCellType7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            gcComboBoxCellType7.EllipsisString = "...";
            gcComboBoxCellType7.ListHeaderPane.Height = 19;
            gcComboBoxCellType7.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear"),
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Return))), "ApplyRecommendedValue")});
            gcComboBoxCellType7.SideButtons.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.SideButtonBaseInfo[] {
            dropDownButtonInfo7});
            this.metFpSpread1_Sheet1.Cells.Get(1, 3).CellType = gcComboBoxCellType7;
            gcComboBoxCellType8.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top);
            gcComboBoxCellType8.ClearCollection = true;
            gcComboBoxCellType8.DropDownMaxHeight = null;
            gcComboBoxCellType8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            gcComboBoxCellType8.EllipsisString = "...";
            gcComboBoxCellType8.ListHeaderPane.Height = 19;
            gcComboBoxCellType8.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear"),
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Return))), "ApplyRecommendedValue")});
            gcComboBoxCellType8.SideButtons.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.SideButtonBaseInfo[] {
            dropDownButtonInfo8});
            this.metFpSpread1_Sheet1.Cells.Get(1, 4).CellType = gcComboBoxCellType8;
            this.metFpSpread1_Sheet1.Cells.Get(1, 4).Locked = true;
            this.metFpSpread1_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.ColumnFooter.DefaultStyle.Locked = false;
            this.metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.Locked = false;
            this.metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefaultEnhanced";
            this.metFpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "LockColumn";
            this.metFpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Locked = false;
            this.metFpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "LockCell";
            this.metFpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.metFpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderDefaultEnhanced";
            gcComboBoxCellType9.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top);
            gcComboBoxCellType9.ClearCollection = true;
            gcComboBoxCellType9.DropDownMaxHeight = null;
            gcComboBoxCellType9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            gcComboBoxCellType9.EllipsisString = "...";
            gcComboBoxCellType9.ListHeaderPane.Height = 19;
            gcComboBoxCellType9.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] {
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(System.Windows.Forms.Keys.F2, "ShortcutClear"),
            new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Return))), "ApplyRecommendedValue")});
            gcComboBoxCellType9.SideButtons.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.SideButtonBaseInfo[] {
            dropDownButtonInfo9});
            this.metFpSpread1_Sheet1.Columns.Get(1).CellType = gcComboBoxCellType9;
            this.metFpSpread1_Sheet1.Columns.Get(2).Label = "LockColumn";
            this.metFpSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.metFpSpread1_Sheet1.Columns.Get(2).Width = 82F;
            this.metFpSpread1_Sheet1.Columns.Get(4).Label = "LockCell";
            this.metFpSpread1_Sheet1.Columns.Get(4).Locked = false;
            this.metFpSpread1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.DefaultStyle.Locked = false;
            this.metFpSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.metFpSpread1_Sheet1.FilterBar.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.FilterBar.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.FilterBar.DefaultStyle.Locked = false;
            this.metFpSpread1_Sheet1.FilterBarHeaderStyle.BackColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.FilterBarHeaderStyle.ForeColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.FilterBarHeaderStyle.Locked = false;
            this.metFpSpread1_Sheet1.Protect = true;
            this.metFpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.metFpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.metFpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefaultEnhanced";
            this.metFpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.Empty;
            this.metFpSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.metFpSpread1_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
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
