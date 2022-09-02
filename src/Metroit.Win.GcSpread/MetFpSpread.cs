using FarPoint.Win.Spread;
using GrapeCity.Win.Spread.InputMan.CellType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// 新しい MetFpSpread インスタンスを生成します。
        /// </summary>
        public MetFpSpread() : base()
        {
            KeyMapActionManager.KeyMapActions.Add(new KeyMapAction(
                new[] { Keys.Control | Keys.F },
                (cell) =>
                {
                    (new CellSearchForm(ActiveSheet)).Show();
                },
                (cell) => true
                ));

            KeyDown += (sender, e) =>
            {
                // キーマップされている処理を強制実行する
                KeyMapActionManager.Execute(e.KeyData, ActiveSheet.ActiveCell, true);
            };

            // NOTE: CellClick, ComboDropDown, ComoCloseUp によって、GcComboBoxCellType がクリックされた時に
            //       自動的にドロップダウンを表示し、ドロップダウンを閉じた時に編集モードを解除する。
            CellClick += (sender, e) =>
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

                prevEditModePermanent = EditModePermanent;
                prevAutoDropDown = gcComboCellType.DropDown.AutoDropDown;
                EditModePermanent = true;
                gcComboCellType.DropDown.AutoDropDown = true;
            };

            ComboDropDown += (sender, e) =>
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
            };

            ComboCloseUp += (sender, e) =>
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
            };
        }

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
        /// コントロールが最初に作成されると呼び出されます。
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            OnKeyMapActionInitializing(KeyMapActionManager);
        }

        /// <summary>
        /// テキストの貼り付けが行われた時、ClipboardPastingTextStrings イベントを発生させます。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClipboardPasting(ClipboardPastingEventArgs e)
        {
            base.OnClipboardPasting(e);

            var clipboardText = Clipboard.GetText();
            if (string.IsNullOrEmpty(clipboardText))
            {
                return;
            }

            var textList = new List<string[]>();
            foreach (var text in clipboardText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
            {
                if (string.IsNullOrEmpty(text))
                {
                    continue;
                }
                textList.Add(text.Split('\t'));
            }
            OnClipboardTextPasting(e, ActiveSheet.ActiveCell, textList);
        }

        /// <summary>
        /// 貼り付けた文字列情報を含んだ文字列貼り付けイベントを呼び出します。
        /// </summary>
        /// <param name="e">貼り付け動作イベント情報。</param>
        /// <param name="cell">貼り付け動作を行った Cell オブジェクト。</param>
        /// <param name="textList">ペーストした文字列情報。</param>
        protected virtual void OnClipboardTextPasting(ClipboardPastingEventArgs e, Cell cell, List<string[]> textList)
        {
            ClipboardTextPasting?.Invoke(this, e, cell, textList);
        }

        /// <summary>
        /// ClipboardTextPasting イベントを発生させる為のデリゲート。
        /// </summary>
        /// <param name="sender">実行発生オブジェクト。</param>
        /// <param name="e">貼り付け動作イベント情報。</param>
        /// <param name="cell">貼り付け動作を行った Cell オブジェクト。</param>
        /// <param name="textList">ペーストした文字列情報。</param>
        public delegate void OnClipboardTextPastingEventHandler(object sender, ClipboardPastingEventArgs e, Cell cell, List<string[]> textList);

        /// <summary>
        /// テキストの貼り付けが行われた時に発生します。
        /// </summary>
        [Browsable(true)]
        [Category("Metroit拡張 アクション")]
        [Description("テキストの貼り付けが行われた時に発生します。")]
        public event OnClipboardTextPastingEventHandler ClipboardTextPasting;

        /// <summary>
        /// キーマップ制御の動作設定を行います。
        /// </summary>
        /// <param name="manager">KeyMapActionManager オブジェクト。</param>
        protected virtual void OnKeyMapActionInitializing(KeyMapActionManager manager)
        {
            KeyMapActionInitializing?.Invoke(this, manager);
        }

        /// <summary>
        /// KeyMapActionInitializing イベントを発生させる為のデリゲート。
        /// </summary>
        /// <param name="sender">実行発生オブジェクト。</param>
        /// <param name="manager">KeyMapActionManager オブジェクト。</param>
        public delegate void OnKeyMapActionInitializingEventHandler(object sender, KeyMapActionManager manager);

        /// <summary>
        /// キーマップ制御の動作設定が行われる時に発生します。
        /// </summary>
        [Browsable(true)]
        [Category("Metroit拡張 アクション")]
        [Description("キーマップ制御を初期化する時に発生します。")]
        public OnKeyMapActionInitializingEventHandler KeyMapActionInitializing;
    }
}
