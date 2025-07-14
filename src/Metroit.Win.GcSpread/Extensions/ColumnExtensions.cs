using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System.Reflection;

namespace Metroit.Win.GcSpread.Extensions
{
    /// <summary>
    /// GrapeCity SPREAD Column の拡張メソッドを提供します。
    /// </summary>
    public static class ColumnExtensions
    {
        /// <summary>
        /// 列が所属している SheetView を取得します。
        /// </summary>
        /// <param name="column">Column オブジェクト。</param>
        /// <returns>列が所属している SheetView。</returns>
        public static SheetView GetSheet(this Column column)
        {
            var pi = column.GetType().GetProperty("SheetView", BindingFlags.Instance | BindingFlags.NonPublic);
            return (SheetView)pi.GetValue(column);
        }

        /// <summary>
        /// 実際に有効となっているセルタイプを取得します。
        /// </summary>
        /// <param name="column">Column オブジェクト。</param>
        /// <returns>実際に有効となっているセルタイプ。</returns>
        /// <remarks>
        /// Column.CellType, SheetView.DefaultStyle.CellType の順に割り当てられているセルタイプを返却します。<br/>
        /// すべてのセルタイプが null の場合、null が返却されます。
        /// </remarks>
        public static ICellType GetActualCellType(this Column column)
        {
            if (column.CellType != null)
            {
                return column.CellType;
            }

            return column.GetSheet().DefaultStyle.CellType;
        }

        /// <summary>
        /// 実際に有効となっているセルタイプをコピーします。
        /// </summary>
        /// <param name="column">Column オブジェクト。</param>
        /// <returns>コピーされたセルタイプ。</returns>
        /// <remarks>
        /// Column.CellType, SheetView.DefaultStyle.CellType の順に割り当てられているセルタイプをコピーします。<br/>
        /// すべてのセルタイプが null の場合、null が返却されます。
        /// </remarks>
        public static ICellType CopyActualCellType(this Column column)
        {
            var cellType = GetActualCellType(column);
            if (cellType == null)
            {
                return null;
            }

            return (ICellType)((BaseCellType)cellType).Clone();
        }
    }
}
