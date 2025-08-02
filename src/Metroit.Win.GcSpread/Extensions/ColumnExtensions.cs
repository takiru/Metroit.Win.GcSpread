using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Linq;
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
            var pi = column.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => typeof(SheetView).IsAssignableFrom(x.PropertyType))
                .First();
            return (SheetView)pi.GetValue(column);
        }

        /// <summary>
        /// 実際に有効となっているセルタイプを取得します。
        /// </summary>
        /// <param name="column">Column オブジェクト。</param>
        /// <returns>実際に有効となっているセルタイプ。</returns>
        /// <remarks>
        /// <see cref="SheetView.GetStyleInfo(int, int)"/> から取得されます。
        /// </remarks>
        public static ICellType GetActualCellType(this Column column)
        {
            return column.GetSheet().GetStyleInfo(-1, column.Index).CellType;
        }

        /// <summary>
        /// 実際に有効となっているセルタイプをコピーします。
        /// </summary>
        /// <param name="column">Column オブジェクト。</param>
        /// <returns>コピーされたセルタイプ。</returns>
        /// <remarks>
        /// <see cref="SheetView.GetStyleInfo(int, int)"/> から取得されたセルタイプをコピーします。
        /// </remarks>
        public static ICellType CopyActualCellType(this Column column)
        {
            var cellType = GetActualCellType(column);
            if (cellType == null)
            {
                throw new ArgumentException("CellType not found.");
            }

            return (ICellType)((BaseCellType)cellType).Clone();
        }
    }
}
