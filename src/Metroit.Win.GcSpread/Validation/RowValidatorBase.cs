using FarPoint.Win.Spread;
using Metroit.Win.GcSpread.Extensions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Metroit.Win.GcSpread.Validation
{
    /// <summary>
    /// 行の検証情報の既定動作を提供します。
    /// </summary>
    public abstract class RowValidatorBase
    {
        /// <summary>
        /// 検証の振る舞いを取得します。
        /// </summary>
        /// <returns></returns>
        public List<ValidationItem> ValidationItems { get; } = new List<ValidationItem>();

        /// <summary>
        /// 呼出元コントロールを取得します。
        /// </summary>
        /// <returns></returns>
        protected Control Owner { get; } = null;

        /// <summary>
        /// エラーメッセージのタイトルを取得します。
        /// </summary>
        protected string MessageTitle { get; } = string.Empty;

        /// <summary>
        /// エラーメッセージのアイコンを取得します。
        /// </summary>
        protected MessageBoxIcon MessageBoxIcon { get; } = MessageBoxIcon.Exclamation;

        /// <summary>
        /// 検証のオプションを取得します。
        /// </summary>
        /// <returns></returns>
        public object Options { get; private set; } = null;

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        public RowValidatorBase() : this(string.Empty, null)
        {
        }

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        /// <param name="owner">呼出元コントロール。</param>
        /// <param name="messageBoxIcon">エラーメッセージのアイコン。</param>
        public RowValidatorBase(Control owner, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation) : this(owner, null, messageBoxIcon)
        {
        }

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        /// <param name="owner">呼出元コントロール。</param>
        /// <param name="options">検証のオプション。</param>
        /// <param name="messageBoxIcon">エラーメッセージのアイコン。</param>
        public RowValidatorBase(Control owner, object options, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation)
        {
            Owner = owner;
            MessageBoxIcon = messageBoxIcon;
            Options = options;
            Configuration(ValidationItems);
        }

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        /// <param name="messageTitle">エラーメッセージのタイトル。</param>
        /// /// <param name="messageBoxIcon">エラーメッセージのアイコン。</param>
        public RowValidatorBase(string messageTitle, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation) : this(messageTitle, null, messageBoxIcon)
        {
        }

        /// <summary>
        /// 新しい RowValidatorBase インスタンスを生成します。
        /// </summary>
        /// <param name="messageTitle">エラーメッセージのタイトル。</param>
        /// <param name="options">検証のオプション。</param>
        /// <param name="messageBoxIcon">エラーメッセージのアイコン。</param>
        public RowValidatorBase(string messageTitle, object options, MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation)
        {
            MessageTitle = messageTitle;
            MessageBoxIcon = messageBoxIcon;
            Options = options;
            Configuration(ValidationItems);
        }

        /// <summary>
        /// 行の検証設定を行います。
        /// </summary>
        /// <param name="validationItems">検証の振る舞い。</param>
        protected abstract void Configuration(List<ValidationItem> validationItems);

        /// <summary>
        /// 行の値検証を行います。
        /// 検証される列は ValidationItem の Column より DataField が優先されます。
        /// エラー時にフォーカスされる列は ValidationBehavior の Column より DataField が優先されます。いずれも設定されていない場合は検証が不正となった列となります。
        /// </summary>
        /// <param name="row">Row オブジェクト。</param>
        /// <returns>true:妥当, false:不当。</returns>
        /// <exception cref="ArgumentException">列が見つかりません。</exception>
        public bool Validate(Row row)
        {
            var sheet = row.GetSheet();

            foreach (var validationItem in ValidationItems)
            {
                Column column;
                if (string.IsNullOrEmpty(validationItem.DataField))
                {
                    if (validationItem.Column < 0)
                    {
                        throw new ArgumentException("列が見つかりません。", $"{nameof(validationItem.Column)}:{validationItem.Column}");
                    }
                    column = sheet.Columns[validationItem.Column];
                }
                else
                {
                    column = sheet.GetColumnFromDataField(validationItem.DataField);
                }
                var cell = sheet.Cells[row.Index, column.Index];

                foreach (var validationBehavior in validationItem.ValidationBehaviors)
                {
                    // 値検証
                    if (validationBehavior.Validate.Invoke(sheet, cell))
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(validationBehavior.ErrorMessage))
                    {
                        // オーナーが設定されている場合はオーナーのタイトルを優先する
                        if (Owner == null)
                        {
                            MessageBox.Show(validationBehavior.ErrorMessage, MessageTitle, MessageBoxButtons.OK, MessageBoxIcon);
                        }
                        else
                        {
                            MessageBox.Show(validationBehavior.ErrorMessage, Owner.Text, MessageBoxButtons.OK, MessageBoxIcon);
                        }
                    }

                    if (string.IsNullOrEmpty(validationBehavior.ErrorDataField) && validationBehavior.ErrorColumn < 0)
                    {
                        sheet.SetActiveCellWithFocus(row.Index, column.Index);
                        return false;
                    }

                    if (string.IsNullOrEmpty(validationBehavior.ErrorDataField))
                    {
                        if (validationBehavior.ErrorColumn < 0)
                        {
                            throw new ArgumentException("列が見つかりません。", $"{nameof(validationBehavior.ErrorColumn)}:{validationBehavior.ErrorColumn}");
                        }
                        sheet.SetActiveCellWithFocus(row.Index, validationBehavior.ErrorColumn);
                    }
                    else
                    {
                        sheet.SetActiveCellWithFocusFromDataField(row.Index, validationBehavior.ErrorDataField);
                    }
                    return false;
                }
            }

            return true;
        }
    }
}
