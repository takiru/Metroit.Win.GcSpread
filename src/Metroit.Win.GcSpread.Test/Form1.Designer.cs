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
            FarPoint.Win.Spread.FlatScrollBarRenderer flatScrollBarRenderer1 = new FarPoint.Win.Spread.FlatScrollBarRenderer();
            FarPoint.Win.Spread.FlatScrollBarRenderer flatScrollBarRenderer2 = new FarPoint.Win.Spread.FlatScrollBarRenderer();
            GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType gcComboBoxCellType1 = new GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo dropDownButtonInfo1 = new GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo();
            GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType gcComboBoxCellType2 = new GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo dropDownButtonInfo2 = new GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            GrapeCity.Win.Spread.InputMan.CellType.GcNumberCellType gcNumberCellType1 = new GrapeCity.Win.Spread.InputMan.CellType.GcNumberCellType();
            GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo dropDownButtonInfo3 = new GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo();
            GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType gcComboBoxCellType3 = new GrapeCity.Win.Spread.InputMan.CellType.GcComboBoxCellType();
            GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo dropDownButtonInfo4 = new GrapeCity.Win.Spread.InputMan.CellType.DropDownButtonInfo();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            metFpSpread1 = new MetFpSpread();
            metFpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)metFpSpread1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)metFpSpread1_Sheet1).BeginInit();
            SuspendLayout();
            // 
            // metFpSpread1
            // 
            metFpSpread1.AccessibleDescription = "metFpSpread1, Sheet1, Row 0, Column 0";
            metFpSpread1.AutoOpenDropDown = true;
            metFpSpread1.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            metFpSpread1.HorizontalScrollBar.Name = "";
            flatScrollBarRenderer1.ArrowColor = Color.FromArgb(121, 121, 121);
            flatScrollBarRenderer1.BackColor = Color.FromArgb(255, 255, 255);
            flatScrollBarRenderer1.BorderActiveColor = Color.FromArgb(171, 171, 171);
            flatScrollBarRenderer1.BorderColor = Color.FromArgb(171, 171, 171);
            flatScrollBarRenderer1.TrackBarBackColor = Color.FromArgb(219, 219, 219);
            metFpSpread1.HorizontalScrollBar.Renderer = flatScrollBarRenderer1;
            metFpSpread1.Location = new Point(119, 110);
            metFpSpread1.Margin = new Padding(4);
            metFpSpread1.MessageBoxCaption = "SPREADデザイナ";
            metFpSpread1.Name = "metFpSpread1";
            metFpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] { metFpSpread1_Sheet1 });
            metFpSpread1.Size = new Size(720, 328);
            metFpSpread1.TabIndex = 0;
            metFpSpread1.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            metFpSpread1.VerticalScrollBar.Name = "";
            flatScrollBarRenderer2.ArrowColor = Color.FromArgb(121, 121, 121);
            flatScrollBarRenderer2.BackColor = Color.FromArgb(255, 255, 255);
            flatScrollBarRenderer2.BorderActiveColor = Color.FromArgb(171, 171, 171);
            flatScrollBarRenderer2.BorderColor = Color.FromArgb(171, 171, 171);
            flatScrollBarRenderer2.TrackBarBackColor = Color.FromArgb(219, 219, 219);
            metFpSpread1.VerticalScrollBar.Renderer = flatScrollBarRenderer2;
            // 
            // metFpSpread1_Sheet1
            // 
            metFpSpread1_Sheet1.Reset();
            metFpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            metFpSpread1_Sheet1.SheetName = "Sheet1";
            metFpSpread1_Sheet1.Cells.Get(0, 0).Value = "a";
            gcComboBoxCellType1.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top);
            gcComboBoxCellType1.ClearCollection = true;
            gcComboBoxCellType1.DropDownMaxHeight = null;
            gcComboBoxCellType1.DropDownStyle = ComboBoxStyle.DropDownList;
            gcComboBoxCellType1.EllipsisString = "...";
            gcComboBoxCellType1.ListHeaderPane.Height = 22;
            gcComboBoxCellType1.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] { new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.F2, "ShortcutClear"), new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.Control | Keys.Return, "ApplyRecommendedValue") });
            gcComboBoxCellType1.SideButtons.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.SideButtonBaseInfo[] { dropDownButtonInfo1 });
            metFpSpread1_Sheet1.Cells.Get(1, 3).CellType = gcComboBoxCellType1;
            gcComboBoxCellType2.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top);
            gcComboBoxCellType2.ClearCollection = true;
            gcComboBoxCellType2.DropDownMaxHeight = null;
            gcComboBoxCellType2.DropDownStyle = ComboBoxStyle.DropDownList;
            gcComboBoxCellType2.EllipsisString = "...";
            gcComboBoxCellType2.ListHeaderPane.Height = 22;
            gcComboBoxCellType2.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] { new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.F2, "ShortcutClear"), new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.Control | Keys.Return, "ApplyRecommendedValue") });
            gcComboBoxCellType2.SideButtons.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.SideButtonBaseInfo[] { dropDownButtonInfo2 });
            metFpSpread1_Sheet1.Cells.Get(1, 4).CellType = gcComboBoxCellType2;
            metFpSpread1_Sheet1.Cells.Get(1, 4).Locked = true;
            buttonCellType1.ButtonColor2 = SystemColors.ButtonFace;
            metFpSpread1_Sheet1.Cells.Get(4, 6).CellType = buttonCellType1;
            gcNumberCellType1.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top);
            gcNumberCellType1.ClearCollection = true;
            gcNumberCellType1.DropDown.ClosingAnimation = GrapeCity.Win.Spread.InputMan.CellType.DropDownAnimation.Extend;
            gcNumberCellType1.DropDownCalculator.BorderStyle = BorderStyle.Fixed3D;
            gcNumberCellType1.DropDownCalculator.FlatStyle = FlatStyle.Flat;
            gcNumberCellType1.Fields.IntegerPart.MinDigits = 1;
            gcNumberCellType1.Fields.SignSuffix.NegativePattern = "";
            gcNumberCellType1.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] { new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.F2, "SetZero"), new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.Subtract, "SwitchSign"), new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.OemMinus, "SwitchSign"), new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.Control | Keys.Return, "ApplyRecommendedValue") });
            dropDownButtonInfo3.Position = LeftRightAlignment.Left;
            gcNumberCellType1.SideButtons.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.SideButtonBaseInfo[] { dropDownButtonInfo3 });
            metFpSpread1_Sheet1.Cells.Get(5, 7).CellType = gcNumberCellType1;
            metFpSpread1_Sheet1.Cells.Get(5, 7).Value = new decimal(new int[] { 1234, 0, 0, 0 });
            metFpSpread1_Sheet1.ColumnFooter.DefaultStyle.BackColor = Color.Empty;
            metFpSpread1_Sheet1.ColumnFooter.DefaultStyle.ForeColor = Color.Empty;
            metFpSpread1_Sheet1.ColumnFooter.DefaultStyle.Locked = false;
            metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.BackColor = Color.Empty;
            metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = Color.Empty;
            metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.Locked = false;
            metFpSpread1_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefaultEnhanced";
            metFpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "LockColumn";
            metFpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Locked = false;
            metFpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "LockCell";
            metFpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = Color.Empty;
            metFpSpread1_Sheet1.ColumnHeader.DefaultStyle.ForeColor = Color.Empty;
            metFpSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            metFpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderDefaultEnhanced";
            gcComboBoxCellType3.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Top);
            gcComboBoxCellType3.ClearCollection = true;
            gcComboBoxCellType3.DropDownMaxHeight = null;
            gcComboBoxCellType3.DropDownStyle = ComboBoxStyle.DropDownList;
            gcComboBoxCellType3.EllipsisString = "...";
            gcComboBoxCellType3.ListHeaderPane.Height = 22;
            gcComboBoxCellType3.ShortcutKeys.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry[] { new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.F2, "ShortcutClear"), new GrapeCity.Win.Spread.InputMan.CellType.ShortcutDictionaryEntry(Keys.Control | Keys.Return, "ApplyRecommendedValue") });
            gcComboBoxCellType3.SideButtons.AddRange(new GrapeCity.Win.Spread.InputMan.CellType.SideButtonBaseInfo[] { dropDownButtonInfo4 });
            metFpSpread1_Sheet1.Columns.Get(1).CellType = gcComboBoxCellType3;
            metFpSpread1_Sheet1.Columns.Get(2).Label = "LockColumn";
            metFpSpread1_Sheet1.Columns.Get(2).Locked = true;
            metFpSpread1_Sheet1.Columns.Get(2).Width = 82F;
            metFpSpread1_Sheet1.Columns.Get(4).Label = "LockCell";
            metFpSpread1_Sheet1.Columns.Get(4).Locked = false;
            comboBoxCellType1.AllowEditorVerticalAlign = true;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            metFpSpread1_Sheet1.Columns.Get(6).CellType = comboBoxCellType1;
            metFpSpread1_Sheet1.Columns.Get(7).Width = 71F;
            metFpSpread1_Sheet1.DefaultStyle.BackColor = Color.Empty;
            metFpSpread1_Sheet1.DefaultStyle.ForeColor = Color.Empty;
            metFpSpread1_Sheet1.DefaultStyle.Locked = false;
            metFpSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            metFpSpread1_Sheet1.FilterBar.DefaultStyle.BackColor = Color.Empty;
            metFpSpread1_Sheet1.FilterBar.DefaultStyle.ForeColor = Color.Empty;
            metFpSpread1_Sheet1.FilterBar.DefaultStyle.Locked = false;
            metFpSpread1_Sheet1.FilterBarHeaderStyle.BackColor = Color.Empty;
            metFpSpread1_Sheet1.FilterBarHeaderStyle.ForeColor = Color.Empty;
            metFpSpread1_Sheet1.FilterBarHeaderStyle.Locked = false;
            metFpSpread1_Sheet1.Protect = true;
            metFpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            metFpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = Color.Empty;
            metFpSpread1_Sheet1.RowHeader.DefaultStyle.ForeColor = Color.Empty;
            metFpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            metFpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefaultEnhanced";
            metFpSpread1_Sheet1.Rows.Get(3).CellType = checkBoxCellType1;
            metFpSpread1_Sheet1.Rows.Get(4).CellType = checkBoxCellType2;
            metFpSpread1_Sheet1.SheetCornerStyle.BackColor = Color.Empty;
            metFpSpread1_Sheet1.SheetCornerStyle.ForeColor = Color.Empty;
            metFpSpread1_Sheet1.SheetCornerStyle.Locked = false;
            metFpSpread1_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            metFpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // button1
            // 
            button1.Location = new Point(498, 33);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(616, 59);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "button2";
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
            ((System.ComponentModel.ISupportInitialize)metFpSpread1_Sheet1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MetFpSpread metFpSpread1;
        private FarPoint.Win.Spread.SheetView metFpSpread1_Sheet1;
        private Button button1;
        private Button button2;
    }
}
