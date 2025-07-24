using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using GrapeCity.Spreadsheet.Win;
using GrapeCity.Win.Spread.InputMan.CellType;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var pi = cell.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => typeof(SheetView).IsAssignableFrom(x.PropertyType))
                .First();
            return (SheetView)pi.GetValue(cell);
        }

        /// <summary>
        /// セルが編集可能かどうか取得します。
        /// </summary>
        /// <param name="cell">Cell オブジェクト。</param>
        /// <returns>編集可能な場合は true, それ以外は false を返却します。</returns>
        /// <remarks>
        /// <see cref="EditBaseCellType.Static"/>、<see cref="RichTextCellType.Static"/>、<see cref="InputManCellTypeBase.Static"/> が true の場合は編集不可とみなします。<br/>
        /// <see cref="SheetView.Protect"/> が true で、<paramref name="cell"/> の <see cref="BaseStyleInfo.Locked"/> が true の場合は編集不可とみなします。<br/>
        /// いずれにも満たないとき、編集可能とみなします。
        /// </remarks>
        public static bool CanEditable(this Cell cell)
        {
            // セルタイプに Static プロパティを有しており、Static = True のものは編集不可
            if (cell.CellType != null)
            {
                if (cell.CellType is EditBaseCellType editBaseCellType)
                {
                    if (editBaseCellType.Static)
                    {
                        return false;
                    }
                }

                if (cell.CellType is RichTextCellType richTextCellType)
                {
                    if (richTextCellType.Static)
                    {
                        return false;
                    }
                }

                if (cell.CellType is InputManCellTypeBase inputManCellTypeBase)
                {
                    if (inputManCellTypeBase.Static)
                    {
                        return false;
                    }
                }
            }

            // シートがプロテクトされていて、セルのロック状態がロックされている場合は編集不可
            var sheet = cell.GetSheet();
            var cellLocked = sheet.GetStyleInfo(cell.Row.Index, cell.Column.Index).Locked;
            if (sheet.Protect && cellLocked)
            {
                return false;
            }

            return true;
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

        /// <summary>
        /// 実際に有効となっているセルタイプを取得します。
        /// </summary>
        /// <param name="cell">Cell オブジェクト。</param>
        /// <returns>実際に有効となっているセルタイプ。</returns>
        /// <remarks>
        /// <see cref="SheetView.GetStyleInfo(int, int)"/> から取得されます。
        /// </remarks>
        public static ICellType GetActualCellType(this Cell cell)
        {
            return cell.GetSheet().GetStyleInfo(cell.Row.Index, cell.Column.Index).CellType;
        }

        /// <summary>
        /// 実際に有効となっているセルタイプをコピーします。
        /// </summary>
        /// <param name="cell">Cell オブジェクト。</param>
        /// <returns>コピーされたセルタイプ。</returns>
        /// <remarks>
        /// <see cref="SheetView.GetStyleInfo(int, int)"/> から取得されたセルタイプをコピーします。
        /// </remarks>
        public static ICellType CopyActualCellType(this Cell cell)
        {
            var cellType = GetActualCellType(cell);
            if (cellType == null)
            {
                throw new ArgumentException("CellType not found.");
            }

            return (ICellType)((BaseCellType)cellType).Clone();
        }
    }
}
