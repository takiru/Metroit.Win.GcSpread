using FarPoint.Win.Spread;
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
                Console.WriteLine($"{e.KeyData}");
                Console.WriteLine($"{e.KeyCode}");
                KeyMapActionManager.Execute(e.KeyData, ActiveSheet.ActiveCell, true);
            };
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
