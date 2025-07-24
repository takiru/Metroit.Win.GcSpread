using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Metroit.Win.GcSpread.Extensions
{
    /// <summary>
    /// GrapeCity SPREAD Row の拡張メソッドを提供します。
    /// </summary>
    public static class RowExtensions
    {
        /// <summary>
        /// 行が所属している SheetView を取得します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <returns>行が所属している SheetView。</returns>
        public static SheetView GetSheet(this Row row)
        {
            var pi = row.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => typeof(SheetView).IsAssignableFrom(x.PropertyType))
                .First();
            return (SheetView)pi.GetValue(row);
        }

        /// <summary>
        /// 行インデックスに対応するデータソースの行インデックスを取得します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <returns>データソースの行インデックス。</returns>
        public static int GetDataRowFromViewRow(this Row row)
        {
            return row.GetSheet().GetDataRowFromViewRow(row.Index);
        }

        /// <summary>
        /// データソースの指定した行インデックスに対応するシートの行インデックスを取得します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <param name="dataSourceRow">データソースの行インデックス。</param>
        /// <returns>シートの行インデックス。</returns>
        public static int GetViewRowFromDataRow(this Row row, int dataSourceRow)
        {
            return row.GetSheet().GetViewRowFromDataRow(dataSourceRow);
        }

        /// <summary>
        /// 指定した DataField の列インデックスを取得します。
        /// 同一の DataField を有する列が複数あった場合、最初に見つかった列のインデックスを返却します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <returns>列インデックス。</returns>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public static int GetColumnIndexFromDataField(this Row row, string dataField)
        {
            return row.GetSheet().GetColumnIndexFromDataField(dataField);
        }

        /// <summary>
        /// 指定した DataField のセルオブジェクトを取得します。
        /// 同一の DataField を有する列が複数あった場合、最初に見つかった列のセルオブジェクトを返却します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <returns>セルオブジェクト。</returns>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public static Cell GetCellFromDataField(this Row row, string dataField)
        {
            return row.GetSheet().GetCellFromDataField(dataField, row.Index);
        }

        /// <summary>
        /// 指定した DataField のセルオブジェクトの値を取得します。
        /// 同一の DataField を有する列が複数あった場合、最初に見つかった列のセルオブジェクトの値を返却します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <returns>セル値。</returns>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public static object GetValueFromDataField(this Row row, string dataField)
        {
            return row.GetSheet().GetValueFromDataField(dataField, row.Index);
        }

        /// <summary>
        /// 条件に応じた行のロックを制御します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <param name="locked">ロックするかどうか。</param>
        /// <param name="lockConditions">ロック条件。</param>
        public static void LockRow(this Row row, bool locked, List<Func<Row, bool>> lockConditions = null)
        {
            if (lockConditions == null)
            {
                row.Locked = locked;
                return;
            }

            foreach (var lockCondition in lockConditions)
            {
                if (lockCondition.Invoke(row))
                {
                    row.Locked = locked;
                    return;
                }
            }
        }

        /// <summary>
        /// 条件に応じた行のロックを制御します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <param name="locked">ロックするかどうか。</param>
        /// <param name="lockCondition">ロック条件。</param>
        public static void LockRow(this Row row, bool locked, Func<Row, bool> lockCondition = null)
        {
            LockRow(row, locked, new List<Func<Row, bool>>() { lockCondition });
        }

        /// <summary>
        /// 指定した DataField のセルをアクティブにします。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public static void SetActiveCellFromDataField(this Row row, string dataField)
        {
            row.GetSheet().SetActiveCellFromDataField(row.Index, dataField);
        }

        /// <summary>
        /// 指定したセルをアクティブにしてスクロール位置を切り替え、フォーカスします。
        /// </summary>
        /// <param name="row">行インデックス。</param>
        /// <param name="column">列インデックス。</param>
        /// <param name="verticalPosition">縦スクロール位置。</param>
        /// <param name="horizontalPosition">横スクロール位置。</param>
        public static void SetActiveCellWithFocus(this Row row, int column,
                                          VerticalPosition verticalPosition = VerticalPosition.Nearest,
                                          HorizontalPosition horizontalPosition = HorizontalPosition.Nearest)
        {
            row.GetSheet().SetActiveCellWithFocus(row.Index, column, verticalPosition, horizontalPosition);
        }

        /// <summary>
        /// 指定した DataField のセルをアクティブにしてスクロール位置を切り替え、フォーカスを設定します。
        /// </summary>
        /// <param name="row">行インデックス。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <param name="verticalPosition">縦スクロール位置。</param>
        /// <param name="horizontalPosition">横スクロール位置。</param>
        public static void SetActiveCellWithFocusFromDataField(this Row row, string dataField,
                                          VerticalPosition verticalPosition = VerticalPosition.Nearest,
                                          HorizontalPosition horizontalPosition = HorizontalPosition.Nearest)
        {
            row.GetSheet().SetActiveCellWithFocusFromDataField(row.Index, dataField, verticalPosition, horizontalPosition);
        }

        /// <summary>
        /// 条件に応じたセルのロックを制御します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <param name="locked">ロックするかどうか。</param>
        /// <param name="lockConditions">ロック条件。</param>
        /// <param name="column">開始列インデックス。0 未満の場合は 1 列目から対象とします。</param>
        /// <param name="count">制御を行う列数。0 未満の場合は最終列まで対象とします。</param>
        public static void LockCells(this Row row, bool locked, List<Func<Cell, bool>> lockConditions = null, int column = -1, int count = -1)
        {
            if (count == 0)
            {
                return;
            }

            var sheet = row.GetSheet();
            var columnIndex = column < 0 ? 0 : column;
            var columnCount = count < 0 ? sheet.ColumnCount : count;
            var columnEndIndex = columnIndex + columnCount - 1 > sheet.ColumnCount - 1 ? sheet.ColumnCount - 1 : columnIndex + columnCount - 1;

            for (var i = columnIndex; i < columnEndIndex; i++)
            {
                sheet.Cells[row.Index, i].LockCell(locked, lockConditions);
            }
        }

        /// <summary>
        /// 行が編集可能かどうか取得します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <returns>編集可能な場合は true, それ以外は false を返却します。</returns>
        /// <remarks>
        /// <see cref="SheetView.Protect"/> が true で、<paramref name="row"/> の <see cref="BaseStyleInfo.Locked"/> が true の場合は編集不可とみなします。<br/>
        /// いずれにも満たないとき、編集可能とみなします。
        /// </remarks>
        public static bool CanEditable(this Row row)
        {
             // シートがプロテクトされていて、行のロック状態がロックされている場合は編集不可
            var sheet = row.GetSheet();
            var rowLocked = sheet.GetStyleInfo(row.Index, -1).Locked;
            if (sheet.Protect && rowLocked)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 行が空行かどうかを取得します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <param name="ignoreDataFields">検証を無視する DataField 値。</param>
        /// <param name="validateHiddenColumn">非表示列も検証するかどうか。</param>
        /// <returns>空行の場合は true, それ以外は false を返却します。</returns>
        /// <remarks>
        /// <see cref="Cell.Value"/> が null でないときは非空行とみなします。<br/>
        /// <see cref="Cell.Text"/> が null でないときは非空行とみなします。<br/>
        /// <see cref="Cell.Text"/> が <see cref="string.Empty"/> でないときは非空行とみなします。<br/>
        /// いずれにも満たないとき、空行とみなします。
        /// </remarks>
        public static bool IsEmptyRow(this Row row, string[] ignoreDataFields = null, bool validateHiddenColumn = true)
        {
            var sheet = row.GetSheet();

            foreach (Column column in sheet.Columns)
            {
                // 無視する列は制御しない
                if (ignoreDataFields.Contains(column.DataField))
                {
                    continue;
                }

                // 非表示列は制御しない
                if (!validateHiddenColumn && !column.Visible)
                {
                    continue;
                }

                var cell = sheet.Cells[row.Index, column.Index];
                if (cell.Value != null)
                {
                    return false;
                }
                if (cell.Text != string.Empty)
                {
                    return false;
                }
                if (cell.Text != null)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 実際に有効となっているセルタイプを取得します。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <returns>実際に有効となっているセルタイプ。</returns>
        /// <remarks>
        /// <see cref="SheetView.GetStyleInfo(int, -1)"/> から取得されます。
        /// </remarks>
        public static ICellType GetActualCellType(this Row row)
        {
            return row.GetSheet().GetStyleInfo(row.Index, -1).CellType;
        }

        /// <summary>
        /// 実際に有効となっているセルタイプをコピーします。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <returns>コピーされたセルタイプ。</returns>
        /// <remarks>
        /// <see cref="SheetView.GetStyleInfo(int, -1)"/> から取得されます。
        /// </remarks>
        public static ICellType CopyActualCellType(this Row row)
        {
            var cellType = GetActualCellType(row);
            if (cellType == null)
            {
                throw new ArgumentException("CellType not found.");
            }

            return (ICellType)((BaseCellType)cellType).Clone();
        }
    }
}
