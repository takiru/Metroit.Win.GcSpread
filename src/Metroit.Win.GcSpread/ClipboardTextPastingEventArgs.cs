using FarPoint.Win.Spread;
using System.Collections.Generic;

namespace Metroit.Win.GcSpread
{
    /// <summary>
    /// ClipboardTextPasting イベントが発生した時のイベント引数を提供します。
    /// </summary>
    public class ClipboardTextPastingEventArgs
    {
        /// <summary>
        /// 動作を取得します。
        /// </summary>
        public ClipboardBehavior Behavior { get; } = ClipboardBehavior.Unknown;

        /// <summary>
        /// 貼り付けが処理されたか、またはデフォルトの貼り付けアクションを実行する必要があるかを取得または設定します。
        /// </summary>
        public bool Handled { get; set; }

        /// <summary>
        /// 貼り付けが行われるアクティブセルを取得します。
        /// </summary>
        public Cell Cell { get; } = null;

        /// <summary>
        /// 貼り付けが行われるテキストから、改行およびタブで区切ったテキストを取得します。
        /// 常に改行を異なる行、タブを異なる列として扱った場合のテキストとなります。
        /// ダブルクォーテーションによるテキストの囲みは1つのテキストとして扱われません。
        /// </summary>
        public IReadOnlyList<IReadOnlyList<string>> Texts { get; } = null;

        /// <summary>
        /// 貼り付けが行われるテキストを取得します。
        /// </summary>
        public string Raw { get; } = null;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="behavior">動作。</param>
        /// <param name="handled">貼り付けが処理されたか、またはデフォルトの貼り付けアクションを実行する必要があるか。</param>
        /// <param name="cell">貼り付けが行われるアクティブセル。</param>
        /// <param name="texts">貼り付けが行われる改行/タブ区切りのテキスト。</param>
        /// <param name="raw">貼り付けが行われるテキスト。</param>
        public ClipboardTextPastingEventArgs(ClipboardBehavior behavior, bool handled, Cell cell, IReadOnlyList<IReadOnlyList<string>> texts, string raw)
        {
            Behavior = behavior;
            Handled = handled;
            Cell = cell;
            Texts = texts;
            Raw = raw;
        }
    }
}
