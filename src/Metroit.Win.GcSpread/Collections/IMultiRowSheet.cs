using FarPoint.Win.Spread;

namespace Metroit.Win.GcSpread.Collections
{
    /// <summary>
    /// 1レコードを複数行として扱う インターフェースを提供します。
    /// </summary>
    public interface IMultiRowSheet
    {
        /// <summary>
        /// 扱っているシートを取得します。
        /// </summary>
        SheetView Sheet { get; }

        /// <summary>
        /// 1レコードに対する行数を取得します。
        /// </summary>
        int RowNumber { get; }

        /// <summary>
        /// アイテムデータを取得します。
        /// </summary>
        object Rows { get; }

        /// <summary>
        /// 新しいアイテムを生成します。
        /// </summary>
        /// <returns>新しいアイテム。</returns>
        object NewItem();

        /// <summary>
        /// 行を追加します。
        /// </summary>
        /// <returns>追加された行のアイテム。</returns>
        object AddRow();

        /// <summary>
        /// 行を追加します。
        /// </summary>
        /// <param name="row">追加するアイテム。</param>
        /// <returns>追加されたアイテム</returns>
        object AddRow(object row);

        /// <summary>
        /// 画面の行インデックスから、行を削除します。
        /// </summary>
        /// <param name="index">画面の行インデックス。</param>
        void RemoveRow(int index);

        /// <summary>
        /// 行を削除します。
        /// </summary>
        /// <param name="row">削除するアイテム。</param>
        void RemoveRow(object row);

        /// <summary>
        /// 画面の行インデックスから、アイテムのインデックスを取得します。
        /// </summary>
        /// <param name="index">画面の行インデックス。</param>
        /// <returns>アイテムのインデックス。</returns>
        int GetItemIndex(int index);

        /// <summary>
        /// 画面の行インデックスから、データの行インデックスを取得します。
        /// </summary>
        /// <param name="index">画面の行インデックス。</param>
        /// <returns>データの行インデックス。</returns>
        int GetItemRowNumber(int index);

        /// <summary>
        /// 画面の行インデックスから、アイテムを取得します。
        /// </summary>
        /// <param name="index">画面の行インデックス。</param>
        /// <returns>アイテム。</returns>
        object GetItem(int index);

        /// <summary>
        /// オブジェクトを破棄します。
        /// </summary>
        void Dispose();
    }
}
