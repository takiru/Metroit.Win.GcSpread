using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Metroit.Win.GcSpread.Extensions
{
    /// <summary>
    /// GrapeCity SPREAD SheetView の拡張メソッドを提供します。
    /// </summary>
    public static class SheetViewExtensions
    {
        /// <summary>
        /// シートの指定した行インデックスに対応するデータソースの行インデックスを取得します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="row">シートの行インデックス。</param>
        /// <returns>データソースの行インデックス。</returns>
        public static int GetDataRowFromViewRow(this SheetView sheet, int row)
        {
            var model = (IDataSourceSupport)sheet.Models.Data;
            var modelIndex = sheet.GetModelRowFromViewRow(row);
            var sourceIndex = model.GetDataRowFromModelRow(modelIndex);

            return sourceIndex;
        }

        /// <summary>
        /// データソースの指定した行インデックスに対応するシートの行インデックスを取得します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="row">データソースの行インデックス。</param>
        /// <returns>シートの行インデックス。</returns>
        public static int GetViewRowFromDataRow(this SheetView sheet, int row)
        {
            var model = (IDataSourceSupport)sheet.Models.Data;
            var modelIndex = model.GetModelRowFromDataRow(row);
            var sheetIndex = sheet.GetViewRowFromModelRow(modelIndex);

            return sheetIndex;
        }

        /// <summary>
        /// 指定した DataField の列インデックスを取得します。
        /// 同一の DataField を有する列が複数あった場合、最初に見つかった列のインデックスを返却します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <returns>列インデックス。</returns>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public static int GetColumnIndexFromDataField(this SheetView sheet, string dataField)
        {
            var column = sheet.Columns.Cast<Column>().Where(x => x.DataField == dataField).FirstOrDefault();
            if (column == null)
            {
                throw new ArgumentException("列が見つかりません。", $"{nameof(dataField)}:{dataField}");
            }

            return column.Index;
        }

        /// <summary>
        /// 指定した DataField の列オブジェクトを取得します。
        /// 同一の DataField を有する列が複数あった場合、最初に見つかった列のオブジェクトを返却します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <returns>列オブジェクト。</returns>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public static Column GetColumnFromDataField(this SheetView sheet, string dataField)
        {
            return sheet.Columns[GetColumnIndexFromDataField(sheet, dataField)];
        }

        /// <summary>
        /// 指定した DataField のセルオブジェクトを取得します。
        /// 行を指定しない場合、アクティブな行から取得します。
        /// 同一の DataField を有する列が複数あった場合、最初に見つかった列のセルオブジェクトを返却します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <param name="row">行インデックス。0 未満の場合はアクティブな行を対象とします。</param>
        /// <returns>セルオブジェクト。</returns>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public static Cell GetCellFromDataField(this SheetView sheet, string dataField, int row = -1)
        {
            var rowIndex = row < 0 ? sheet.ActiveRowIndex : row;
            var columnIndex = GetColumnIndexFromDataField(sheet, dataField);

            return sheet.Cells[rowIndex, columnIndex];
        }

        /// <summary>
        /// 指定した DataField のセルオブジェクトの値を取得します。
        /// 行を指定しない場合、アクティブな行から取得します。
        /// 同一の DataField を有する列が複数あった場合、最初に見つかった列のセルオブジェクトの値を返却します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <param name="row">行インデックス。0 未満の場合はアクティブな行を対象とします。</param>
        /// <returns>セル値。</returns>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public static object GetValueFromDataField(this SheetView sheet, string dataField, int row = -1)
        {
            return GetCellFromDataField(sheet, dataField, row)?.Value;
        }

        /// <summary>
        /// 条件に応じた行のロックを制御します。
        /// 開始行インデックスが指定された場合、該当行からロックを制御します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="locked">ロックするかどうか。</param>
        /// <param name="lockConditions">ロック条件。</param>
        /// <param name="row">開始行インデックス。0 未満の場合は 1 行目から対象とします。</param>
        /// <param name="count">制御を行う行数。0 未満の場合は最終行まで対象とします。</param>
        public static void LockRows(this SheetView sheet, bool locked, List<Func<Row, bool>> lockConditions = null, int row = -1, int count = -1)
        {
            if (count == 0)
            {
                return;
            }

            var rowIndex = row < 0 ? 0 : row;
            var rowCount = count < 0 ? sheet.RowCount : count;
            var rowEndIndex = rowIndex + rowCount - 1 > sheet.RowCount - 1 ? sheet.RowCount - 1 : rowIndex + rowCount - 1;

            for (var i = rowIndex; i < rowEndIndex; i++)
            {
                sheet.Rows[i].LockRow(locked, lockConditions);
            }
        }

        /// <summary>
        /// 条件に応じた行のロックを制御します。
        /// 開始行インデックスが指定された場合、該当行からロックを制御します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="locked">ロックするかどうか。</param>
        /// <param name="lockCondition">ロック条件。</param>
        /// <param name="row">開始行インデックス。0 未満の場合は 1 行目から対象とします。</param>
        /// <param name="count">制御を行う行数。0 未満の場合は最終行まで対象とします。</param>
        public static void LockRows(this SheetView sheet, bool locked, Func<Row, bool> lockCondition = null, int row = -1, int count = -1)
        {
            sheet.LockRows(locked, new List<Func<Row, bool>>() { lockCondition }, row, count);
        }

        /// <summary>
        /// 全行のロック設定をリセットし、デフォルト行のロック設定を継承させます。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        public static void ResetLockedAllRows(this SheetView sheet)
        {
            foreach (Row row in sheet.Rows)
            {
                row.ResetLocked();
            }
        }

        /// <summary>
        /// 指定したセルをアクティブにしてスクロール位置を切り替えます。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="row">行インデックス。</param>
        /// <param name="column">列インデックス。</param>
        /// <param name="verticalPosition">縦スクロール位置。</param>
        /// <param name="horizontalPosition">横スクロール位置。</param>
        public static void SetActiveCell(this SheetView sheet, int row, int column,
            VerticalPosition verticalPosition, HorizontalPosition horizontalPosition)
        {
            sheet.SetActiveCell(row, column);
            sheet.FpSpread.ShowActiveCell(verticalPosition, horizontalPosition);
        }

        /// <summary>
        /// 指定したセルをアクティブにしてスクロール位置を切り替え、フォーカスします。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="row">行インデックス。</param>
        /// <param name="column">列インデックス。</param>
        /// <param name="verticalPosition">縦スクロール位置。</param>
        /// <param name="horizontalPosition">横スクロール位置。</param>
        public static void SetActiveCellWithFocus(this SheetView sheet, int row, int column,
            VerticalPosition verticalPosition = VerticalPosition.Nearest,
            HorizontalPosition horizontalPosition = HorizontalPosition.Nearest)
        {
            sheet.SetActiveCell(row, column);
            sheet.FpSpread.ShowActiveCell(verticalPosition, horizontalPosition);
            sheet.FpSpread.Focus();
        }

        /// <summary>
        /// 指定した DataField のセルをアクティブにします。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="row">行インデックス。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <param name="verticalPosition">縦スクロール位置。</param>
        /// <param name="horizontalPosition">横スクロール位置。</param>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public static void SetActiveCellFromDataField(this SheetView sheet, int row, string dataField,
            VerticalPosition verticalPosition = VerticalPosition.Nearest,
            HorizontalPosition horizontalPosition = HorizontalPosition.Nearest)
        {
            SetActiveCell(sheet, row, GetColumnIndexFromDataField(sheet, dataField), verticalPosition, horizontalPosition);
        }

        /// <summary>
        /// 指定した DataField のセルをアクティブにしてスクロール位置を切り替え、フォーカスを設定します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="row">行インデックス。</param>
        /// <param name="dataField">DataField 値。</param>
        /// <param name="verticalPosition">縦スクロール位置。</param>
        /// <param name="horizontalPosition">横スクロール位置。</param>
        public static void SetActiveCellWithFocusFromDataField(this SheetView sheet, int row, string dataField,
            VerticalPosition verticalPosition = VerticalPosition.Nearest,
            HorizontalPosition horizontalPosition = HorizontalPosition.Nearest)
        {
            SetActiveCellWithFocus(sheet, row, GetColumnIndexFromDataField(sheet, dataField), verticalPosition, horizontalPosition);
        }

        /// <summary>
        /// 現在のシートをコピーします。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <returns>コピーした SheetView オブジェクト。</returns>
        public static SheetView Copy(this SheetView sheet)
        {
            const string elementName = "NewSheet";

            return (SheetView)Serializer.LoadObjectXml(typeof(SheetView), Serializer.GetObjectXml(sheet, elementName), elementName);
        }

        /// <summary>
        /// 現在のシートをコピーし、指定した FpSpread へ追加します。
        /// </summary>
        /// <param name="sheet">SheetView オブジェクト。</param>
        /// <param name="fpSpread">FpSpread オブジェクト。</param>
        /// <param name="sheetName">シート名。</param>
        public static void CopyTo(this SheetView sheet, FpSpread fpSpread, string sheetName)
        {
            var newSheetView = Copy(sheet);
            newSheetView.SheetName = sheetName;
            fpSpread.Sheets.Add(newSheetView);
        }

        /// <summary>
        /// DataField プロパティを保持したまま列の移動を行います。
        /// 列タイトルのセル結合を保持するため、SheetView.MoveColumn() の第四引数 moveContent は true として実行されます。
        /// </summary>
        /// <param name="sheetView">SheetView オブジェクト。</param>
        /// <param name="fromIndex">移動元の列インデックス。</param>
        /// <param name="toIndex">移動先の列インデックス。</param>
        /// <param name="columnCount">移動する列数。</param>
        /// <returns>列の移動を行った情報のリスト。移動が行われなかった時は空のリストを返却します。</returns>
        public static List<ColumnMoveResult> MoveColumnKeepDataField(this SheetView sheetView,
            int fromIndex, int toIndex, int columnCount)
        {
            var result = new List<ColumnMoveResult>();

            // 移動する必要がない
            if (fromIndex == toIndex)
            {
                return result;
            }

            // 列を後ろに移動する時
            if (fromIndex < toIndex)
            {
                // 移動を指定した列分を把握
                // NOTE: MoveColumn() の仕様により、columnCount > 1 の時、toIndex の位置は、移動する列の最後の列となる
                var lastToIndex = 0;
                for (var i = fromIndex; i < fromIndex + columnCount; i++)
                {
                    lastToIndex = (toIndex - columnCount) + (i - fromIndex) + 1;
                    result.Add(new ColumnMoveResult(i, i, lastToIndex, sheetView.Columns[i].DataField));
                }

                // 移動することによって前に移動する列分を把握
                var intervalStartInex = fromIndex + columnCount;
                for (var i = intervalStartInex; i <= lastToIndex; i++)
                {
                    result.Add(new ColumnMoveResult(i, i, i - columnCount, sheetView.Columns[i].DataField));
                }
            }

            // 列を前に移動する時
            if (fromIndex > toIndex)
            {
                // 移動を指定した列分を把握
                // NOTE: MoveColumn() の仕様により、columnCount > 1 の時、toIndex の位置は、移動する列の最初の列となる
                for (var i = fromIndex; i < fromIndex + columnCount; i++)
                {
                    var lastToIndex = toIndex + (i - fromIndex);
                    result.Add(new ColumnMoveResult(i, i, lastToIndex, sheetView.Columns[i].DataField));
                }

                // 移動することによって後ろに移動する列分を把握
                var intervalEndIndex = fromIndex - 1;
                for (var i = toIndex; i <= intervalEndIndex; i++)
                {
                    result.Add(new ColumnMoveResult(i, i, i + columnCount, sheetView.Columns[i].DataField));
                }
            }

            // 実際の列移動とバインドし直し
            sheetView.MoveColumn(fromIndex, toIndex, columnCount, true);
            foreach (var columnMoveResult in result)
            {
                sheetView.BindDataColumn(columnMoveResult.AfterColumnIndex, columnMoveResult.DataField);
            }

            return result;
        }
    }
}
