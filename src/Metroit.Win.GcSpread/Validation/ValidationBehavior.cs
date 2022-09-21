using Metroit.Win.GcSpread.Extensions;
using FarPoint.Win.Spread;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Metroit.Win.GcSpread.Validation
{
    /// <summary>
    /// 値検証の振る舞いを提供します。
    /// </summary>
    public class ValidationBehavior
    {
        /// <summary>
        /// 値の妥当性を検証する振る舞いを取得します。
        /// </summary>
        /// <returns></returns>
        public Func<SheetView, Cell, bool> Validate { get; } = null;

        /// <summary>
        /// エラーメッセージを取得します。
        /// </summary>
        /// <returns></returns>
        public string ErrorMessage { get; } = null;

        /// <summary>
        /// エラー時にフォーカスする DataField 値を取得します。
        /// </summary>
        /// <returns></returns>
        public string ErrorDataField { get; private set; } = string.Empty;

        /// <summary>
        /// エラー時にフォーカスする列インデックスを取得します。
        /// </summary>
        public int ErrorColumn { get; private set; } = -1;

        /// <summary>
        /// 新しい ValidationBehavior インスタンスを生成します。
        /// </summary>
        /// <param name="validate">妥当かどうかを検証する処理。</param>
        /// <param name="errorMessage">エラーメッセージ。</param>
        public ValidationBehavior(Func<SheetView, Cell, bool> validate,
                       string errorMessage = null)
        {
            Validate = validate;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 新しい ValidationBehavior インスタンスを生成します。
        /// </summary>
        /// <param name="validate">妥当かどうかを検証する処理。</param>
        /// <param name="errorMessage">エラーメッセージ。</param>
        /// <param name="errorDataField">エラー時にフォーカスする DataField 値。</param>
        public ValidationBehavior(Func<SheetView, Cell, bool> validate,
                       string errorMessage, string errorDataField) : this(validate, errorMessage)
        {
            SetErrorDataField(errorDataField);
        }

        /// <summary>
        /// 新しい ValidationBehavior インスタンスを生成します。
        /// </summary>
        /// <param name="validate">妥当かどうかを検証する処理。</param>
        /// <param name="errorMessage">エラーメッセージ。</param>
        /// <param name="errorColumn">エラー時にフォーカスする列インデックス。</param>
        public ValidationBehavior(Func<SheetView, Cell, bool> validate,
                       string errorMessage, int errorColumn) : this(validate, errorMessage)
        {
            SetErrorColumn(errorColumn);
        }

        /// <summary>
        /// null を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="name">項目名。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotNullBehavior(string name)
        {
            return new ValidationBehavior(
                (sheet, cell) => !IsNull(cell.Value),
                $"{name}を入力してください。");
        }

        /// <summary>
        /// null を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="name">項目名。</param>
        /// <param name="errorDataField">エラー時にフォーカスする DataField 値。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotNullBehavior(string name, string errorDataField)
        {
            var result = CreateNotNullBehavior(name);
            result.SetErrorDataField(errorDataField);
            return result;
        }

        /// <summary>
        /// null を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="name">項目名。</param>
        /// <param name="errorColumn">エラー時にフォーカスする列インデックス。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotNullBehavior(string name, int errorColumn)
        {
            var result = CreateNotNullBehavior(name);
            result.SetErrorColumn(errorColumn);
            return result;
        }

        /// <summary>
        /// 半角英数記号以外を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="name">項目名。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateHalfWidthCharsBehavior(string name)
        {
            return new ValidationBehavior(
                (sheet, cell) => IsOnlyHalfWidthChars(cell.Value?.ToString()),
                $"{name}に半角以外の文字が入力されています。");
        }

        /// <summary>
        /// 半角英数記号以外を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="name">項目名。</param>
        /// <param name="errorDataField">エラー時にフォーカスする DataField 値。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateHalfWidthCharsBehavior(string name, string errorDataField)
        {
            var result = CreateHalfWidthCharsBehavior(name);
            result.SetErrorDataField(errorDataField);
            return result;
        }

        /// <summary>
        /// 半角英数記号以外を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="name">項目名。</param>
        /// <param name="errorColumn">エラー時にフォーカスする列インデックス。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateHalfWidthCharsBehavior(string name, int errorColumn)
        {
            var result = CreateHalfWidthCharsBehavior(name);
            result.SetErrorColumn(errorColumn);
            return result;
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="dataFields">重複検証を行う DataField 値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(string[] dataFields, string name,
            Func<Row, bool> ignore = null)
        {
            return new ValidationBehavior(
                (sheet, cell) =>
                {
                    var count = sheet.Rows.Cast<Row>().Where((row) =>
                    {
                        // 無視する行は対象外
                        if (ignore != null && ignore(row))
                        {
                            return false;
                        }

                        // 値が重複していないものは対象外
                        foreach (var dataField in dataFields)
                        {
                            var sourceValue = cell.Row.GetValueFromDataField(dataField);
                            if (sourceValue == null)
                            {
                                return false;
                            }

                            if (!sourceValue.Equals(row.GetValueFromDataField(dataField)))
                            {
                                return false;
                            }
                        }
                        return true;
                    }).Count();

                    // 自身の項目以上に重複している行ある場合はNGとする
                    if (count > 1)
                    {
                        return false;
                    }

                    return true;
                },
                $"{name}が重複しています。");
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="columns">重複検証を行う列インデックス値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(int[] columns, string name,
            Func<Row, bool> ignore = null)
        {
            return new ValidationBehavior(
                (sheet, cell) =>
                {
                    var count = sheet.Rows.Cast<Row>().Where((row) =>
                    {
                        // 無視する行は対象外
                        if (ignore != null && ignore(row))
                        {
                            return false;
                        }

                        // 値が重複していないものは対象外
                        foreach (var column in columns)
                        {
                            var sourceValue = sheet.Cells[cell.Row.Index, column].Value;
                            if (sourceValue == null)
                            {
                                return false;
                            }

                            if (!sourceValue.Equals(sheet.Cells[row.Index, column].Value))
                            {
                                return false;
                            }
                        }
                        return true;
                    }).Count();

                    // 自身の項目以上に重複している行ある場合はNGとする
                    if (count > 1)
                    {
                        return false;
                    }

                    return true;
                },
                $"{name}が重複しています。");
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="dataField">重複検証を行う DataField 値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(string dataField, string name,
            Func<Row, bool> ignore = null)
        {
            var result = CreateNotDuplicateBehavior(new string[] { dataField }, name, ignore);
            return result;
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="column">重複検証を行う列インデックス値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(int column, string name,
            Func<Row, bool> ignore = null)
        {
            var result = CreateNotDuplicateBehavior(new int[] { column }, name, ignore);
            return result;
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="dataFields">重複検証を行う DataField 値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="errorDataField">エラー時にフォーカスする DataField 値。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(string[] dataFields, string name,
            string errorDataField, Func<Row, bool> ignore = null)
        {
            var result = CreateNotDuplicateBehavior(dataFields, name, ignore);
            result.SetErrorDataField(errorDataField);
            return result;
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="dataFields">重複検証を行う DataField 値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="errorColumn">エラー時にフォーカスする列インデックス。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(string[] dataFields, string name,
            int errorColumn, Func<Row, bool> ignore = null)
        {
            var result = CreateNotDuplicateBehavior(dataFields, name, ignore);
            result.SetErrorColumn(errorColumn);
            return result;
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="columns">重複検証を行う列インデックス値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="errorDataField">エラー時にフォーカスする DataField 値。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(int[] columns, string name,
            string errorDataField, Func<Row, bool> ignore = null)
        {
            var result = CreateNotDuplicateBehavior(columns, name, ignore);
            result.SetErrorDataField(errorDataField);
            return result;
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="columns">重複検証を行う列インデックス値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="errorColumn">エラー時にフォーカスする列インデックス。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(int[] columns, string name,
            int errorColumn, Func<Row, bool> ignore = null)
        {
            var result = CreateNotDuplicateBehavior(columns, name, ignore);
            result.SetErrorColumn(errorColumn);
            return result;
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="dataField">重複検証を行う DataField 値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="errorDataField">エラー時にフォーカスする DataField 値。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(string dataField, string name,
            string errorDataField, Func<Row, bool> ignore = null)
        {
            return CreateNotDuplicateBehavior(new string[] { dataField }, name, errorDataField, ignore);
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="dataField">重複検証を行う DataField 値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="errorColumn">エラー時にフォーカスする列インデックス。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(string dataField, string name,
            int errorColumn, Func<Row, bool> ignore = null)
        {
            return CreateNotDuplicateBehavior(new string[] { dataField }, name, errorColumn, ignore);
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="column">重複検証を行う列インデックス値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="errorDataField">エラー時にフォーカスする DataField 値。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(int column, string name,
            string errorDataField, Func<Row, bool> ignore = null)
        {
            return CreateNotDuplicateBehavior(new int[] { column }, name, errorDataField, ignore);
        }

        /// <summary>
        /// 重複行を許可しない値検証の振る舞いを生成します。
        /// </summary>
        /// <param name="column">重複検証を行う列インデックス値。</param>
        /// <param name="name">項目名。</param>
        /// <param name="errorColumn">エラー時にフォーカスする列インデックス。</param>
        /// <param name="ignore">無視する行の判定処理。</param>
        /// <returns>値検証の振る舞い。</returns>
        public static ValidationBehavior CreateNotDuplicateBehavior(int column, string name,
            int errorColumn, Func<Row, bool> ignore = null)
        {
            return CreateNotDuplicateBehavior(new int[] { column }, name, errorColumn, ignore);
        }

        /// <summary>
        /// 値が null かどうか検証します。
        /// </summary>
        /// <param name="value">値。</param>
        /// <returns>true:null である, false:null でない。</returns>
        public static bool IsNull(object value)
        {
            if (value == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// いずれの値も null かどうかを検証します。
        /// </summary>
        /// <param name="values">複数の値。</param>
        /// <returns>true:いずれの値も null である, false:いずれかの値が null でない。</returns>
        public static bool IsNullAll(object[] values)
        {
            foreach (var value in values)
            {
                if (!IsNull(value))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 値が半角数字だけで構成されるかを検証します。
        /// </summary>
        /// <param name="value">値。</param>
        /// <returns>true:半角数字だけで構成される, false:半角数字以外が含まれる。</returns>
        public static bool IsOnlyHalfWidthNumberChars(string value)
        {
            // 値がない場合はOK
            if (value == null)
            {
                return true;
            }

            List<char> halfNumChars = new List<char>();
            for (var i = 0x30; i <= 0x39; i++)
            {
                halfNumChars.Add((char)i);
            }

            foreach (var charValue in value)
            {
                if (!halfNumChars.Contains(charValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 値が半角英字だけで構成されるかを検証します。
        /// </summary>
        /// <param name="value">値。</param>
        /// <returns>true:半角英字だけで構成される, false:半角英字以外が含まれる。</returns>
        public static bool IsOnlyHalfWidthAlphabetChars(string value)
        {
            // 値がない場合はOK
            if (value == null)
            {
                return true;
            }

            List<char> halfAlphaChars = new List<char>();
            for (var i = 0x41; i <= 0x5a; i++)
            {
                halfAlphaChars.Add((char)i);
            }
            for (var i = 0x61; i <= 0x7a; i++)
            {
                halfAlphaChars.Add((char)i);
            }

            foreach (var charValue in value)
            {
                if (!halfAlphaChars.Contains(charValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 値が半角記号だけで構成されるかを検証します。
        /// </summary>
        /// <param name="value">値。</param>
        /// <returns>true:半角記号だけで構成される, false:半角記号以外が含まれる。</returns>
        public static bool IsOnlyHalfWidthSymbolChars(string value)
        {
            // 値がない場合はOK
            if (value == null)
            {
                return true;
            }

            List<char> halfSymbolChars = new List<char>();
            for (var i = 0x20; i <= 0x2f; i++)
            {
                halfSymbolChars.Add((char)i);
            }
            for (var i = 0x3a; i <= 0x40; i++)
            {
                halfSymbolChars.Add((char)i);
            }
            for (var i = 0x5e; i <= 0x60; i++)
            {
                halfSymbolChars.Add((char)i);
            }
            for (var i = 0x7b; i <= 0x7e; i++)
            {
                halfSymbolChars.Add((char)i);
            }

            foreach (var charValue in value)
            {
                if (!halfSymbolChars.Contains(charValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 値が半角英数だけで構成されるかを検証します。
        /// </summary>
        /// <param name="value">値。</param>
        /// <returns>true:半角英数だけで構成される, false:半角英数以外が含まれる。</returns>
        public static bool IsOnlyHalfWidthNumberAlphabetChars(string value)
        {
            // 値がない場合はOK
            if (value == null)
            {
                return true;
            }

            // 半角数字
            List<char> halfNumChars = new List<char>();
            for (var i = 0x30; i <= 0x39; i++)
            {
                halfNumChars.Add((char)i);
            }

            // 半角英字
            List<char> halfAlphaChars = new List<char>();
            for (var i = 0x41; i <= 0x5a; i++)
            {
                halfAlphaChars.Add((char)i);
            }
            for (var i = 0x61; i <= 0x7a; i++)
            {
                halfAlphaChars.Add((char)i);
            }

            foreach (var charValue in value)
            {
                if (halfNumChars.Contains(charValue))
                {
                    continue;
                }
                if (halfAlphaChars.Contains(charValue))
                {
                    continue;
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// 値が半角英数記号だけで構成されるかを検証します。
        /// </summary>
        /// <param name="value">値。</param>
        /// <returns>true:半角英数記号だけで構成される, false:半角英数記号以外が含まれる。</returns>
        public static bool IsOnlyHalfWidthChars(string value)
        {
            // 値がない場合はOK
            if (value == null)
            {
                return true;
            }

            // 半角数字
            List<char> halfNumChars = new List<char>();
            for (var i = 0x30; i <= 0x39; i++)
            {
                halfNumChars.Add((char)i);
            }

            // 半角英字
            List<char> halfAlphaChars = new List<char>();
            for (var i = 0x41; i <= 0x5a; i++)
            {
                halfAlphaChars.Add((char)i);
            }
            for (var i = 0x61; i <= 0x7a; i++)
            {
                halfAlphaChars.Add((char)i);
            }

            // 半角記号
            List<char> halfSymbolChars = new List<char>();
            for (var i = 0x20; i <= 0x2f; i++)
            {
                halfSymbolChars.Add((char)i);
            }
            for (var i = 0x3a; i <= 0x40; i++)
            {
                halfSymbolChars.Add((char)i);
            }
            for (var i = 0x5e; i <= 0x60; i++)
            {
                halfSymbolChars.Add((char)i);
            }
            for (var i = 0x7b; i <= 0x7e; i++)
            {
                halfSymbolChars.Add((char)i);
            }

            foreach (var charValue in value)
            {
                if (halfNumChars.Contains(charValue))
                {
                    continue;
                }
                if (halfAlphaChars.Contains(charValue))
                {
                    continue;
                }
                if (halfSymbolChars.Contains(charValue))
                {
                    continue;
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// エラー時にフォーカスする DataField 値を設定する。
        /// </summary>
        /// <param name="errorDataField"></param>
        private void SetErrorDataField(string errorDataField)
        {
            ErrorDataField = errorDataField;
        }

        /// <summary>
        /// エラー時にフォーカスする列インデックスを設定する。
        /// </summary>
        /// <param name="errorColumn"></param>
        private void SetErrorColumn(int errorColumn)
        {
            ErrorColumn = errorColumn;
        }
    }
}
