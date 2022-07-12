using FarPoint.Win.Spread;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Metroit.Win.GcSpread.Extensions
{
    /// <summary>
    /// GrapeCity SPREAD Cell の拡張メソッドを提供します。
    /// </summary>
    public static class CellExtensions
    {
        /// <summary>
        /// セルが所属している SheetView を取得します。
        /// </summary>
        /// <param name="cell">Cell オブジェクト。</param>
        /// <returns>セルが所属している SheetView。</returns>
        public static SheetView GetSheet(this Cell cell)
        {
            var pi = cell.GetType().GetProperty("SheetView", BindingFlags.Instance | BindingFlags.NonPublic);
            return (SheetView)pi.GetValue(cell);
        }

        /// <summary>
        /// セルが編集可能かどうか取得します。
        /// </summary>
        /// <param name="cell">Cell オブジェクト。</param>
        /// <returns>true:編集可能, false:編集不可。</returns>
        public static bool CanEditable(this Cell cell)
        {
            var sheet = cell.GetSheet();

            // シートがプロテクトされていない場合は編集可能
            if (!sheet.Protect)
            {
                return true;
            }

            // シートがプロテクトされているが、セルのロック状態がロックされていない場合は編集可能
            if (!sheet.GetStyleInfo(cell.Row.Index, cell.Column.Index).Locked)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 条件に応じたセルのロックを制御します。
        /// </summary>
        /// <param name="cell">Cell オブジェクト。</param>
        /// <param name="locked">ロックするかどうか。</param>
        /// <param name="lockConditions">ロック条件。</param>
        public static void LockCell(this Cell cell, bool locked, List<Func<Cell, bool>> lockConditions = null)
        {
            if (lockConditions == null)
            {
                cell.Locked = locked;
                return;
            }

            foreach (var lockCondition in lockConditions)
            {
                if (lockCondition.Invoke(cell))
                {
                    cell.Locked = locked;
                    return;
                }
            }
        }

        /// <summary>
        /// 条件に応じたセルのロックを制御します。
        /// </summary>
        /// <param name="cell">Cell オブジェクト。</param>
        /// <param name="locked">ロックするかどうか。</param>
        /// <param name="lockCondition">ロック条件。</param>
        public static void LockCell(this Cell cell, bool locked, Func<Cell, bool> lockCondition = null)
        {
            LockCell(cell, locked, new List<Func<Cell, bool>>() { lockCondition });
        }
    }
}
