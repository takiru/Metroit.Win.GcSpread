using FarPoint.Win.Spread;
using GrapeCity.Win.Spread.InputMan.CellType;
using Metroit.Win.GcSpread.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Metroit.Win.GcSpread
{
    /// <summary>
    /// GrapeCity SPREAD を拡張した命令を提供します。
    /// </summary>
    public class MetFpSpread : FpSpread
    {
        private bool prevEditModePermanent;
        private bool prevAutoDropDown;

        /// <summary>
        /// キーマップ制御の動作を取得します。
        /// </summary>
        /// <returns></returns>
        [Browsable(false)]
        public KeyMapActionManager KeyMapActionManager { get; } = new KeyMapActionManager();

        /// <summary>
        /// GcComboBoxCellType のセルをクリックした時、自動的にドロップダウンを表示するかどうかを指定します。
        /// true の場合、セルのクリックでドロップダウンが表示され、ドロップダウンが閉じられた時には編集モードではなくなります。
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Category("Metroit拡張 動作")]
        [Description("GcComboBoxCellType のセルをクリックした時、自動的にドロップダウンを表示するかどうかを指定します。true の場合、セルのクリックでドロップダウンが表示され、ドロップダウンが閉じられた時には編集モードではなくなります。")]
        public bool AutoOpenDropDown { get; set; } = false;

        /// <summary>
        /// シートタブをCtrlやShiftキーによって複数選択できるかどうかを取得または設定します。
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Metroit拡張 動作")]
        [Description("シートタブをCtrlやShiftキーによって複数選択できるかどうかを指定します。")]
        public bool AllowSheetMultiSelect { get; set; } = true;

        /// <summary>
        /// シートタブをドラッグ＆ドロップしてシートをコピーできるかどうかを取得または設定します。
        /// シートタブのドラッグ＆ドロップの操作自体は AllowSheetMove プロパティによって決定されます。
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Metroit拡張 動作")]
        [Description("シートタブをドラッグ＆ドロップしてシートをコピーできるかどうかを指定します。シートタブのドラッグ＆ドロップの操作自体は AllowSheetMove プロパティによって決定されます。")]
        public bool AllowSheetCopy { get; set; } = true;

        /// <summary>
        /// シートをドラッグ中かどうか。
        /// </summary>
        private bool _sheetDragging = false;

        /// <summary>
        /// 新しい MetFpSpread インスタンスを生成します。
        /// </summary>
        public MetFpSpread() : base()
        {
            AddEvents();
        }

        /// <summary>
        /// 新しい MetFpSpread インスタンスを生成します。
        /// </summary>
        /// <param name="legacyBehaviors">どの動作が下位互換であるかを値を示すLegacyBehaviors。</param>
        public MetFpSpread(LegacyBehaviors legacyBehaviors) : base(legacyBehaviors)
        {
            AddEvents();
        }

        /// <summary>
        /// イベントを追加する。
        /// </summary>
        private void AddEvents()
        {
            KeyDown += MetFpSpread_KeyDown;
            CellClick += MetFpSpread_CellClick;
            ComboDropDown += MetFpSpread_ComboDropDown;
            ComboCloseUp += MetFpSpread_ComboCloseUp;
            SheetTabClick += MetFpSpread_SheetTabClick;
            SheetDragMoving += MetFpSpread_SheetDragMoving;
            MouseUp += MetFpSpread_MouseUp;
            MouseMove += MetFpSpread_MouseMove;
        }

        /// <summary>
        /// コントロールが最初に作成されると呼び出されます。
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            OnKeyMapActionInitializing(new KeyMapActionInitializingEventArgs(KeyMapActionManager));
        }

        /// <summary>
        /// キーマップされている処理を実行する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetFpSpread_KeyDown(object sender, KeyEventArgs e)
        {
            KeyMapActionManager.Execute(e.KeyData, ActiveSheet.ActiveCell, true);
        }

        /// <summary>
        /// GcComboBoxCellType がクリックされた時、自動的にドロップダウンを表示する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetFpSpread_CellClick(object sender, CellClickEventArgs e)
        {
            if (!AutoOpenDropDown)
            {
                return;
            }
            if (e.ColumnHeader || e.ColumnFooter || e.RowHeader)
            {
                return;
            }

            var gcComboCellType = GetGcComboBoxCellType(e.Row, e.Column);
            if (gcComboCellType == null)
            {
                return;
            }
            if (!ActiveSheet.Cells[e.Row, e.Column].CanEditable())
            {
                return;
            }

            prevEditModePermanent = EditModePermanent;
            prevAutoDropDown = gcComboCellType.DropDown.AutoDropDown;
            EditModePermanent = true;
            gcComboCellType.DropDown.AutoDropDown = true;
        }

        /// <summary>
        /// AutoOpenDropDown = true によって GcComboBoxCellType がクリックされてドロップダウンが表示された時、
        /// 強制的に変更したプロパティ情報を元に戻す。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetFpSpread_ComboDropDown(object sender, EditorNotifyEventArgs e)
        {
            if (!AutoOpenDropDown)
            {
                return;
            }

            var gcComboCellType = GetGcComboBoxCellType(e.Row, e.Column);
            if (gcComboCellType == null)
            {
                return;
            }

            EditModePermanent = prevEditModePermanent;
            gcComboCellType.DropDown.AutoDropDown = prevAutoDropDown;
        }

        /// <summary>
        /// GcComboBoxCellType のドロップダウンが閉じられた時、編集モードを解除する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetFpSpread_ComboCloseUp(object sender, EditorNotifyEventArgs e)
        {
            if (!AutoOpenDropDown)
            {
                return;
            }

            var gcComboCellType = GetGcComboBoxCellType(e.Row, e.Column);
            if (gcComboCellType == null)
            {
                return;
            }

            EditMode = false;
        }

        /// <summary>
        /// Ctrl, Shift 押下によるシートの複数選択を拒否する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetFpSpread_SheetTabClick(object sender, SheetTabClickEventArgs e)
        {
            if (!AllowSheetMultiSelect)
            {
                var pressedOperateKey = (ModifierKeys & Keys.Control) == Keys.Control || (ModifierKeys & Keys.Shift) == Keys.Shift;
                if (MouseButtons == MouseButtons.Left && pressedOperateKey)
                {
                    Sheets[e.SheetTabIndex].AsWorksheet().Select(true);
                }
            }
        }

        /// <summary>
        /// シートのドラッグコピーを許可しな場合、ドラッグ中にCtrlが押されてたら拒否する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetFpSpread_SheetDragMoving(object sender, SheetDragMovingEventArgs e)
        {
            _sheetDragging = true;

            if (!AllowSheetCopy && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                e.Restrict = true;
            }
        }

        /// <summary>
        /// シートのドラッグ中認識をリセットする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetFpSpread_MouseUp(object sender, MouseEventArgs e)
        {
            _sheetDragging = false;
        }

        /// <summary>
        /// シートのドラッグコピーを許可しな場合、マウス移動中にCtrlが押されたら
        /// マウス処理制御をスキップすることで、ドラッグ位置やカーソルアイコンの切り替えを行わない。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetFpSpread_MouseMove(object sender, MouseEventArgs e)
        {
            if (!AllowSheetCopy && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                SkipMouseProcessing = true;
            }
        }

        /// <summary>
        /// コマンドキーを処理します。
        /// </summary>
        /// <param name="msg">参照によって渡されるSystem.Windows.Forms.Message 処理するウィンドウメッセージを表します。</param>
        /// <param name="keyData">処理するキーを表すSystem.Windows.Forms.Keys値の1つ。</param>
        /// <returns>文字がコントロールによって処理された場合は True、それ以外の場合は False。</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // シートのドラッグコピーを許可しな場合、ドラッグ中にCtrlが押されたらカーソルをNGにして
            // 後続制御を行わないことで、カーソルアイコンやシートコピー制御を行わない
            if (!AllowSheetCopy && _sheetDragging && (keyData & Keys.Control) == Keys.Control)
            {
                Cursor = Cursors.No;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// GcComboBoxCellType を取得する。セルの CellType が未設定の時、列の CellType を取得する。
        /// </summary>
        /// <param name="row">行インデックス。</param>
        /// <param name="column">列インデックス。</param>
        /// <returns>GcComboBoxCellType。取得できない場合は null を返却する。</returns>
        private GcComboBoxCellType GetGcComboBoxCellType(int row, int column)
        {
            var gcComboCellType = ActiveSheet.Cells[row, column].CellType as GcComboBoxCellType;
            if (gcComboCellType == null)
            {
                gcComboCellType = ActiveSheet.Columns[column].CellType as GcComboBoxCellType;
            }

            return gcComboCellType;
        }

        /// <summary>
        /// テキストの貼り付けが行われた時、ClipboardTextPasting イベントを発生させます。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClipboardPasting(ClipboardPastingEventArgs e)
        {
            base.OnClipboardPasting(e);

            // 貼り付けが拒否された場合は、テキスト貼り付けイベントは行わない
            if (e.Handled)
            {
                return;
            }

            var clipboardText = Clipboard.GetText();
            if (string.IsNullOrEmpty(clipboardText))
            {
                return;
            }

            var textList = new List<List<string>>();
            foreach (var text in clipboardText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
            {
                textList.Add(text.Split('\t').ToList());
            }
            var lastItem = textList.Last();
            if (lastItem.Count == 1 && string.IsNullOrEmpty(lastItem[0]))
            {
                textList.Remove(lastItem);
            }

            var textPastingEventArgs = new ClipboardTextPastingEventArgs(e.Behavior, e.Handled,
                ActiveSheet.ActiveCell, textList, clipboardText);

            OnClipboardTextPasting(textPastingEventArgs);

            e.Handled = textPastingEventArgs.Handled;
        }

        /// <summary>
        /// テキストの貼り付けを行った時、テキスト貼り付けイベントを発生させます。
        /// </summary>
        /// <param name="e">貼り付け動作イベント情報。</param>
        protected virtual void OnClipboardTextPasting(ClipboardTextPastingEventArgs e)
        {
            ClipboardTextPasting?.Invoke(this, e);
        }

        /// <summary>
        /// テキストの貼り付けが行われた時に発生します。
        /// </summary>
        [Browsable(true)]
        [Category("Metroit拡張 アクション")]
        [Description("テキストの貼り付けが行われた時に発生します。")]
        public event ClipboardTextPastingEventHandler ClipboardTextPasting;

        /// <summary>
        /// キーマップ制御の動作設定イベントを発生させます。
        /// </summary>
        /// <param name="e">キーマップ制御マネージャー。</param>
        protected virtual void OnKeyMapActionInitializing(KeyMapActionInitializingEventArgs e)
        {
            KeyMapActionInitializing?.Invoke(this, e);
        }

        /// <summary>
        /// キーマップ制御の動作設定が行われる時に発生します。
        /// </summary>
        [Browsable(true)]
        [Category("Metroit拡張 アクション")]
        [Description("キーマップ制御を初期化する時に発生します。")]
        public event KeyMapActionInitializingEventHandler KeyMapActionInitializing;

        /// <summary>
        /// カスタム検索ダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">CustomSearchDialog を継承した任意の検索ダイアログ。</typeparam>
        public void SearchWithCustomDialog<T>() where T : CustomSearchDialog, new()
        {
            if (CustomSearchDialog != null)
            {
                CustomSearchDialog.Close();
            }

            var dialog = new T();
            dialog.SetSpread(this);
            dialog.Show(FindForm());
        }

        /// <summary>
        /// オープン済みの CustomSearchDialog を取得する。
        /// </summary>
        [NonSerialized]
        private CustomSearchDialog _openedCustonSearchDialog;

        /// <summary>
        /// オープン済みの CustomSearchDialog を取得します。
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public CustomSearchDialog CustomSearchDialog
        {
            get => _openedCustonSearchDialog;
            internal set
            {
                _openedCustonSearchDialog = value;
            }
        }

        /// <summary>
        /// カスタム検索ダイアログが閉じられる前に SearchDialogClosing イベントを発生させます。
        /// </summary>
        /// <param name="sender">カスタム検索ダイアログオブジェクト。</param>
        /// <param name="e">キャンセルオブジェクト。</param>
        internal void PrepareCustomSearchDialogClose(object sender, CancelEventArgs e)
        {
            OnSearchDialogClosing(e);
        }
    }
}
