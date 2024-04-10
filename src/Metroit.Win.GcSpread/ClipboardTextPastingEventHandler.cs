namespace Metroit.Win.GcSpread
{
    /// <summary>
    /// ClipboardTextPasting イベントを発生させる為のデリゲート。
    /// </summary>
    /// <param name="sender">実行発生オブジェクト。</param>
    /// <param name="e">貼り付け動作イベント情報。</param>
    public delegate void ClipboardTextPastingEventHandler(object sender, ClipboardTextPastingEventArgs e);
}
