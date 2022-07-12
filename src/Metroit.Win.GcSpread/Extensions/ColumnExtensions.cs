using FarPoint.Win.Spread;
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
    }
}
